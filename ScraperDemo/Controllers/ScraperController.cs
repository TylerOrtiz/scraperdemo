using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ScraperDemo.Model;
using ScraperDemo.Interfaces;

namespace ScraperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        private readonly IScraperLogic scraperLogic;

        public ScraperController(IScraperLogic logic)
        {
            scraperLogic = logic;
        }

        [HttpPost]
        [Route("LoadUrl")]
        public ActionResult<ScraperResponse> LoadUrl(ScraperRequest request)
        {
            var scraperResults = scraperLogic.ScrapeUrl(request.Url);
            var response = new ScraperResponse
            {
                FetchedUrl = $"{request.Url}",
                TotalWords = 100
            };
            response.Images.AddRange(scraperResults.Images);
            scraperResults.Words.ForEach(e => {
                response.Words.Add(new ScraperResponse.KeyCount() { Key = e, Count = 0});
            });
           
            response.Images.Add("http://somewhere.com/image.png");
            response.Images.Add("http://somewhereelse.com/image.png");
            response.Words.Add(new ScraperResponse.KeyCount() { Key = "This", Count = 10 });
            response.Words.Add(new ScraperResponse.KeyCount() { Key = "That", Count = 5 });

            return response;
        }
    }
}
