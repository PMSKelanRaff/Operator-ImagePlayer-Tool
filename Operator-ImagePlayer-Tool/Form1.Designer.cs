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
            this.checkBoxAutoPlay = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRow
            // 
            this.pictureBoxRow.Location = new System.Drawing.Point(3, 20);
            this.pictureBoxRow.Name = "pictureBoxRow";
            this.pictureBoxRow.Size = new System.Drawing.Size(330, 246);
            this.pictureBoxRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRow.TabIndex = 0;
            this.pictureBoxRow.TabStop = false;
            // 
            // pictureBoxRear
            // 
            this.pictureBoxRear.Location = new System.Drawing.Point(339, 20);
            this.pictureBoxRear.Name = "pictureBoxRear";
            this.pictureBoxRear.Size = new System.Drawing.Size(330, 246);
            this.pictureBoxRear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRear.TabIndex = 1;
            this.pictureBoxRear.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(3, 272);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(330, 272);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 2;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Location = new System.Drawing.Point(339, 272);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(330, 272);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 3;
            this.pictureBoxRight.TabStop = false;
            // 
            // btnWriteExif
            // 
            this.btnWriteExif.Location = new System.Drawing.Point(1014, 571);
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
            this.checkBoxShowAll.Location = new System.Drawing.Point(691, 363);
            this.checkBoxShowAll.Name = "checkBoxShowAll";
            this.checkBoxShowAll.Size = new System.Drawing.Size(124, 17);
            this.checkBoxShowAll.TabIndex = 6;
            this.checkBoxShowAll.Text = "Show All GPS Points";
            this.checkBoxShowAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoPlay
            // 
            this.checkBoxAutoPlay.AutoSize = true;
            this.checkBoxAutoPlay.Location = new System.Drawing.Point(835, 364);
            this.checkBoxAutoPlay.Name = "checkBoxAutoPlay";
            this.checkBoxAutoPlay.Size = new System.Drawing.Size(112, 17);
            this.checkBoxAutoPlay.TabIndex = 8;
            this.checkBoxAutoPlay.Text = "Auto Loop (5/sec)";
            this.checkBoxAutoPlay.UseVisualStyleBackColor = true;
            this.checkBoxAutoPlay.CheckedChanged += new System.EventHandler(this.checkBoxAutoPlay_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 606);
            this.Controls.Add(this.checkBoxAutoPlay);
            this.Controls.Add(this.checkBoxShowAll);
            this.Controls.Add(this.webViewMap);
            this.Controls.Add(this.btnWriteExif);
            this.Controls.Add(this.pictureBoxRear);
            this.Controls.Add(this.pictureBoxRow);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Name = "Form1";
            this.Text = "Operator-ImagePlayer-Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBoxAutoPlay;
    }
}

