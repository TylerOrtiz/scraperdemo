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
                FetchedUrl = $"{request.Url}"
            };
            response.Images.AddRange(scraperResults.Images);
            var uniqueWords = new Dictionary<string, uint>();
            scraperResults.Words.ForEach(e => {
                if(uniqueWords.ContainsKey(e))
                {
                    uniqueWords[e] += 1;
                } else
                {
                    uniqueWords.Add(e, 1);
                }
                
            });

            var uniqueWordsList = uniqueWords.ToList();
            uniqueWordsList.ForEach(item => {
                response.Words.Add(new ScraperResponse.KeyCount() { Key = item.Key, Count = item.Value });
            });
            response.TotalWords = (uint)uniqueWordsList.Count;

            return response;
        }
    }
}
