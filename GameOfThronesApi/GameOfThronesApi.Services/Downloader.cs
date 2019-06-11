using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesApi.Services
{
    public class Downloader
    {
        public static string DownloadDataJson(string url)
        {
            using(var client = new WebClient())
            {
                try
                {
                    return client.DownloadString(url);
                }
                catch (WebException)
                {
                    return string.Empty;
                }
            }
        }
    }
}
