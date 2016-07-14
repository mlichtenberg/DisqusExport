using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.listThreads
{
    public class Rootobject
    {
        public Cursor cursor { get; set; }
        public int code { get; set; }
        public Response[] response { get; set; }
    }
}
