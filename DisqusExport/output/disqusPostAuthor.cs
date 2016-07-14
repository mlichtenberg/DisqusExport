using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.output
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class disqusPostAuthor
    {
        private object idField;

        private string emailField;

        private string nameField;

        private bool isAnonymousField;

        private string usernameField;

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

        /// <remarks/>
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public bool isAnonymous
        {
            get
            {
                return this.isAnonymousField;
            }
            set
            {
                this.isAnonymousField = value;
            }
        }

        /// <remarks/>
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }
    }
}
