using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Cryptography;
using System;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Linq;

namespace Operator_ImagePlayer_Tool
{
    public static class ImageStitcher
    {
        public static Bitmap StitchImages(Image left, Image right)
        {
            // Convert System.Drawing.Image -> Mat
            Mat leftMat = BitmapConverter.ToMat((Bitmap)left);
            Mat rightMat = BitmapConverter.ToMat((Bitmap)right);

            var stitched = Stitch(leftMat, rightMat, 0.30);

            // Convert back Mat -> Bitmap
            return BitmapConverter.ToBitmap(stitched);
        }

        public static Mat Stitch(Mat leftBgr, Mat rightBgr, double overlapRatio = 0.20)
        {
            // Ensure both images are the same height
            if (leftBgr.Rows != rightBgr.Rows)
            {
                double scale = (double)leftBgr.Rows / rightBgr.Rows;
                Cv2.Resize(rightBgr, rightBgr, new OpenCvSharp.Size(rightBgr.Cols * scale, leftBgr.Rows));
            }

            int overlapWidth = (int)(Math.Min(leftBgr.Cols, rightBgr.Cols) * overlapRatio);
            int blendedWidth = leftBgr.Cols + rightBgr.Cols - overlapWidth;

            // Create output canvas
            Mat stitched = new Mat(leftBgr.Rows, blendedWidth, MatType.CV_8UC3, Scalar.All(0));

            // Left part: copy left image fully (except the overlap area)
            var leftRoi = new Mat(stitched, new Rect(0, 0, leftBgr.Cols - overlapWidth, leftBgr.Rows));
            leftBgr[new Rect(0, 0, leftBgr.Cols - overlapWidth, leftBgr.Rows)].CopyTo(leftRoi);

            // Overlap region
            var overlapLeft = leftBgr[new Rect(leftBgr.Cols - overlapWidth, 0, overlapWidth, leftBgr.Rows)];
            var overlapRight = rightBgr[new Rect(0, 0, overlapWidth, rightBgr.Rows)];

            Mat blended = new Mat(overlapLeft.Size(), MatType.CV_8UC3);

            for (int x = 0; x < overlapWidth; x++)
            {
                double alpha = (double)x / overlapWidth; // left fades out, right fades in
                Mat leftCol = overlapLeft[new Rect(x, 0, 1, overlapLeft.Rows)];
                Mat rightCol = overlapRight[new Rect(x, 0, 1, overlapRight.Rows)];
                Cv2.AddWeighted(leftCol, 1.0 - alpha, rightCol, alpha, 0.0, blended[new Rect(x, 0, 1, blended.Rows)]);
            }

            var blendRoi = new Mat(stitched, new Rect(leftBgr.Cols - overlapWidth, 0, overlapWidth, leftBgr.Rows));
            blended.CopyTo(blendRoi);

            // Right part: copy remaining right image
            var rightRoi = new Mat(stitched, new Rect(leftBgr.Cols, 0, rightBgr.Cols - overlapWidth, rightBgr.Rows));
            rightBgr[new Rect(overlapWidth, 0, rightBgr.Cols - overlapWidth, rightBgr.Rows)].CopyTo(rightRoi);

            return stitched;
        }
    }
}