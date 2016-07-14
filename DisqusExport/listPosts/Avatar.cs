using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.listPosts
{
    public class Avatar
    {
        public Small small { get; set; }
        public bool isCustom { get; set; }
        public string permalink { get; set; }
        public string cache { get; set; }
        public Large large { get; set; }
    }
}
