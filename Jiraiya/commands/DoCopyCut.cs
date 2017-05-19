using System;
using System.Collections.Generic;
using System.Text;

namespace Jiraiya.commands
{
    [Serializable]
    class DoCopyCut : command
    {
        public List<string> elements;
        public string dis;
        public DoCopyCut(List<string> l , string d)
        {
            elements = l;
            dis = d;
        }
    }
}
