using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExifLibrary;

namespace EXIF_BatchGPSInserter
{
    public static class ExifBatchProcessor
    {
        public static int Process(string[] camFolders, string rspFile)
        {
            bool forceUpdate = true;

            var gpsPoints = ParseRspFile(rspFile);
            if (gpsPoints.Count == 0) return 0;

            var interpolated = InterpolateWithoutHeading(gpsPoints, 0.005);
            //var interpolated = gpsPoints;

            // Debug print to verify interpolated points
            Console.WriteLine("Interpolated points:");
            foreach (var pt in interpolated)
                Console.WriteLine($"{pt.DistanceMeters:F3}m - Lat: {pt.Latitude}, Lon: {pt.Longitude}");

            Console.WriteLine($"Interpolated points count: {interpolated.Count}");
            foreach (var p in interpolated.Take(5))
            {
                Console.WriteLine($"Point: {p.DistanceMeters:F2} m, Lat: {p.Latitude}, Lon: {p.Longitude}");
            }


            int total = 0;

            var groupedImages = new Dictionary<double, List<string>>();

            foreach (var camFolder in camFolders)
            {
                var jpgFiles = Directory.GetFiles(camFolder, "*.JPG");

                foreach (var imagePath in jpgFiles)
                {
                    double dist = ExtractDistanceFromFilename(imagePath);

                    if (!groupedImages.ContainsKey(dist))
                        groupedImages[dist] = new List<string>();

                    groupedImages[dist].Add(imagePath);
                }
            }

            foreach (var kvp in groupedImages.OrderBy(g => g.Key))
            {
                double imgDist = kvp.Key;
                var images = kvp.Value;

                var gps = interpolated.OrderBy(pt => Math.Abs(pt.DistanceMeters - imgDist)).First();

                Console.WriteLine($"Image distance: {imgDist}m, matched GPS distance: {gps.DistanceMeters}m");

                foreach (var imagePath in images)
                {
                    try
                    {
                        var file = ExifLibrary.ImageFile.FromFile(imagePath);

                        if (!forceUpdate && HasGpsTags(file)) continue;
                        RemoveGpsTags(file);

                        double absLat = Math.Abs(gps.Latitude);
                        double absLng = Math.Abs(gps.Longitude);
                        float? absHeading = gps.Heading.HasValue && gps.Heading.Value >= 0 ? (float?)gps.Heading.Value : null;

                        ConvertToDMS(absLat, out int latDeg, out int latMin, out float latSec);
                        ConvertToDMS(absLng, out int lngDeg, out int lngMin, out float lngSec);

                        file.Properties.Add(ExifTag.GPSLatitude, latDeg, latMin, latSec);
                        file.Properties.Add(ExifTag.GPSLatitudeRef, gps.LatitudeDirection);
                        file.Properties.Add(ExifTag.GPSLongitude, lngDeg, lngMin, lngSec);
                        file.Properties.Add(ExifTag.GPSLongitudeRef, gps.LongitudeDirection);

                        if (absHeading.HasValue)
                        {
                            file.Properties.Add(ExifTag.GPSImgDirection, absHeading.Value);
                            file.Properties.Add(ExifTag.GPSImgDirectionRef, "T");
                        }

                        file.Save(imagePath);
                        total++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to write EXIF for {imagePath}: {ex.Message}");
                    }
                }
            }
        
            return total;
        }

        public static Task<int> ProcessAsync(string[] camFolders, string rspFile)
        {
            return Task.Run(() => Process(camFolders, rspFile));
        }

        private static bool HasGpsTags(ImageFile file)
        {
            return file.Properties.Any(p => p.Tag == ExifTag.GPSLatitude) &&
                   file.Properties.Any(p => p.Tag == ExifTag.GPSLatitudeRef) &&
                   file.Properties.Any(p => p.Tag == ExifTag.GPSLongitude) &&
                   file.Properties.Any(p => p.Tag == ExifTag.GPSLongitudeRef) &&
                   file.Properties.Any(p => p.Tag == ExifTag.GPSImgDirection) &&
                   file.Properties.Any(p => p.Tag == ExifTag.GPSImgDirectionRef);
        }

