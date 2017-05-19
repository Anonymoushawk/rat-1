namespace Jiraiya.Forms
{
    partial class frmControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControl));
            this.hName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.small_icons = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.files_imageList = new System.Windows.Forms.ImageList(this.components);
            this.firefoxSubTabControl1 = new FirefoxSubTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.files_ListView = new AeroListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fmLoadPic = new System.Windows.Forms.PictureBox();
            this.txtDirPath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStripDirectory.SuspendLayout();
            this.firefoxSubTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fmLoadPic)).BeginInit();
            this.SuspendLayout();
            // 
            // hName
            // 
            this.hName.Text = "Name";
            this.hName.Width = 360;
            // 
            // hSize
            // 
            this.hSize.Text = "Size";
            this.hSize.Width = 125;
            // 
            // hType
            // 
            this.hType.Text = "Type";
            this.hType.Width = 168;
            // 
            // small_icons
            // 
            this.small_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("small_icons.ImageStream")));
            this.small_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.small_icons.Images.SetKeyName(0, "imageres_1302.ico_16x16.png");
            this.small_icons.Images.SetKeyName(1, "loading.gif");
            // 
            // contextMenuStripDirectory
            // 
            this.contextMenuStripDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.lineToolStripMenuItem,
            this.executeToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStripDirectory.Name = "ctxtMenu";
            this.contextMenuStripDirectory.Size = new System.Drawing.Size(153, 208);
            this.contextMenuStripDirectory.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripDirectory_Opening);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("downloadToolStripMenuItem.Image")));
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadToolStripMenuItem.Image")));
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Cut";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "past";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("executeToolStripMenuItem.Image")));
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameToolStripMenuItem.Image")));
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // files_imageList
            // 
            this.files_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("files_imageList.ImageStream")));
            this.files_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.files_imageList.Images.SetKeyName(0, "1.png");
            this.files_imageList.Images.SetKeyName(1, "imageres_3.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(2, "imageres_15.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(3, "imageres_19.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(4, "imageres_35.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(5, "imageres_54.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(6, "imageres_131.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(7, "imageres_132.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(8, "imageres_133.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(9, "imageres_174.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(10, "imageres_183.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(11, "imageres_1002.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(12, "imageres_1003.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(13, "imageres_1004.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(14, "imageres_5303.ico_64x64.png");
            this.files_imageList.Images.SetKeyName(15, "imageres_2.ico_64x64.png");
            // 
            // firefoxSubTabControl1
            // 
            this.firefoxSubTabControl1.Controls.Add(this.tabPage1);
            this.firefoxSubTabControl1.Controls.Add(this.tabPage2);
            this.firefoxSubTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firefoxSubTabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.firefoxSubTabControl1.Location = new System.Drawing.Point(0, 0);
            this.firefoxSubTabControl1.Name = "firefoxSubTabControl1";
            this.firefoxSubTabControl1.SelectedIndex = 0;
            this.firefoxSubTabControl1.Size = new System.Drawing.Size(789, 452);
            this.firefoxSubTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.firefoxSubTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.files_ListView);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Explorer";
            // 
            // files_ListView
            // 
            this.files_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.files_ListView.ContextMenuStrip = this.contextMenuStripDirectory;
            this.files_ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.files_ListView.FullRowSelect = true;
            this.files_ListView.LargeImageList = this.files_imageList;
            this.files_ListView.Location = new System.Drawing.Point(3, 33);
            this.files_ListView.Name = "files_ListView";
            this.files_ListView.Size = new System.Drawing.Size(775, 368);
            this.files_ListView.TabIndex = 3;
            this.files_ListView.UseCompatibleStateImageBehavior = false;
            this.files_ListView.View = System.Windows.Forms.View.Tile;
            this.files_ListView.DoubleClick += new System.EventHandler(this.files_ListView_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel1.Size = new System.Drawing.Size(775, 30);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.fmLoadPic);
            this.panel2.Controls.Add(this.txtDirPath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 25);
            this.panel2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(30, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fmLoadPic
            // 
            this.fmLoadPic.ErrorImage = ((System.Drawing.Image)(resources.GetObject("fmLoadPic.ErrorImage")));
            this.fmLoadPic.Image = ((System.Drawing.Image)(resources.GetObject("fmLoadPic.Image")));
            this.fmLoadPic.InitialImage = ((System.Drawing.Image)(resources.GetObject("fmLoadPic.InitialImage")));
            this.fmLoadPic.Location = new System.Drawing.Point(56, 4);
            this.fmLoadPic.Name = "fmLoadPic";
            this.fmLoadPic.Size = new System.Drawing.Size(16, 16);
            this.fmLoadPic.TabIndex = 4;
            this.fmLoadPic.TabStop = false;
            // 
            // txtDirPath
            // 
            this.txtDirPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDirPath.Location = new System.Drawing.Point(77, 3);
            this.txtDirPath.Name = "txtDirPath";
            this.txtDirPath.Size = new System.Drawing.Size(685, 18);
            this.txtDirPath.TabIndex = 6;
            this.txtDirPath.Text = "home";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 452);
            this.Controls.Add(this.firefoxSubTabControl1);
            this.Name = "frmControl";
            this.Text = "Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControl_Close);
            this.contextMenuStripDirectory.ResumeLayout(false);
            this.firefoxSubTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fmLoadPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        public AeroListView files_ListView;
        private System.Windows.Forms.Panel panel1;
        private FirefoxSubTabControl firefoxSubTabControl1;
        private System.Windows.Forms.ColumnHeader hName;
        private System.Windows.Forms.ColumnHeader hSize;
        private System.Windows.Forms.ColumnHeader hType;
        public System.Windows.Forms.PictureBox fmLoadPic;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtDirPath;
        public System.Windows.Forms.ImageList small_icons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDirectory;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ImageList files_imageList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}