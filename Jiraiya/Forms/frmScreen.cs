using Jiraiya.tcp;
using Jiraiya.commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jiraiya.Forms
{
    public partial class frmScreen : Form
    {
        public Client client;
        public int quality;
        public Boolean go = true;
        public frmScreen(Client c)
        {
            InitializeComponent();
            c.frmScreen = this;
            this.client = c;
            c.Send(new GetScreen(50, 1, 1));
        }

        private void FrmRemoteDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.client.frmScreen = null;
        }

        private void btnPlayScreen_Click(object sender, EventArgs e)
        {
            if (go)
            {
                btnPlayScreen.Text = "Start";
                go = false;
            }
            else
            {
                client.Send(new GetScreen((trackBarQ.Value * 10), 1, 1));
                go = true;
                btnPlayScreen.Text = "Stop";
            }
           
        }

        private void trackBarQ_Scroll(object sender, EventArgs e)
        {
            try { 
            this.quality = (trackBarQ.Value * 10)-5;
            this.label1.Text = "Quality: " + (trackBarQ.Value*10).ToString() + " %";
                }
            catch (Exception) { }
        }

      
    }
}
