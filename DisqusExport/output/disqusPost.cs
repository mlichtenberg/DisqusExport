using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.output
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class disqusPost
    {

        private object idField;

        private long? parentField;

        private string messageField;

        private string raw_messageField;

        private System.DateTime createdAtField;

        private bool isDeletedField;

        private bool isSpamField;

        private disqusPostAuthor authorField;

        private string ipAddressField;

        private disqusPostThread threadField;

        private string linkField;

        /// <remarks/>
        public object id
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

        public long? parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }

        /// <remarks/>
        public string message
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
        public string raw_message
        {
            get
            {
                return this.raw_messageField;
            }
            set
            {
                this.raw_messageField = value;
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

        /// <remarks/>
        public bool isSpam
        {
            get
            {
                return this.isSpamField;
            }
            set
            {
                this.isSpamField = value;
            }
        }

        /// <remarks/>
        public disqusPostAuthor author
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
        public disqusPostThread thread
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
    }
}
