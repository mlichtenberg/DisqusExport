using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.listForums
{
    public class Response
    {
        public object category { get; set; }
        public object description { get; set; }
        public string founder { get; set; }
        public object twitterName { get; set; }
        public string url { get; set; }
        public object raw_description { get; set; }
        public object guidelines { get; set; }
        public Favicon favicon { get; set; }
        public object raw_guidelines { get; set; }
        public string language { get; set; }
        public int daysThreadAlive { get; set; }
        public Avatar avatar { get; set; }
        public object channel { get; set; }
        public int daysAlive { get; set; }
        public string pk { get; set; }
        public string signedUrl { get; set; }
        public Settings settings { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
    }

}
