namespace Operator_ImagePlayer_Tool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxRow = new System.Windows.Forms.PictureBox();
            this.pictureBoxRear = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.btnWriteExif = new System.Windows.Forms.Button();
            this.webViewMap = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.checkBoxShowAll = new System.Windows.Forms.CheckBox();
            this.buttonBackNavigate = new System.Windows.Forms.Button();
            this.buttonFrontNavigate = new System.Windows.Forms.Button();
            this.buttonTogglePlay = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLoadProject = new System.Windows.Forms.Button();
            this.buttonLoadFromAws = new System.Windows.Forms.Button();
            this.buttonStitch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxRow
            // 
            this.pictureBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRow.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxRow.Name = "pictureBoxRow";
            this.pictureBoxRow.Size = new System.Drawing.Size(327, 289);
            this.pictureBoxRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRow.TabIndex = 0;
            this.pictureBoxRow.TabStop = false;
            // 
            // pictureBoxRear
            // 
            this.pictureBoxRear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRear.Location = new System.Drawing.Point(336, 3);
            this.pictureBoxRear.Name = "pictureBoxRear";
            this.pictureBoxRear.Size = new System.Drawing.Size(328, 289);
            this.pictureBoxRear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRear.TabIndex = 1;
            this.pictureBoxRear.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeft.Location = new System.Drawing.Point(3, 298);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(327, 290);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 2;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRight.Location = new System.Drawing.Point(336, 298);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(328, 290);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 3;
            this.pictureBoxRight.TabStop = false;
            // 
            // btnWriteExif
            // 
            this.btnWriteExif.Location = new System.Drawing.Point(676, 542);
            this.btnWriteExif.Name = "btnWriteExif";
            this.btnWriteExif.Size = new System.Drawing.Size(75, 23);
            this.btnWriteExif.TabIndex = 4;
            this.btnWriteExif.Text = "Add GPS";
            this.btnWriteExif.UseVisualStyleBackColor = true;
            this.btnWriteExif.Click += new System.EventHandler(this.btnWriteExif_Click);
            // 
            // webViewMap
            // 
            this.webViewMap.AllowExternalDrop = true;
            this.webViewMap.CreationProperties = null;
            this.webViewMap.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewMap.Location = new System.Drawing.Point(676, 20);
            this.webViewMap.Name = "webViewMap";
            this.webViewMap.Size = new System.Drawing.Size(413, 337);
            this.webViewMap.TabIndex = 5;
            this.webViewMap.ZoomFactor = 1D;
            // 
            // checkBoxShowAll
            // 
            this.checkBoxShowAll.AutoSize = true;
            this.checkBoxShowAll.Location = new System.Drawing.Point(954, 363);
            this.checkBoxShowAll.Name = "checkBoxShowAll";
            this.checkBoxShowAll.Size = new System.Drawing.Size(124, 17);
            this.checkBoxShowAll.TabIndex = 6;
            this.checkBoxShowAll.Text = "Show All GPS Points";
            this.checkBoxShowAll.UseVisualStyleBackColor = true;
            // 
            // buttonBackNavigate
            // 
            this.buttonBackNavigate.Location = new System.Drawing.Point(852, 571);
            this.buttonBackNavigate.Name = "buttonBackNavigate";
            this.buttonBackNavigate.Size = new System.Drawing.Size(75, 23);
            this.buttonBackNavigate.TabIndex = 9;
            this.buttonBackNavigate.Text = "<<";
            this.buttonBackNavigate.UseVisualStyleBackColor = true;
            this.buttonBackNavigate.Click += new System.EventHandler(this.buttonBackNavigate_Click);
            // 
            // buttonFrontNavigate
            // 
            this.buttonFrontNavigate.Location = new System.Drawing.Point(1014, 571);
            this.buttonFrontNavigate.Name = "buttonFrontNavigate";
            this.buttonFrontNavigate.Size = new System.Drawing.Size(75, 23);
            this.buttonFrontNavigate.TabIndex = 10;
            this.buttonFrontNavigate.Text = ">>";
            this.buttonFrontNavigate.UseVisualStyleBackColor = true;
            this.buttonFrontNavigate.Click += new System.EventHandler(this.buttonFrontNavigate_Click);
            // 
            // buttonTogglePlay
            // 
            this.buttonTogglePlay.Location = new System.Drawing.Point(933, 571);
            this.buttonTogglePlay.Name = "buttonTogglePlay";
            this.buttonTogglePlay.Size = new System.Drawing.Size(75, 23);
            this.buttonTogglePlay.TabIndex = 11;
            this.buttonTogglePlay.Text = "Play";
            this.buttonTogglePlay.UseVisualStyleBackColor = true;
            this.buttonTogglePlay.Click += new System.EventHandler(this.buttonTogglePlay_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxRow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxRear, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxRight, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 591);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // buttonLoadProject
            // 
            this.buttonLoadProject.Location = new System.Drawing.Point(676, 571);
            this.buttonLoadProject.Name = "buttonLoadProject";
            this.buttonLoadProject.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadProject.TabIndex = 13;
            this.buttonLoadProject.Text = "Load Project";
            this.buttonLoadProject.UseVisualStyleBackColor = true;
            this.buttonLoadProject.Click += new System.EventHandler(this.buttonLoadProject_Click);
            // 
            // buttonLoadFromAws
            // 
            this.buttonLoadFromAws.Location = new System.Drawing.Point(754, 571);
            this.buttonLoadFromAws.Name = "buttonLoadFromAws";
            this.buttonLoadFromAws.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFromAws.TabIndex = 14;
            this.buttonLoadFromAws.Text = "Load AWS";
            this.buttonLoadFromAws.UseVisualStyleBackColor = true;
            this.buttonLoadFromAws.Click += new System.EventHandler(this.buttonLoadFromAws_Click);
            // 
            // buttonStitch
            // 
            this.buttonStitch.Location = new System.Drawing.Point(754, 542);
            this.buttonStitch.Name = "buttonStitch";
            this.buttonStitch.Size = new System.Drawing.Size(75, 23);
            this.buttonStitch.TabIndex = 15;
            this.buttonStitch.Text = "Stitch Images";
            this.buttonStitch.UseVisualStyleBackColor = true;
            this.buttonStitch.Click += new System.EventHandler(this.buttonStitch_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(693, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 16;
            this.button1.Text = "5";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(774, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 75);
            this.button2.TabIndex = 17;
            this.button2.Text = "4";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(855, 461);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 75);
            this.button3.TabIndex = 18;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.OrangeRed;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(936, 461);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 75);
            this.button4.TabIndex = 19;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.OrangeRed;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1017, 461);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 75);
            this.button5.TabIndex = 20;
            this.button5.Text = "1";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.ForestGreen;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(693, 380);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 75);
            this.button6.TabIndex = 21;
            this.button6.Text = "10";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LimeGreen;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(774, 380);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 75);
            this.button7.TabIndex = 22;
            this.button7.Text = "9";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LimeGreen;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(855, 380);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 75);
            this.button8.TabIndex = 23;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Yellow;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(936, 380);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 75);
            this.button9.TabIndex = 24;
            this.button9.Text = "7";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Yellow;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(1017, 380);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 75);
            this.button10.TabIndex = 25;
            this.button10.Text = "6";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 606);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonStitch);
            this.Controls.Add(this.buttonLoadFromAws);
            this.Controls.Add(this.buttonLoadProject);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonTogglePlay);
            this.Controls.Add(this.buttonFrontNavigate);
            this.Controls.Add(this.buttonBackNavigate);
            this.Controls.Add(this.checkBoxShowAll);
            this.Controls.Add(this.webViewMap);
            this.Controls.Add(this.btnWriteExif);
            this.Name = "Form1";
            this.Text = "Operator-ImagePlayer-Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRow;
        private System.Windows.Forms.PictureBox pictureBoxRear;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button btnWriteExif;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewMap;
        private System.Windows.Forms.CheckBox checkBoxShowAll;
        private System.Windows.Forms.Button buttonBackNavigate;
        private System.Windows.Forms.Button buttonFrontNavigate;
        private System.Windows.Forms.Button buttonTogglePlay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonLoadProject;
        private System.Windows.Forms.Button buttonLoadFromAws;
        private System.Windows.Forms.Button buttonStitch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

