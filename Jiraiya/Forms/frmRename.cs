using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jiraiya.commands;
using Jiraiya.Utils;


namespace Jiraiya.Forms
{
    public partial class frmRename : Form
    {
        tcp.Client client;
        string fname;
        System.IO.FileInfo fi = null;
        public frmRename(tcp.Client c , string n)
        {
            client = c;
            fname = n;
            InitializeComponent();
            T.Text = Utils.Helpers.getFileTitle(n);
        }

        private void firefoxButton1_Click(object sender, EventArgs e)
        {
            try
            {
                fi = new System.IO.FileInfo(T.Text);
            }
            catch (ArgumentException) { }
            catch (System.IO.PathTooLongException) { }
            catch (NotSupportedException) { }
            if (ReferenceEquals(fi, null))
            {
                MessageBox.Show("Invalid Input");
            }
            else
            {
                client.Send(new DoRename(this.fname, T.Text));
                this.Close();
            }
        }

        private void firefoxButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
