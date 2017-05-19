namespace Jiraiya.Forms
{
    partial class frmScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarQ = new System.Windows.Forms.TrackBar();
            this.btnPlayScreen = new System.Windows.Forms.Button();
            this.screenBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trackBarQ);
            this.panel1.Controls.Add(this.btnPlayScreen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 38);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quality:  10%";
            // 
            // trackBarQ
            // 
            this.trackBarQ.LargeChange = 1;
            this.trackBarQ.Location = new System.Drawing.Point(186, 2);
            this.trackBarQ.Minimum = 1;
            this.trackBarQ.Name = "trackBarQ";
            this.trackBarQ.Size = new System.Drawing.Size(104, 45);
            this.trackBarQ.TabIndex = 1;
            this.trackBarQ.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarQ.Value = 1;
            this.trackBarQ.Scroll += new System.EventHandler(this.trackBarQ_Scroll);
            // 
            // btnPlayScreen
            // 
            this.btnPlayScreen.Location = new System.Drawing.Point(2, 11);
            this.btnPlayScreen.Name = "btnPlayScreen";
            this.btnPlayScreen.Size = new System.Drawing.Size(75, 23);
            this.btnPlayScreen.TabIndex = 0;
            this.btnPlayScreen.Text = "Stop";
            this.btnPlayScreen.UseVisualStyleBackColor = true;
            this.btnPlayScreen.Click += new System.EventHandler(this.btnPlayScreen_Click);
            // 
            // screenBox
            // 
            this.screenBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.screenBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenBox.Location = new System.Drawing.Point(0, 0);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(713, 379);
            this.screenBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screenBox.TabIndex = 1;
            this.screenBox.TabStop = false;
            // 
            // frmScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 417);
            this.Controls.Add(this.screenBox);
            this.Controls.Add(this.panel1);
            this.Name = "frmScreen";
            this.Text = "frmScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRemoteDesktop_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenBox)).EndInit();
            this.ResumeLayout(false);

        }

    

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarQ;
        private System.Windows.Forms.Button btnPlayScreen;
        public System.Windows.Forms.PictureBox screenBox;
    }
}