namespace Jiraiya.Forms
{
    partial class frmRename
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
            this.T = new System.Windows.Forms.TextBox();
            this.firefoxButton2 = new FirefoxButton();
            this.firefoxButton1 = new FirefoxButton();
            this.SuspendLayout();
            // 
            // T
            // 
            this.T.Location = new System.Drawing.Point(12, 12);
            this.T.Name = "T";
            this.T.Size = new System.Drawing.Size(382, 20);
            this.T.TabIndex = 1;
            // 
            // firefoxButton2
            // 
            this.firefoxButton2.EnabledCalc = true;
            this.firefoxButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.firefoxButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(80)))));
            this.firefoxButton2.Location = new System.Drawing.Point(200, 38);
            this.firefoxButton2.Name = "firefoxButton2";
            this.firefoxButton2.Size = new System.Drawing.Size(194, 23);
            this.firefoxButton2.TabIndex = 2;
            this.firefoxButton2.Text = "Cancel";
            this.firefoxButton2.Click += new System.EventHandler(this.firefoxButton2_Click);
            // 
            // firefoxButton1
            // 
            this.firefoxButton1.EnabledCalc = true;
            this.firefoxButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.firefoxButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(80)))));
            this.firefoxButton1.Location = new System.Drawing.Point(12, 38);
            this.firefoxButton1.Name = "firefoxButton1";
            this.firefoxButton1.Size = new System.Drawing.Size(182, 23);
            this.firefoxButton1.TabIndex = 0;
            this.firefoxButton1.Text = "Rename";
            this.firefoxButton1.Click += new System.EventHandler(this.firefoxButton1_Click);
            // 
            // frmRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 69);
            this.ControlBox = false;
            this.Controls.Add(this.firefoxButton2);
            this.Controls.Add(this.T);
            this.Controls.Add(this.firefoxButton1);
            this.Name = "frmRename";
            this.Text = "frmRename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FirefoxButton firefoxButton1;
        private System.Windows.Forms.TextBox T;
        private FirefoxButton firefoxButton2;
    }
}