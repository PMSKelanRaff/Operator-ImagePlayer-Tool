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

        string folderRow;
        string folderLeft;
        string folderRight;
        string folderRear;
        private string folderBase;

        List<string> imageNames = new List<string>();
        private Timer autoLoopTimer;
        int currentIndex = 0;
        private static bool hasRunOnce = false;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            webViewMap.PreviewKeyDown += webViewMap_PreviewKeyDown;

            webViewMap.Source = new Uri("file:///C:/path/to/your/image_map.html");
            // Add this for arrow key handling in webViewMap
            webViewMap.PreviewKeyDown += WebViewMap_PreviewKeyDown;

            //disable buttons until project is loaded
            buttonTogglePlay.Enabled = false;
            buttonBackNavigate.Enabled = false;
            buttonFrontNavigate.Enabled = false;

            //initialise timer
            autoLoopTimer = new Timer();
            autoLoopTimer.Interval = 200; // 5 images per second
            autoLoopTimer.Tick += AutoLoopTimer_Tick;

        }

        private void LoadImageList()
        {
            var files = Directory.GetFiles(folderRow, "*.JPG");
            imageNames = files.Select(Path.GetFileName)
                              .OrderBy(f => f)
                              .ToList();

            if (imageNames.Count > 0)
            {
                currentIndex = 0;
                DisplayImages(currentIndex);
                ShowGpsMap(files.ToList());
            }
            else
            {
                MessageBox.Show("No images found in ROW folder.");
            }
        }

        private void WebViewMap_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;  // Important to tell WinForms not to eat these keys
            }
        }

        private void webViewMap_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;  // Tell WinForms to treat these as regular input keys
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
            // Only show the folder check message after the first run
            if (hasRunOnce)
            {
                if (string.IsNullOrEmpty(folderRow) || !Directory.Exists(folderRow))
                {
                    MessageBox.Show("ROW folder not set or does not exist. Please load a project first.");
                    return;
                }
            }
            else
            {
                hasRunOnce = true; // Mark the first run as complete
            }

            // Validate folderRow before continuing
            if (string.IsNullOrEmpty(folderRow) || !Directory.Exists(folderRow))
            {
                return;
            }

            var files = Directory.GetFiles(folderRow, "*.JPG");

            imageNames = files
                .Select(Path.GetFileName)
                .OrderBy(f => f)
                .ToList();

            if (imageNames.Count > 0)
            {
                DisplayImages(currentIndex);
            }
            else
            {
                MessageBox.Show("No images found in ROW folder.");
            }

            List<string> allImages = Directory.GetFiles(folderRow, "*.JPG").ToList();
            ShowGpsMap(allImages);

            this.Focus();
            this.KeyPreview = true; // Capture key presses
        }

        private async void DisplayImages(int index)
        {
            if (index < 0 || index >= imageNames.Count) return;

            currentIndex = index;

            string rowFilename = imageNames[index];
            string distance = ExtractDistance(rowFilename);

            string baseName = Path.GetFileName(folderBase) + "    ";  // Adds four spaces
            string leftFilename = $"{baseName}{distance} 3.JPG";
            string rearFilename = $"{baseName}{distance} 2.JPG";
            string rightFilename = $"{baseName}{distance} 4.JPG";

            string pathRow = Path.Combine(folderRow, rowFilename);
            string pathLeft = Path.Combine(folderLeft, leftFilename);
            string pathRight = Path.Combine(folderRight, rightFilename);
            string pathRear = Path.Combine(folderRear, rearFilename);

            pictureBoxRow.Image = LoadIfExists(pathRow);
            pictureBoxLeft.Image = LoadIfExists(pathLeft);
            pictureBoxRight.Image = LoadIfExists(pathRight);
            pictureBoxRear.Image = LoadIfExists(pathRear);

            var gps = ExifHelper.GetGpsCoordinates(pathRow);
            if (gps == null) return;

            double lat = gps.Value.lat;
            double lon = gps.Value.lon;
            string name = Path.GetFileName(pathRow).Replace("'", "");

            if (webViewMap.CoreWebView2 != null)
            {
                try
                {
                    if (checkBoxShowAll.Checked)
                    {
                        // Show all markers and fit map to bounds
                        await webViewMap.ExecuteScriptAsync("window.showAllMarkers();");
                    }
                    else
                    {
                        // Clear all markers and show only the current one
                        await UpdateMapLocation(lat, lon, name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating map: " + ex.Message);
                }
            }
        }

        private async Task UpdateMapLocation(double lat, double lon, string name)
        {
            if (webViewMap.CoreWebView2 != null)
            {
                string script = $"window.updateSingleMarker({lat}, {lon}, '{name}');";

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

        private async void btnWriteExif_Click(object sender, EventArgs e)
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

            try
            {
                int updatedCount = await ExifBatchProcessor.ProcessAsync(camFolders, rspPath);
                MessageBox.Show($"{updatedCount} images were updated with GPS EXIF data.");

                List<string> allImages = Directory.GetFiles(folderRow, "*.JPG").ToList();
                ShowGpsMap(allImages);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during EXIF processing: {ex.Message}");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                btnWriteExif.Enabled = true;
            }
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

        private void checkBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            DisplayImages(currentIndex); //updates map dynamically
        }

        private void AutoLoopTimer_Tick(object sender, EventArgs e)
        {
            if (currentIndex >= imageNames.Count)
            {
                currentIndex = 0; // Optionally loop back to start
            }

            DisplayImages(currentIndex);
            currentIndex++;
        }

        private void buttonBackNavigate_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayImages(currentIndex);
            }
        }

        private void buttonFrontNavigate_Click(object sender, EventArgs e)
        {
            if (currentIndex < imageNames.Count - 1)
            {
                currentIndex++;
                DisplayImages(currentIndex);
            }
        }

        private void buttonTogglePlay_Click(object sender, EventArgs e)
        {
            if (autoLoopTimer.Enabled)
            {
                autoLoopTimer.Stop();
                buttonTogglePlay.Text = "Play";
            }
            else
            {
                autoLoopTimer.Start();
                buttonTogglePlay.Text = "Pause";
            }
        }

        private void buttonLoadProject_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a project folder (e.g., N03D120A)";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    folderBase = dialog.SelectedPath;
                    string projectName = Path.GetFileName(folderBase);

                    folderRow = Path.Combine(folderBase, projectName + "_ROW");
                    folderLeft = Path.Combine(folderBase, projectName + "_LEFT");
                    folderRight = Path.Combine(folderBase, projectName + "_RIGHT");
                    folderRear = Path.Combine(folderBase, projectName + "_REAR");

                    if (Directory.Exists(folderRow) &&
                        Directory.Exists(folderLeft) &&
                        Directory.Exists(folderRight) &&
                        Directory.Exists(folderRear))
                    {
                        LoadImageList();

                        // Enable controls now that project and images are loaded
                        buttonTogglePlay.Enabled = true;
                        buttonBackNavigate.Enabled = true;
                        buttonFrontNavigate.Enabled = true;
                        btnWriteExif.Enabled = true; // If you want to enable EXIF writing here
                    }
                    else
                    {
                        MessageBox.Show("One or more camera folders are missing.");
                    }
                }
            }
        }
    
    }
}
