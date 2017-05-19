using System;
using System.Collections.Generic;
using System.Text;

namespace Jiraiya.commands
{
    [Serializable]
    class DoRename : command
    {
        public string old, ne;
        public DoRename(string o, string n)
        {
            old = o;
            ne = n;
        }
    }
}
