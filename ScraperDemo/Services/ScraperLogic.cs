using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ScraperDemo.Interfaces;
using ScraperDemo.Model;

namespace ScraperDemo.Services
{
    public class ScraperLogic : IScraperLogic
    {
        private readonly Regex wordRegex = new Regex(@"\b[\w']+\b");
        private readonly IHttpClientUtility httpClientUtility;

        public ScraperLogic(IHttpClientUtility clientUtility)
        {
            httpClientUtility = clientUtility;
        }

        public ScraperResults ScrapeUrl(string url)
        {
            var response = new ScraperResults();

            var rawPageContent = httpClientUtility.DownloadUrl(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(rawPageContent);

            // Parse out images
            var imageNodes = doc.DocumentNode.SelectNodes("//img");
            if (imageNodes != null)
            {
                var images = imageNodes.ToList();
                images.ForEach(node =>
                {
                    var src = node.GetAttributeValue("src", "default");
                    if (!src.Equals("default", StringComparison.OrdinalIgnoreCase))
                    {
                        if (src.StartsWith('/'))
                        {
                            src = $"{url}{src}";
                        }
                        response.Images.Add(src);
                    }

                });
            }

            // Parse out words
            var wordNodes = doc.DocumentNode.SelectNodes("//body//text()").Select(x =>
            {
                return x.InnerText;
            });
            if (wordNodes != null)
            {
                var wordList = wordNodes.ToList();
                var words = wordList;
                words.ForEach(domText =>
                {
                    var wordsSub = domText.Split(" ").ToList();
                    wordsSub.ForEach(word =>
                    {
                        if (IsWord(word))
                        {
                            response.Words.Add(word.ToString());
                        }
                    });
                });
            }


            return response;
        }

        private bool IsWord(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var match = wordRegex.Match(text);
            return match.Value.Equals(text);
        }
    }
}
