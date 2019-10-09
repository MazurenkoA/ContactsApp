using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    /// Contains a list of all contacts created in the application
    /// </summary>
    public class Project
    {
        #region Private fields

        /// <summary>
        /// List of all contacts.
        /// </summary>
        private List<Contact> _contacts;

        #endregion

        #region Properties

        /// <summary>
        /// List of all contacts.
        /// </summary>
        public List<Contact> Contacts
        {
            get => _contacts;
            set => _contacts = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public Project()
        {
            Contacts = new List<Contact>();
        }

        #endregion
    }
}