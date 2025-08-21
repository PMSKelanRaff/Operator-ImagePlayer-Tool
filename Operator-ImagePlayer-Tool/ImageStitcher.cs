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

            var stitched = Stitch(leftMat, rightMat);

            // Convert back Mat -> Bitmap
            return BitmapConverter.ToBitmap(stitched);
        }

        public static Mat Stitch(Mat leftBgr, Mat rightBgr)
        {
            // Convert to grayscale for feature detection
            var leftGray = leftBgr.CvtColor(ColorConversionCodes.BGR2GRAY);
            var rightGray = rightBgr.CvtColor(ColorConversionCodes.BGR2GRAY);

            var orb = ORB.Create(5000);
            KeyPoint[] kpLeft;
            var descLeft = new Mat();
            orb.DetectAndCompute(leftGray, null, out kpLeft, descLeft);

            KeyPoint[] kpRight;
            var descRight = new Mat();
            orb.DetectAndCompute(rightGray, null, out kpRight, descRight);

            if (kpLeft.Length < 10 || kpRight.Length < 10)
                throw new Exception("Not enough keypoints detected.");

            // Match with KNN and ratio test
            var matcher = new BFMatcher(NormTypes.Hamming);
            var knn = matcher.KnnMatch(descLeft, descRight, 2);

            var goodMatches = knn
                .Where(m => m.Length == 2 && m[0].Distance < 0.75f * m[1].Distance)
                .Select(m => m[0])
                .ToList();

            if (goodMatches.Count < 8)
                throw new Exception("Not enough good matches after ratio test.");

            // Extract matched points
            Point2f[] srcPts = goodMatches.Select(m => kpLeft[m.QueryIdx].Pt).ToArray();
            Point2f[] dstPts = goodMatches.Select(m => kpRight[m.TrainIdx].Pt).ToArray();

            // Estimate homography
            Mat H = Cv2.FindHomography(InputArray.Create(srcPts), InputArray.Create(dstPts), HomographyMethods.Ransac);
            if (H.Empty())
                throw new Exception("Homography estimation failed.");

            // Prepare canvas
            var canvasSize = new OpenCvSharp.Size(leftBgr.Cols + rightBgr.Cols, Math.Max(leftBgr.Rows, rightBgr.Rows));
            var warpedLeft = new Mat();
            Cv2.WarpPerspective(leftBgr, warpedLeft, H, canvasSize);

            var canvas = new Mat(canvasSize, MatType.CV_8UC3, Scalar.All(0));
            warpedLeft.CopyTo(canvas[new Rect(0, 0, warpedLeft.Cols, warpedLeft.Rows)]);
            rightBgr.CopyTo(canvas[new Rect(0, 0, rightBgr.Cols, rightBgr.Rows)]);

            // Create alpha masks for blending
            var leftMask = new Mat(warpedLeft.Size(), MatType.CV_8UC1);
            Cv2.CvtColor(warpedLeft, leftMask, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(leftMask, leftMask, 1, 255, ThresholdTypes.Binary);

            var rightMask = new Mat(canvas.Size(), MatType.CV_8UC1, Scalar.All(0));
            new Mat(rightBgr.Size(), MatType.CV_8UC1, Scalar.All(255))
                .CopyTo(rightMask[new Rect(0, 0, rightBgr.Cols, rightBgr.Rows)]);

            var overlap = new Mat();
            Cv2.BitwiseAnd(leftMask, rightMask, overlap);

            if (Cv2.CountNonZero(overlap) > 0)
            {
                // Horizontal gradient alpha
                var alpha = new Mat(canvas.Size(), MatType.CV_32FC1);
                for (int x = 0; x < alpha.Cols; x++)
                {
                    float val = (float)x / alpha.Cols;
                    Cv2.Line(alpha, new OpenCvSharp.Point(x, 0), new OpenCvSharp.Point(x, alpha.Rows - 1), new Scalar(val), 1);
                }

                var alpha3 = new Mat();
                Cv2.Merge(new[] { alpha, alpha, alpha }, alpha3);

                canvas.ConvertTo(canvas, MatType.CV_32FC3);
                var rightOnCanvas = new Mat(canvas.Size(), MatType.CV_32FC3, Scalar.All(0));
                var roi = new Rect(0, 0, rightBgr.Cols, rightBgr.Rows);
                rightBgr.ConvertTo(rightOnCanvas[roi], MatType.CV_32FC3);

                var one = new Mat(alpha3.Size(), alpha3.Type(), Scalar.All(1.0));
                var invAlpha = one - alpha3;

                Cv2.Multiply(canvas, invAlpha, canvas);
                Cv2.Multiply(rightOnCanvas, alpha3, rightOnCanvas);
                Cv2.Add(canvas, rightOnCanvas, canvas);

                canvas.ConvertTo(canvas, MatType.CV_8UC3);
            }

            return canvas;
        }
    }
}