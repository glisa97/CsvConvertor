using AgTest.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AgTest
{
    public class FIleDownloader : IFileDownloader
    {
        public async Task Download(Uri url, string file)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Accept", "text/html");
                client.DownloadFileCompleted += (s, e) => Console.WriteLine("Download file completed.");
                await client.DownloadFileTaskAsync(url, file);
            }
        }
    }
}
