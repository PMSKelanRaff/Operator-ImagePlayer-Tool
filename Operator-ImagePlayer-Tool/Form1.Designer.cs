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
            this.btnWriteExif.Location = new System.Drawing.Point(757, 571);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 606);
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
    }
}

