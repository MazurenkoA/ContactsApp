using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    /// <summary>
    /// Control for viewing and editing notes.
    /// </summary>
    public partial class ContactControl : UserControl
    {
        #region Private fields

        /// <summary>
        /// Current contact's data.
        /// </summary>
        private Contact _currentContact;

        /// <summary>
        /// The correctness of the entered contact's data.
        /// </summary>
        private bool _isCorrectContact = true;

        /// <summary>
        /// Contact's phone number.
        /// </summary>  
        private long _number = 0;

        #endregion

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
                ToolTip.Active = !value;
            }
        }

        /// <summary>
        /// Gets or sets the correctness of the entered contact's data.
        /// </summary>
        public bool IsCorrectContact
        {
            get
            {
                UpdateContact();
                return _isCorrectContact;
            }
            private set => _isCorrectContact = value;
        }

        /// <summary>
        /// Gets or sets current contact's data.
        /// </summary>
        public Contact CurrentContact
        {
            get
            {
                UpdateContact();
                return _currentContact;
            }
            set
            {
                if (value != null)
                {
                    SurnameTextBox.Text = value.Surname;
                    NameTextBox.Text = value.Name;
                    BirthdayDateTime.Value = value.BirthDay;
                    PhoneMaskedTextBox.Text =
                        Convert.ToString(value.Phone.Number).Remove(0, 1);

                    EmailTextBox.Text = value.Email;
                    IdTextBox.Text = value.Id;
                    IsCorrectContact = true;
                    _currentContact = value;
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public ContactControl()
        {
            InitializeComponent();
            BirthdayDateTime.MaxDate = DateTime.Now;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Updating data from a text field to the contact.
        /// </summary>
        private void UpdateContact()
        {
            if (!string.IsNullOrWhiteSpace(SurnameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(PhoneMaskedTextBox.Text) &&
                !string.IsNullOrWhiteSpace(IdTextBox.Text) && _number != 0)
            {
                _currentContact.Surname = SurnameTextBox.Text;
                _currentContact.Name = NameTextBox.Text;
                _currentContact.BirthDay = BirthdayDateTime.Value;
                _currentContact.Phone.Number = _number;
                _currentContact.Email = EmailTextBox.Text;
                _currentContact.Id = IdTextBox.Text;

                IsCorrectContact = true;
            }
            else
            {
                IsCorrectContact = false;
            }
        }

        /// <summary>
        /// Event that occurs when you press keys in the text field 'Surname'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == (char) Keys.Back ||
                char.ToLower(e.KeyChar) >= 'а' && char.ToLower(e.KeyChar) <= 'я')
            {
                if (SurnameTextBox.Text.Length == 0 || SurnameTextBox.Text.EndsWith("-"))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else
                {
                    e.KeyChar = char.ToLower(e.KeyChar);
                }
            }
            else
            {
                e.Handled = true;
            }
        }


        /// <summary>
        /// Event that occurs when you press keys in the text field 'Name'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Back || char.ToLower(e.KeyChar) >= 'а' &&
                char.ToLower(e.KeyChar) <= 'я')
            {
                e.KeyChar = NameTextBox.Text.Length == 0
                    ? char.ToUpper(e.KeyChar)
                    : char.ToLower(e.KeyChar);
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Event that occurs when the 'Phone field is left.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void PhoneMaskedTextBox_Leave(object sender, EventArgs e)
        {
            if (!PhoneMaskedTextBox.ReadOnly)
            {
                var phone = PhoneMaskedTextBox.Text.Replace("(", "").Replace(")", "")
                    .Replace("-", "").Replace("+", "").Replace(" ", "");

                if (phone.Length == 11)
                {
                    var result = long.TryParse(phone, out var number);
                    if (result)
                    {
                        PhoneMaskedTextBox.BackColor = Color.White;
                        _number = number;
                    }
                    else
                    {
                        MessageBox.Show(
                            @"Error entering phone number. The value entered is: " +
                            PhoneMaskedTextBox.Text);
                    }
                }
                else
                {
                    PhoneMaskedTextBox.BackColor = Color.Red;
                    IsCorrectContact = false;
                }
            }
        }

        /// <summary>
        /// Event that occurs when you press keys in the text field 'Email'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Back || e.KeyChar == '_' || e.KeyChar == '-' ||
                e.KeyChar == '@' || e.KeyChar == '.' ||
                char.ToLower(e.KeyChar) >= 'a' && char.ToLower(e.KeyChar) <= 'z' ||
                e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.KeyChar = char.ToLower(e.KeyChar);
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Event that occurs when the 'Email' field is left.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            if (!EmailTextBox.ReadOnly)
            {
                var pattern =
                    "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                if (!Regex.IsMatch(EmailTextBox.Text, pattern, RegexOptions.IgnoreCase))
                {
                    EmailTextBox.BackColor = Color.Red;
                    IsCorrectContact = false;
                }
                else
                {
                    EmailTextBox.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// Event that occurs when you press keys in the text field 'Id'.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void IdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '_' || e.KeyChar == (char) Keys.Back ||
                char.ToLower(e.KeyChar) >= 'a' && char.ToLower(e.KeyChar) <= 'z' ||
                e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.KeyChar = char.ToLower(e.KeyChar);
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Event that occurs when a anything field is left.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">An argument that stores event information.</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (!((TextBox) sender).ReadOnly)
            {
                if (((TextBox) sender).Text == "")
                {
                    ((TextBox) sender).BackColor = Color.Red;
                    IsCorrectContact = false;
                }
                else
                {
                    ((TextBox) sender).BackColor = Color.White;
                }
            }
        }

        #endregion
    }
}