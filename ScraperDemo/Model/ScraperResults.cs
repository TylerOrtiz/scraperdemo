using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScraperDemo.Model
{
    public class ScraperResults
    {
        public List<string> Images { get; set; }
        public List<string> Words { get; set; }

        public ScraperResults()
        {
            Images = new List<string>();
            Words = new List<string>();
        }
    }
}
