using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.output
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class disqusThread
    {

        private string idField;

        private string forumField;

        private disqusThreadCategory categoryField;

        private string identifierField;

        private string linkField;

        private string feedField;

        private string titleField;

        private string slugField;

        private object messageField;

        private System.DateTime createdAtField;

        private disqusThreadAuthor authorField;

        private string ipAddressField;

        private bool isClosedField;

        private bool isDeletedField;

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string forum
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
        public disqusThreadCategory category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks />
        public string identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <remarks/>
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public string feed
        {
            get
            {
                return this.feedField;
            }
            set
            {
                this.feedField = value;
            }
        }

        /// <remarks/>
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string slug
        {
            get
            {
                return this.slugField;
            }
            set
            {
                this.slugField = value;
            }
        }

        /// <remarks/>
        public object message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public System.DateTime createdAt
        {
            get
            {
                return this.createdAtField;
            }
            set
            {
                this.createdAtField = value;
            }
        }

        /// <remarks/>
        public disqusThreadAuthor author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <remarks/>
        public string ipAddress
        {
            get
            {
                return this.ipAddressField;
            }
            set
            {
                this.ipAddressField = value;
            }
        }

        /// <remarks/>
        public bool isClosed
        {
            get
            {
                return this.isClosedField;
            }
            set
            {
                this.isClosedField = value;
            }
        }

        /// <remarks/>
        public bool isDeleted
        {
            get
            {
                return this.isDeletedField;
            }
            set
            {
                this.isDeletedField = value;
            }
        }
    }
}
