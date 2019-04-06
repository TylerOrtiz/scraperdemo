using System.Collections.Generic;

namespace ScraperDemo.Model
{
    public class ScraperResponse
    {
        public ScraperResponse()
        {
            Images = new List<string>();
            Words = new List<KeyCount>();
        }

        public string FetchedUrl { get; set; }
        public List<string> Images { get; set; }
        public uint TotalWords { get; set; }
        public List<KeyCount> Words { get; set; }

        public class KeyCount
        {
            public string Key { get; set; }
            public uint Count { get; set; }
        }
    }
}
