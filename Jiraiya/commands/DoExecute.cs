using System;
using System.Collections.Generic;
using System.Text;

namespace Jiraiya.commands
{
    [Serializable]
    class DoExecute : command
    {
        public String ne;
        public DoExecute( string n)
        {
            ne = n;
        }
    }
}
