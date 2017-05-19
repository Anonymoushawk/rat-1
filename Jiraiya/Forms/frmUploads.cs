using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Jiraiya.commands;

namespace Jiraiya.Forms
{
    public partial class frmUploads : Form
    {
        public string fname,dis;
        public int rec, current_part;
        public Boolean finished , paused;
        FileInfo f;
        tcp.Client client;
        public frmUploads(string n, tcp.Client c , string d)
        {
            fname = n;
            dis = d;
            client = c;
            InitializeComponent();
            H1.Text = fitted_title(Utils.Helpers.getFileTitle(n));
            f = new FileInfo(fname);
          //  client.send_files.Add(new(n,))
            if (f.Length < tcp.Server.fileManager.chunk_size)
            {
                client.Send(new DownExec(fname,
                                         File.ReadAllBytes(fname),
                                         0,
                                         0,
                                         (int)f.Length,
                                         false,
                                         dis
                                         ));
                return;
            }
            tcp.Server.fileManager.start(fname);
            client.Send(new DownExec(tcp.Server.fileManager.clean_path(fname),
                                              tcp.Server.fileManager.tobe_sent,
                                              tcp.Server.fileManager.get_chunk_num(fname),
                                              tcp.Server.fileManager.calc_num_chunks((int)f.Length),
                                              (int)f.Length,
                                              false,
                                              dis
                                              ));

        }

        private void pause_download_Click(object sender, EventArgs e)
        {
            if (pause_download.Text == "Pause")
            {
                paused = true;
                pause_download.Text = "Resume";
            }
            else if (pause_download.Text == "Resume")
            {
                paused=false;

                client.Send(new DownExec(fname,
                                                      tcp.Server.fileManager.tobe_sent,
                                                     current_part,
                                                      tcp.Server.fileManager.calc_num_chunks((int)f.Length),
                                                      (int)f.Length,
                                                      false,
                                                      dis
                                                      ));

                pause_download.Text = "Pause";
            }
        }
        private void frmUploads_Close(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!finished)
            {
                DialogResult dialogResult = MessageBox.Show("Are you Sure ?", "Cancel Upload", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    client.UpExForms.Remove(this);
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                client.UpExForms.Remove(this);
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


        public void update_rate_and_progress(int tr, int ts)
        {
            //count how much i uploaded
            int pv = (int)(Decimal.Divide(tr , ts)*100);
            ProgressBar.Value = pv;
            ProgressBar.Update();

            label_downloaded.Text =  " (" + (Decimal.Divide(tr, ts) * 100).ToString("#") + "%)";
        }


    }
}
