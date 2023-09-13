using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cronomefy.Models
{
    public class Cancion
    {
        public external_urls external_urls { get; set; }
        public followers followers { get; set; }
        public List<string> genres { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Images> images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class external_urls
    {
        public string spotify { get; set; }
    }

    public class followers
    {
        public string href { get; set; }
        public int total { get; set; }
    }

    public class Images
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }
}