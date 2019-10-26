using System;
using System.Windows.Forms;

namespace ContactsAppUI
{
    /// <summary>
    /// Form for editing and adding notes.
    /// </summary>
    public partial class SecondaryForm : Form
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SecondaryForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Action when pressing the 'OK' button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Action when pressing the ' Cancel ' button
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}