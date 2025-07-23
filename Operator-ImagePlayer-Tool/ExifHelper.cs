using System.Drawing;
using System;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

public static class ExifHelper
{
    public static (double lat, double lon)? GetGpsCoordinates(string imagePath)
    {
        using (var img = new Bitmap(imagePath))
        {
            PropertyItem[] props = img.PropertyItems;
            var latProp = props.FirstOrDefault(p => p.Id == 0x0002); // GPSLatitude
            var latRef = props.FirstOrDefault(p => p.Id == 0x0001); // GPSLatitudeRef
            var lonProp = props.FirstOrDefault(p => p.Id == 0x0004); // GPSLongitude
            var lonRef = props.FirstOrDefault(p => p.Id == 0x0003); // GPSLongitudeRef

            if (latProp == null || latRef == null || lonProp == null || lonRef == null)
                return null;

            double latitude = ConvertToDegrees(latProp.Value);
            if (Encoding.ASCII.GetString(new byte[] { latRef.Value[0] }) == "S")
                latitude = -latitude;

            double longitude = ConvertToDegrees(lonProp.Value);
            if (Encoding.ASCII.GetString(new byte[] { lonRef.Value[0] }) == "W")
                longitude = -longitude;

            return (latitude, longitude);
        }
    }

    private static double ConvertToDegrees(byte[] raw)
    {
        // Each component is 8 bytes: 4 bytes numerator (uint), 4 bytes denominator (uint)
        double[] dms = new double[3];

        for (int i = 0; i < 3; i++)
        {
            uint numerator = BitConverter.ToUInt32(raw, i * 8);
            uint denominator = BitConverter.ToUInt32(raw, i * 8 + 4);

            if (denominator == 0) // avoid divide by zero
                dms[i] = 0;
            else
                dms[i] = (double)numerator / denominator;
        }

        return dms[0] + (dms[1] / 60.0) + (dms[2] / 3600.0);
    }
}
