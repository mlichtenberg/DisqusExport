using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.output
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class disqus
    {

        private disqusForum forumField;

        private disqusThread[] threadField;

        private disqusPost[] postField;

        /// <remarks/>
        public disqusForum forum
        {
            get
            {
                return this.forumField;
            }
            set
            {
                this.forumField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("thread")]
        public disqusThread[] thread
        {
            get
            {
                return this.threadField;
            }
            set
            {
                this.threadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("post")]
        public disqusPost[] post
        {
            get
            {
                return this.postField;
            }
            set
            {
                this.postField = value;
            }
        }
    }
}
