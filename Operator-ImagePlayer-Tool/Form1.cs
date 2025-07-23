using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXIF_BatchGPSInserter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Operator_ImagePlayer_Tool
{
    public partial class Form1 : Form
    {
        string folderRow = @"C:\Users\KelanRafferty\Desktop\Operator\WE20240511\N03D120A\N03D120A_ROW";
        string folderLeft = @"C:\Users\KelanRafferty\Desktop\Operator\WE20240511\N03D120A\N03D120A_LEFT";
        string folderRight = @"C:\Users\KelanRafferty\Desktop\Operator\WE20240511\N03D120A\N03D120A_RIGHT";
        string folderRear = @"C:\Users\KelanRafferty\Desktop\Operator\WE20240511\N03D120A\N03D120A_REAR";

        List<string> imageNames = new List<string>();
        int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            webViewMap.Source = new Uri("file:///C:/path/to/your/image_map.html");
            // Add this for arrow key handling in webViewMap
            webViewMap.PreviewKeyDown += WebViewMap_PreviewKeyDown;
        }

        private void WebViewMap_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;  // Important to tell WinForms not to eat these keys
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                    DisplayImages(currentIndex);
                }
                return true;  // Mark as handled
            }
            else if (keyData == Keys.Right)
            {
                if (currentIndex < imageNames.Count - 1)
                {
                    currentIndex++;
                    DisplayImages(currentIndex);
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(folderRow, "*.JPG");

            imageNames = files
                .Select(Path.GetFileName)
                .OrderBy(f => f)
                .ToList();

            if (imageNames.Count > 0)
            {
                DisplayImages(currentIndex);
            }

            List<string> allImages = Directory.GetFiles(folderRow, "*.JPG").ToList();
            ShowGpsMap(allImages);
            this.Focus();

            this.KeyPreview = true; // To capture key presses
        }

        private void DisplayImages(int index)
        {
            if (index < 0 || index >= imageNames.Count) return;

            string rowFilename = imageNames[index];
            string distance = ExtractDistance(rowFilename);

            string baseName = "N03D120A    "; // Adjust if this changes per project

            // Build expected filenames
            string leftFilename = $"{baseName}{distance} 3.JPG";
            string rearFilename = $"{baseName}{distance} 2.JPG";
            string rightFilename = $"{baseName}{distance} 4.JPG";

            // Build full paths
            string pathRow = Path.Combine(folderRow, rowFilename);
            string pathLeft = Path.Combine(folderLeft, leftFilename);
            string pathRight = Path.Combine(folderRight, rightFilename);
            string pathRear = Path.Combine(folderRear, rearFilename);

            // Load images
            pictureBoxRow.Image = LoadIfExists(pathRow);
            pictureBoxLeft.Image = LoadIfExists(pathLeft);
            pictureBoxRight.Image = LoadIfExists(pathRight);
            pictureBoxRear.Image = LoadIfExists(pathRear);

            // Now update the map with GPS for this Row image
            var gps = ExifHelper.GetGpsCoordinates(pathRow);
            if (gps != null)
            {
                UpdateMapLocation(gps.Value.lat, gps.Value.lon, rowFilename);
            }
        }

        private async void UpdateMapLocation(double lat, double lon, string name)
        {
            if (webViewMap.CoreWebView2 != null)
            {
                // JS code to move map and update marker popup:
                string script = $@"
            (function() {{
                if (!window.map) return;
                var latlng = L.latLng({lat}, {lon});
                window.map.setView(latlng, 18); // zoom level 18

                if (window.currentMarker) {{
                    window.currentMarker.setLatLng(latlng).setPopupContent('{name}').openPopup();
                }} else {{
                    window.currentMarker = L.marker(latlng).addTo(window.map).bindPopup('{name}').openPopup();
                }}
            }})();";

                try
                {
                    await webViewMap.ExecuteScriptAsync(script);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating map location: " + ex.Message);
                }
            }
        }

        private string ExtractDistance(string filename)
        {
            // Assumes format like "N03D120A    0.010 1.JPG"
            var match = System.Text.RegularExpressions.Regex.Match(filename, @"\s+([\d.]+)\s");
            return match.Success ? match.Groups[1].Value : "0.000";
        }

        private Image LoadIfExists(string path)
        {
            if (File.Exists(path))
            {
                return LoadImage(path);
            }
            else
            {
                return null; // or a placeholder image
            }
        }

        private Image LoadImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(fs);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (currentIndex < imageNames.Count - 1)
                {
                    currentIndex++;
                    DisplayImages(currentIndex);
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                    DisplayImages(currentIndex);
                }
            }
        }

        private void btnWriteExif_Click(object sender, EventArgs e)
        {
            string rspPath = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "RSP files (*.RSP)|*.RSP|All files (*.*)|*.*";
                ofd.Title = "Select RSP File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rspPath = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("No RSP file selected.");
                    return;
                }
            }

            // Collect camera folder paths — adjust if you make them user-selectable
            string[] camFolders = new string[]
            {
                folderRow,
                folderLeft,
                folderRight,
                folderRear
            };

            if (string.IsNullOrEmpty(rspPath) || !File.Exists(rspPath) || camFolders.Any(f => !Directory.Exists(f)))
            {
                MessageBox.Show("Missing or invalid RSP file or camera folders.");
                return;
            }

            btnWriteExif.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            int updatedCount = ExifBatchProcessor.Process(camFolders, rspPath);

            Cursor.Current = Cursors.Default;
            btnWriteExif.Enabled = true;

            MessageBox.Show($"{updatedCount} images were updated with GPS EXIF data.");
            List<string> allImages = Directory.GetFiles(folderRow, "*.JPG").ToList();
            ShowGpsMap(allImages);
        }

        private void ShowGpsMap(List<string> imagePaths)
        {
            var points = new List<string>();
            foreach (var path in imagePaths)
            {
                var gps = ExifHelper.GetGpsCoordinates(path);
                if (gps != null)
                {
                    var (lat, lon) = gps.Value;
                    string name = Path.GetFileName(path).Replace("'", "");
                    points.Add($"{{ lat: {lat}, lon: {lon}, name: '{name}' }}");
                }
            }

            string jsonData = "[" + string.Join(",", points) + "]";

            // Adjust path for the template location relative to the executable
            string templatePath = Path.Combine(Application.StartupPath, "Resources", "map_template.html");
            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Map template not found at: " + templatePath);
                return;
            }

            string html = File.ReadAllText(templatePath).Replace("__DATA__", jsonData);

            string tempMapPath = Path.Combine(Path.GetTempPath(), "image_map.html");
            File.WriteAllText(tempMapPath, html);

            webViewMap.Source = new Uri(tempMapPath);
        }
    }
}
