using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.listPosts
{
    public class Response
    {
        public int points { get; set; }
        public string forum { get; set; }
        public long? parent { get; set; }
        public bool isApproved { get; set; }
        public Author author { get; set; }
        public object[] media { get; set; }
        public bool isDeleted { get; set; }
        public Approxloc approxLoc { get; set; }
        public bool isFlagged { get; set; }
        public int dislikes { get; set; }
        public string raw_message { get; set; }
        public DateTime createdAt { get; set; }
        public string id { get; set; }
        public string thread { get; set; }
        public int numReports { get; set; }
        public bool isDeletedByAuthor { get; set; }
        public int likes { get; set; }
        public bool isEdited { get; set; }
        public string message { get; set; }
        public bool isSpam { get; set; }
        public bool isHighlighted { get; set; }
        public int userScore { get; set; }
        public string ipAddress { get; set; }
    }
}
