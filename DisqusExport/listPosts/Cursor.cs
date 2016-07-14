using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.listPosts
{
    public class Cursor
    {
        public object prev { get; set; }
        public bool hasNext { get; set; }
        public string next { get; set; }
        public bool hasPrev { get; set; }
        public object total { get; set; }
        public string id { get; set; }
        public bool more { get; set; }
    }
}
