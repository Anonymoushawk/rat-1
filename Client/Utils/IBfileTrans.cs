using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace xClient.Utils
{
    class IBfileTrans
    {
        public static int chunk_size = 80*1024;
      
        public byte[] tobe_sent = new byte[chunk_size];
     
        public void set_file_Chunk(String fpath, int index)
        {

            byte[] f = File.ReadAllBytes(fpath);
            int cpy_lengt = (index+1) * chunk_size > f.Length ? f.Length - (index) * chunk_size : chunk_size;
            tobe_sent = new byte[cpy_lengt];
            Array.Copy(f, index * chunk_size,tobe_sent,0,tobe_sent.Length);
        }

        public int get_chunk_num(string s)
        {
            string re = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsNumber(s[i])) re += s[i];
                else break;
            }
            if (re == "") return 0;
            return Int32.Parse(re);
        }

        public int calc_num_chunks(int x)
        {
            if (x % chunk_size == 0) return x / chunk_size;
            return (x / chunk_size) + 1;
        }

        public string clean_path(string s)
        {
            string r = "";
            int ind =0;
            for (int i = 0; i <s.Length; i++)
			{
                if (Char.IsNumber(s[i])) ind++;
                else break;
			}
            return s.Substring(ind);
        }
       
        public void start(string file)
        {
            lock (tobe_sent)
            {
                set_file_Chunk(clean_path(file), get_chunk_num(file));
            }   
        }
    }
}
