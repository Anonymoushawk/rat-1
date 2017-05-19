using System;
using System.Collections.Generic;
using System.Text;

namespace Jiraiya.commands
{
    [Serializable]
    public class DownExec : command
    {
        public String name, dis;
        public byte[] file_part;
        public int current_part, parts, size;
        public Boolean ex;
        public DownExec(string n, byte[] f, int c, int p, int s, Boolean e, string d)
        {
            name = n;
            file_part = f;
            current_part = c;
            parts = p;
            size = s;
            ex = e;
            dis = d;
        }
    }
}