        private static void RemoveGpsTags(ImageFile file)
        {
            var tagsToRemove = new[]
            {
                    ExifTag.GPSLatitude,
                    ExifTag.GPSLatitudeRef,
                    ExifTag.GPSLongitude,
                    ExifTag.GPSLongitudeRef,
                    ExifTag.GPSImgDirection,
                    ExifTag.GPSImgDirectionRef
        };

            foreach (var tag in tagsToRemove)
            {
                var prop = file.Properties.FirstOrDefault(p => p.Tag == tag);
                if (prop != null)
                    file.Properties.Remove(prop);
            }
        }

        private static void ConvertToDMS(double decimalDegrees, out int degrees, out int minutes, out float seconds)
        {
            degrees = (int)decimalDegrees;
            double minutesFull = (decimalDegrees - degrees) * 60;
            minutes = (int)minutesFull;
            seconds = (float)((minutesFull - minutes) * 60);
        }

        private static List<GpsPoint> ParseRspFile(string rspFile)
        {
            var points = new List<GpsPoint>();
            var headings = new List<Tuple<double, double>>();
            var lines = File.ReadAllLines(rspFile);

            // Parse headings from 5420 lines
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length > 6 && parts[0].StartsWith("5420"))
                {
                    if (double.TryParse(parts[1], out double distanceMeters) &&
                        double.TryParse(parts[6], out double heading))
                    {
                        headings.Add(Tuple.Create(distanceMeters, heading));
                    }
                }
            }

            // Parse GPS points from 5280 lines
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length > 6 && parts[0].StartsWith("5280"))
                {
                    if (double.TryParse(parts[1], out double distanceMeters) &&
                        double.TryParse(parts[5], out double lat) &&
                        double.TryParse(parts[6], out double lng))
                    {
                        points.Add(new GpsPoint
                        {
                            DistanceMeters = distanceMeters,
                            Latitude = lat,
                            LatitudeDirection = lat >= 0 ? "N" : "S",
                            Longitude = lng,
                            LongitudeDirection = lng >= 0 ? "E" : "W"
                        });
                    }
                }
            }

            // Assign closest heading to each point
            foreach (var pt in points)
            {
                if (headings.Count > 0)
                {
                    var closest = headings.OrderBy(h => Math.Abs(h.Item1 - pt.DistanceMeters)).First();
                    pt.Heading = closest.Item2;
                }
            }

            return points;
        }

        private static List<GpsPoint> InterpolateWithoutHeading(List<GpsPoint> points, double intervalMeters)
        {
            var result = new List<GpsPoint>();
            if (points.Count == 0) return result;

            double current = 0.0;
            int i = 0;

            while (current <= points[points.Count - 1].DistanceMeters)
            {
                while (i < points.Count - 1 && points[i + 1].DistanceMeters < current)
                    i++;

                if (i == points.Count - 1) break;

                var p1 = points[i];
                var p2 = points[i + 1];
                double t = (current - p1.DistanceMeters) / (p2.DistanceMeters - p1.DistanceMeters);

                double lat = p1.Latitude + t * (p2.Latitude - p1.Latitude);
                double lng = p1.Longitude + t * (p2.Longitude - p1.Longitude);

                double? heading = null;
                if (p1.Heading.HasValue && p2.Heading.HasValue)
                {
                    heading = p1.Heading + t * (p2.Heading.Value - p1.Heading.Value);
                }

                result.Add(new GpsPoint
                {
                    DistanceMeters = current,
                    Latitude = lat,
                    LatitudeDirection = lat >= 0 ? "N" : "S",
                    Longitude = lng,
                    LongitudeDirection = lng >= 0 ? "E" : "W",
                    Heading = heading
                });

                current += intervalMeters;
            }

            return result;
        }

        private static double ExtractDistanceFromFilename(string filename)
        {
            var name = Path.GetFileNameWithoutExtension(filename);
            var parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Collect all parts that can be parsed as double
            var numericParts = parts
                .Select(p => double.TryParse(p, out double val) ? (double?)val : null)
                .Where(d => d.HasValue)
                .Select(d => d.Value)
                .ToList();

            if (numericParts.Count >= 2)
            {
                // The second last number is the distance in kilometers
                return numericParts[numericParts.Count - 2]; // meters
            }

            // Fallback to zero if not enough numbers found
            return 0;
        }

    }
}
