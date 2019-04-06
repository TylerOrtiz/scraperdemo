using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ScraperDemo.Interfaces;

namespace ScraperDemo.Services
{
    public class ScraperLogic : IScraperLogic
    {
        private readonly IHttpClientUtility httpClientUtility;

        public ScraperLogic(IHttpClientUtility clientUtility)
        {
            httpClientUtility = clientUtility;
        }

        public string ScrapeUrl(string url)
        {
            return httpClientUtility.DownloadUrl(url);
        }
    }
}
