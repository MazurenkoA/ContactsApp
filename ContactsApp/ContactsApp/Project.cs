using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Contains a list of all contacts created in the application
    /// </summary>
    public class Project
    {
        /// <summary>
        /// List of all contacts.
        /// </summary>
        private List<Contact> _contacts;

        /// <summary>
        /// Constructor.
        /// </summary>        
        public Project()
        {
            Contacts = new List<Contact>();
        }

        /// <summary>
        /// List of all contacts.
        /// </summary>
        public List<Contact> Contacts
        {
            get => _contacts;
            set => _contacts = value;
        }
        
    }
}
