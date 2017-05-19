namespace Jiraiya.Forms
{
    partial class frmDownload
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownload));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ProgressBar = new XylosProgressBar();
            this.label_rate = new FirefoxH2();
            this.firefoxH23 = new FirefoxH2();
            this.firefoxH22 = new FirefoxH2();
            this.label_downloaded = new FirefoxH2();
            this.pause_download = new FirefoxRedirect();
            this.lbl_dwn_vn = new FirefoxH2();
            this.H1 = new FirefoxH1();
            this.Restartbtn = new FirefoxRedirect();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "imageres_3.ico_64x64.png");
            this.imageList1.Images.SetKeyName(2, "imageres_15.ico_64x64.png");
            this.imageList1.Images.SetKeyName(3, "imageres_19.ico_64x64.png");
            this.imageList1.Images.SetKeyName(4, "imageres_35.ico_64x64.png");
            this.imageList1.Images.SetKeyName(5, "imageres_54.ico_64x64.png");
            this.imageList1.Images.SetKeyName(6, "imageres_131.ico_64x64.png");
            this.imageList1.Images.SetKeyName(7, "imageres_132.ico_64x64.png");
            this.imageList1.Images.SetKeyName(8, "imageres_133.ico_64x64.png");
            this.imageList1.Images.SetKeyName(9, "imageres_174.ico_64x64.png");
            this.imageList1.Images.SetKeyName(10, "imageres_183.ico_64x64.png");
            this.imageList1.Images.SetKeyName(11, "imageres_1002.ico_64x64.png");
            this.imageList1.Images.SetKeyName(12, "imageres_1003.ico_64x64.png");
            this.imageList1.Images.SetKeyName(13, "imageres_1004.ico_64x64.png");
            this.imageList1.Images.SetKeyName(14, "imageres_5303.ico_64x64.png");
            this.imageList1.Images.SetKeyName(15, "imageres_2.ico_64x64.png");
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(130)))), ((int)(((byte)(254)))));
            this.ProgressBar.Location = new System.Drawing.Point(14, 78);
            this.ProgressBar.Maximum = 100;
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(470, 11);
            this.ProgressBar.Stripes = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(130)))), ((int)(((byte)(254)))));
            this.ProgressBar.TabIndex = 14;
            this.ProgressBar.Text = "xylosProgressBar1";
            this.ProgressBar.Value = 0;
            // 
            // label_rate
            // 
            this.label_rate.AutoSize = true;
            this.label_rate.BackColor = System.Drawing.Color.White;
            this.label_rate.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.label_rate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.label_rate.Location = new System.Drawing.Point(88, 118);
            this.label_rate.Name = "label_rate";
            this.label_rate.Size = new System.Drawing.Size(34, 12);
            this.label_rate.TabIndex = 13;
            this.label_rate.Text = "0 KB/s";
            // 
            // firefoxH23
            // 
            this.firefoxH23.AutoSize = true;
            this.firefoxH23.BackColor = System.Drawing.Color.White;
            this.firefoxH23.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.firefoxH23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.firefoxH23.Location = new System.Drawing.Point(12, 118);
            this.firefoxH23.Name = "firefoxH23";
            this.firefoxH23.Size = new System.Drawing.Size(69, 12);
            this.firefoxH23.TabIndex = 10;
            this.firefoxH23.Text = "Transfer rate :";
            // 
            // firefoxH22
            // 
            this.firefoxH22.AutoSize = true;
            this.firefoxH22.BackColor = System.Drawing.Color.White;
            this.firefoxH22.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.firefoxH22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.firefoxH22.Location = new System.Drawing.Point(12, 102);
            this.firefoxH22.Name = "firefoxH22";
            this.firefoxH22.Size = new System.Drawing.Size(69, 12);
            this.firefoxH22.TabIndex = 9;
            this.firefoxH22.Text = "Downloaded :";
            // 
            // label_downloaded
            // 
            this.label_downloaded.AutoSize = true;
            this.label_downloaded.BackColor = System.Drawing.Color.White;
            this.label_downloaded.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.label_downloaded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.label_downloaded.Location = new System.Drawing.Point(87, 102);
            this.label_downloaded.Name = "label_downloaded";
            this.label_downloaded.Size = new System.Drawing.Size(52, 12);
            this.label_downloaded.TabIndex = 12;
            this.label_downloaded.Text = "0 KB (0%)";
            // 
            // pause_download
            // 
            this.pause_download.BackColor = System.Drawing.Color.White;
            this.pause_download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause_download.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.pause_download.Location = new System.Drawing.Point(12, 140);
            this.pause_download.Name = "pause_download";
            this.pause_download.Size = new System.Drawing.Size(56, 23);
            this.pause_download.TabIndex = 7;
            this.pause_download.Text = "Pause";
            this.pause_download.Click += new System.EventHandler(this.pause_download_Click);
            // 
            // lbl_dwn_vn
            // 
            this.lbl_dwn_vn.AutoSize = true;
            this.lbl_dwn_vn.BackColor = System.Drawing.Color.White;
            this.lbl_dwn_vn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_dwn_vn.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_dwn_vn.Location = new System.Drawing.Point(81, 38);
            this.lbl_dwn_vn.Name = "lbl_dwn_vn";
            this.lbl_dwn_vn.Size = new System.Drawing.Size(0, 15);
            this.lbl_dwn_vn.TabIndex = 5;
            // 
            // H1
            // 
            this.H1.AutoSize = true;
            this.H1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.H1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.H1.Location = new System.Drawing.Point(74, 6);
            this.H1.Name = "H1";
            this.H1.Size = new System.Drawing.Size(100, 33);
            this.H1.TabIndex = 4;
            this.H1.Text = "firefoxH11";
            this.H1.UseCompatibleTextRendering = true;
            // 
            // Restartbtn
            // 
            this.Restartbtn.BackColor = System.Drawing.Color.White;
            this.Restartbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Restartbtn.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.Restartbtn.Location = new System.Drawing.Point(145, 100);
            this.Restartbtn.Name = "Restartbtn";
            this.Restartbtn.Size = new System.Drawing.Size(56, 23);
            this.Restartbtn.TabIndex = 15;
            this.Restartbtn.Text = "Restart";
            this.Restartbtn.Click += new System.EventHandler(this.firefoxRedirect1_Click);
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(496, 175);
            this.Controls.Add(this.Restartbtn);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.label_rate);
            this.Controls.Add(this.firefoxH23);
            this.Controls.Add(this.firefoxH22);
            this.Controls.Add(this.label_downloaded);
            this.Controls.Add(this.pause_download);
            this.Controls.Add(this.lbl_dwn_vn);
            this.Controls.Add(this.H1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 214);
            this.MinimumSize = new System.Drawing.Size(512, 214);
            this.Name = "frmDownload";
            this.Text = "Downloads";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDownload_Close);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private FirefoxH1 H1;
        private FirefoxH2 lbl_dwn_vn;
        public FirefoxRedirect pause_download;
        private FirefoxH2 firefoxH22;
        public FirefoxH2 label_downloaded;
        public XylosProgressBar ProgressBar;
        private System.Windows.Forms.ImageList imageList1;
        public FirefoxH2 firefoxH23;
        public FirefoxH2 label_rate;
        public FirefoxRedirect Restartbtn;


    }
}