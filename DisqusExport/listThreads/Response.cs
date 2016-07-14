using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.listThreads
{
    public class Response
    {
        public string feed { get; set; }
        public string[] identifiers { get; set; }
        public int dislikes { get; set; }
        public int likes { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string category { get; set; }
        public string author { get; set; }
        public int userScore { get; set; }
        public bool isSpam { get; set; }
        public string signedLink { get; set; }
        public bool isDeleted { get; set; }
        public string raw_message { get; set; }
        public bool isClosed { get; set; }
        public string link { get; set; }
        public string slug { get; set; }
        public string forum { get; set; }
        public string clean_title { get; set; }
        public int posts { get; set; }
        public bool userSubscription { get; set; }
        public string title { get; set; }
        public string ipAddress { get; set; }
        public object highlightedPost { get; set; }
    }
}
