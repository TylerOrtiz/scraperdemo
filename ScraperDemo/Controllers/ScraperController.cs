using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ScraperDemo.Model;

namespace ScraperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ScraperResponseModel> Scrape(ScraperRequestModel scraperRequest)
        {
            var response = new ScraperResponseModel
            {
                FetchedUrl = $"Web scraper demo for: {scraperRequest.Url}"
            };
            return response;
        }
    }
}
