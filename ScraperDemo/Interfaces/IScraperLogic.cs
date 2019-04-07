using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ScraperDemo.Model;

namespace ScraperDemo.Interfaces
{
    public interface IScraperLogic
    {
        ScraperResults ScrapeUrl(string url);
    }

    
}
