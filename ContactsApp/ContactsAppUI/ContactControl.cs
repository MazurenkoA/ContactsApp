using System.Windows.Forms;

namespace ContactsAppUI
{
    /// <summary>
    /// Control for viewing and editing notes.
    /// </summary>
    public partial class ContactControl : UserControl
    {
        #region Properties

        /// <summary>
        /// Control mode.
        /// </summary>
        public bool ReadOnly
        {
            set
            {
                SurnameTextBox.ReadOnly = value;
                NameTextBox.ReadOnly = value;
                BirthdayDateTime.Enabled = !value;
                PhoneMaskedTextBox.ReadOnly = value;
                EmailTextBox.ReadOnly = value;
                IdTextBox.ReadOnly = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ContactControl()
        {
            InitializeComponent();
        }

        #endregion
    }
}