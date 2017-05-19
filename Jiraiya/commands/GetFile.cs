using System;
using System.Collections.Generic;
using System.Text;

namespace Jiraiya.commands
{
    [Serializable]
    class GetFile : command
    {
        public String file;
        public GetFile(string f)
        {
            file = f;
        }
    }
}
