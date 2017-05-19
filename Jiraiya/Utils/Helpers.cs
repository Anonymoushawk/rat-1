using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jiraiya.Utils
{
    class Helpers
    {
        public static int getDirImage(string s)
        {
            switch (s)
            {
                case "drive":
                    return 4;
                    break;
                case "Desktop":
                    return 10;
                    break;
                case "MyDocuments":
                    return 11;
                    break;
                case "MyMusic":
                    return 13;
                    break;
                case "MyPictures":
                    return 12;
                    break;
                case "Startup":
                    return 0;
                    break;
                case "exe":
                case "bat":
                case "com":
                case "scr":
                    return 2;
                    break;
                case "jpg":
                case "jpeg":
                case "bmp":
                case "png":
                case "gif":
                    return 7;
                    break;
                case "folder":
                    return 1;
                    break;
                case "txt":
                    return 3;
                    break;
                case "mp3":
                case "wav":
                case "wma":
                    return 6;
                    break;
                case "bin":
                    return 5;
                    break;
                case "avi":
                case "mp4":
                    return 8;
                    break;
                case "zip":
                case "rar":
                    return 9;
                    break;
                default:
                    return 15;
                    break;
            }
        }

        public static string getDirShortName(string s)
        {
            if (s.Length == 3)
            {
                return s;
            }
            string[] words = s.Split('\\');
            return words[words.Length - 1];
        }
        public static string getFileTitle(string s)
        {
           
            string[] words = s.Split('\\');
            return words[words.Length - 1];
        }

        public static string getUpperPath(string s)
        {
            string[] paths = s.Split('\\');
            if (paths.Length == 1) return "0";
            int d = paths[paths.Length - 1].Length;
            if (d == 0) return "0";
   

            return s.Substring(0, s.Length - d - 1).Length == 2 ? s.Substring(0, s.Length - d - 1) + "\\" : s.Substring(0, s.Length - d - 1);
        }

        public static Boolean isFolder(string s)
        {
            return s.Contains("\\");
        }

        public static string file_size(int n)
        {
            if (n > 1073741824) return Decimal.Divide(n, 1073741824).ToString("#.#") + " GB";
            if (n > 1048576) return Decimal.Divide(n, 1048576).ToString("#.#") + " MB";
            if (n > 1024) return Decimal.Divide(n, 1024).ToString("#.#") + " KB";
            return n + " Byte";
        }

        //--------------------------------------------------
        public static int fileInList(List<tobe_file> lst , string f){
            int r = -1;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].name == f) { r = i; break; }
            }
	 
            return r;
        }
        static string d_path(string s)
        {
            return s.Substring(3);
        }
        public static void buildFile(List<tobe_file> lst, string f)
        {
             int ind = Utils.Helpers.fileInList(lst, f);
             tobe_file  fi = lst[ind];
             byte[] res = new byte[fi.size];
             int off = 0;
             while (fi.queue.Count > 0)
             {
                 byte[] prt = fi.queue.Dequeue();
                 Array.Copy(prt, 0, res, off, prt.Length);
                 off += prt.Length;
             }

             try
             {
                 FileInfo file = new System.IO.FileInfo("C:\\Users\\islam\\Desktop\\t\\"+ d_path(fi.name));
                 file.Directory.Create();
                 File.WriteAllBytes(file.FullName, res);
             }
             catch (Exception) { }
             finally
             {
                 res = new byte[1];
                 res = null;
             }

             //    Console.WriteLine("finished and removing : " + lst[fileInList(lst, f)].name);
                 lst.RemoveAt(fileInList(lst, f));
             
             GC.Collect();
        }

        //----------------------------------------------------
        public static int downWindowIndex(IList<Jiraiya.Forms.frmDownload> l , string s){
            int res = -1;
            for (int i = 0; i < l.Count; i++)
			{
                if (l[i].fname == s) { res = i; break; }
			}
            return res;
        }
        public static int UPWindowIndex(IList<Jiraiya.Forms.frmUploads> l, string s)
        {
            int res = -1;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].fname == s) { res = i; break; }
            }
            return res;
        }
    }
   
    
    public class aFile{
       public String fn,n,t,s;

        public aFile(string ffnn,string nn , string tt, string ss){
            n=nn;
            t=tt;
            s=ss;
            fn=ffnn;
        }
    }

    public class tobe_file
    {
       public string name;
       public int size;
       public int rec;
       public Boolean paused;
       public Queue<byte[]> queue = new Queue<byte[]>();
        public tobe_file(string n, byte[] c , int s , int l)
        {
            name = n;
            queue.Enqueue(c);
            size = s;
            rec = l;
        }
    }


}

