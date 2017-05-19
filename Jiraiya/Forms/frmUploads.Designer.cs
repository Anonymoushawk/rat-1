namespace Jiraiya.Forms
{
    partial class frmUploads
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
            this.pause_download = new FirefoxRedirect();
            this.label_downloaded = new FirefoxH2();
            this.ProgressBar = new XylosProgressBar();
            this.H1 = new FirefoxH1();
            this.SuspendLayout();
            // 
            // pause_download
            // 
            this.pause_download.BackColor = System.Drawing.Color.White;
            this.pause_download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause_download.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.pause_download.Location = new System.Drawing.Point(12, 29);
            this.pause_download.Name = "pause_download";
            this.pause_download.Size = new System.Drawing.Size(49, 23);
            this.pause_download.TabIndex = 17;
            this.pause_download.Text = "Pause";
            this.pause_download.Click += new System.EventHandler(this.pause_download_Click);
            // 
            // label_downloaded
            // 
            this.label_downloaded.AutoSize = true;
            this.label_downloaded.BackColor = System.Drawing.Color.White;
            this.label_downloaded.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.label_downloaded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.label_downloaded.Location = new System.Drawing.Point(225, 50);
            this.label_downloaded.Name = "label_downloaded";
            this.label_downloaded.Size = new System.Drawing.Size(52, 12);
            this.label_downloaded.TabIndex = 16;
            this.label_downloaded.Text = "0 KB (0%)";
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(130)))), ((int)(((byte)(254)))));
            this.ProgressBar.Location = new System.Drawing.Point(64, 36);
            this.ProgressBar.Maximum = 100;
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(395, 11);
            this.ProgressBar.Stripes = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(130)))), ((int)(((byte)(254)))));
            this.ProgressBar.TabIndex = 15;
            this.ProgressBar.Text = "xylosProgressBar1";
            this.ProgressBar.Value = 2;
            // 
            // H1
            // 
            this.H1.AutoSize = true;
            this.H1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.H1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.H1.Location = new System.Drawing.Point(64, 0);
            this.H1.Margin = new System.Windows.Forms.Padding(0);
            this.H1.Name = "H1";
            this.H1.Size = new System.Drawing.Size(100, 33);
            this.H1.TabIndex = 5;
            this.H1.Text = "firefoxH11";
            this.H1.UseCompatibleTextRendering = true;
            // 
            // frmUploads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(471, 72);
            this.Controls.Add(this.pause_download);
            this.Controls.Add(this.label_downloaded);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.H1);
            this.MaximizeBox = false;
            this.Name = "frmUploads";
            this.Text = "frmUploads";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUploads_Close);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FirefoxH1 H1;
        public XylosProgressBar ProgressBar;
        public FirefoxH2 label_downloaded;
        public FirefoxRedirect pause_download;
    }
}