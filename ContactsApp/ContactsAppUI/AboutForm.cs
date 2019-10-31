using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ContactsAppUI
{
    /// <summary>
    /// Form containing information about the application.
    /// </summary>
    public partial class AboutForm : Form
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Event that occurs when you click on a 'Git Hub' link.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void GitHubLinkLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MazurenkoA/ContactsApp");
        }

        /// <summary>
        /// Event that occurs when you click on a 'E-mail' link.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void EmailLinkLabel_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:walenotor@gmail.com");
        }

        #endregion
    }
}