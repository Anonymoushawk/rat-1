using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jiraiya.commands;


namespace Jiraiya.Forms
{
    public partial class frmDownload : Form
    {
        public string fname;
        public int rec;
        public int current_part;
        public Boolean finished;
        tcp.Client client;
        Stopwatch sw = new Stopwatch();
        public frmDownload(string n ,  tcp.Client c)
        {
            fname = n;
            client = c;
            InitializeComponent();
            string fo = n.Split('.')[n.Split('.').Length-1];
            pictureBox1.Image = imageList1.Images[Utils.Helpers.getDirImage(fo)];
            imageList1.ImageSize = new Size(64, 64);
            
            H1.Text = fitted_title(Utils.Helpers.getFileTitle(n));
            lbl_dwn_vn.Text = c.data.UserAtPc;
            sw.Start();

        }

        public void update_rate_and_progress(int r , int cp , int np , int tr , int ts)
        {
            Restartbtn.Hide();
            int pv =(int)(Decimal.Divide(tr, ts) * 100);
            ProgressBar.Value = pv;
            ProgressBar.Update();

            label_downloaded.Text = Utils.Helpers.file_size(tr) + "/ " + Utils.Helpers.file_size (ts)+ " (" + (Decimal.Divide(tr, ts) * 100).ToString("#") + "%)";
                       
            //------------------------
            rec += r;
            int et = sw.ElapsedMilliseconds > 1 ? (int)sw.ElapsedMilliseconds : 1;
            int v = 1000 * rec / et;
                label_rate.Text = Utils.Helpers.file_size(v) + "/s";
                sw.Reset();
                sw.Stop();
                sw.Start();
                rec = 0;
            
        }

        private void frmDownload_Close(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!finished)
            {
                DialogResult dialogResult = MessageBox.Show("Are you Sure ?", "Cancel Download", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    client.downForms.Remove(this);
                   
                    int inn = Utils.Helpers.fileInList(client.rec_files, fname);
                    
                    if (inn > -1 && inn < client.rec_files.Count){
                      //  Console.WriteLine("Removing : " + client.rec_files[inn].name);
                        client.rec_files.RemoveAt(inn);
                    }
                   

                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel=true;
                }
            }
            else
            {
                client.downForms.Remove(this);
            }
           

        }

        string fitted_title(string s)
        {
            if (s.Length > 30)
            {
                string n = s.Substring(s.Length - 30);
                n = "..." + n;
                return n;
            }
            return s;
        }

        private void pause_download_Click(object sender, EventArgs e)
        {
            if (pause_download.Text == "Pause")
            {
                int inn = Utils.Helpers.fileInList(client.rec_files, fname);
                if(inn< client.rec_files.Count && inn > -1)
                {
                    client.rec_files[inn].paused = true;
                pause_download.Text = "Resume";
                }
            }
            else if (pause_download.Text == "Resume")
            {
                client.rec_files[Utils.Helpers.fileInList(client.rec_files, fname)].paused = false;
                client.Send(new GetFile((current_part + 1) + fname));
                pause_download.Text = "Pause";
            }
        }

        private void firefoxRedirect1_Click(object sender, EventArgs e)
        {
            client.Send(new GetFile(fname));
        }
    }
}
