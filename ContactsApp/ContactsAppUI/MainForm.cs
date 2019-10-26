using System;
using System.Windows.Forms;

namespace ContactsAppUI
{
    /// <summary>
    /// Main application form.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InfoContact.ReadOnly = true;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Opening the window "About".
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Opening the window "Add/Edit contact".
        /// </summary>
        private void OpenSecondaryForm()
        {
            var secondaryForm = new SecondaryForm();
            secondaryForm.ShowDialog();
        }

        /// <summary>
        /// Action when pressing the 'Add Contact' in the Menu.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void AddContactMenuItem_Click(object sender, EventArgs e)
        {
            OpenSecondaryForm();
        }

        /// <summary>
        /// Action when pressing the 'AddContact' button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void AddContactButton_Click(object sender, EventArgs e)
        {
            OpenSecondaryForm();
        }

        #endregion
    }
}