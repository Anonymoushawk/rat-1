using System;
using System.Collections.Generic;
using System.Text;

namespace xClient.responds
{
     [Serializable]
    class SendFile : Respond
    {
       public  String name;
       public byte[] file_part;
       public int current_part, parts , size;
       public SendFile(string n, byte[] f , int c , int p , int s)
         {
             name = n;
             file_part = f;
             current_part = c;
             parts = p;
             size = s;
         }
    }
}
