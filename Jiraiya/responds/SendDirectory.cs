using System;
using System.Collections.Generic;
using System.Text;

namespace xClient.responds
{
    [Serializable]
    class SendDirectory : respond
    {
        public List<String> names, types;
        public List<int> sizes;

        public SendDirectory(List<String> n, List<String> t, List<int> s)
        {
            names = n;
            types = t;
            sizes = s;
        }
    }
}
