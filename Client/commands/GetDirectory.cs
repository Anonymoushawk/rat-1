using System;
using System.Collections.Generic;
using System.Text;

namespace Jiraiya.commands
{
    [Serializable]
    class GetDirectory : command
    {
       public  String dir;
       public GetDirectory(String d)
       {
           this.dir = d;
       }
    }
}
