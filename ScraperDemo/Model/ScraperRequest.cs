using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScraperDemo.Model
{
    public class ScraperRequest
    {
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Url { get; set; }
    }
}
