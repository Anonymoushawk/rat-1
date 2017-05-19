using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Jiraiya.tcp
{
    public class Server
    {
        public Socket socket;
        public static Utils.IBfileTrans fileManager = new Utils.IBfileTrans();
        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void start(int port)
        {
            if (!socket.IsBound)
            {

                try
                {
                    socket.Bind(new IPEndPoint(0, port));
                    socket.Listen(0);
                    socket.BeginAccept(acc_callback, null);
                }
                catch (SocketException e)
                {

                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        MessageBox.Show(e.Message);
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        System.Environment.Exit(1);
                    }
                }
            }
            else
            {
                MessageBox.Show("already bound");
            }
        }

        void acc_callback(IAsyncResult ar)
        {
            try
            {
                Socket s = this.socket.EndAccept(ar);

                if (SocketAccepted != null)
                {
                    SocketAccepted(s);
                }

                socket.BeginAccept(acc_callback, null);
            }
            catch (Exception ex) { }
        }

        public delegate void SocketAcceptedEventHandler(Socket s);
        public event SocketAcceptedEventHandler SocketAccepted;


    }
}
