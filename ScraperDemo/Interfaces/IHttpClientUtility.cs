﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ScraperDemo.Interfaces
{
    public interface IHttpClientUtility
    {
        string DownloadUrl(string url);
    }
}
