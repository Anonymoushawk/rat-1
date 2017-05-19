using System;
using System.Collections.Generic;
using System.Text;

namespace xClient.responds
{
    [Serializable]
    public class SendInfo : respond
    {
        public string IP,
               pcuser,
               tag,
               country,
               country_code,
               os;
        public int Image_index;
        public SendInfo()
        {

        }

    }
}
