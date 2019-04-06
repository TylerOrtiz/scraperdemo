using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ScraperDemo.Interfaces;

namespace ScraperDemo.Repository
{
    public class HttpClientUtility : IHttpClientUtility
    {
        public string DownloadUrl(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }
    }
}
