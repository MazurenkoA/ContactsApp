using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContactsApp
{
    /// <summary>
    /// Contact's personal data.
    /// </summary>
    public class Contact : ICloneable
    {
        #region Private fields

        /// <summary>
        /// Contact's birthday.
        /// </summary>
        private DateTime _birthday = DateTime.Today;

        /// <summary>
        /// Contact's email.
        /// </summary>
        private string _email;

        /// <summary>
        /// Contact's ID in VK.
        /// </summary>
        private string _id;

        /// <summary>
        /// Contact's name.
        /// </summary>
        private string _name;

        /// <summary>
        /// Contact's phone number.
        /// </summary>
        private PhoneNumber _phone = new PhoneNumber();

        /// <summary>
        /// Contact's surname.
        /// </summary>
        private string _surname;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets contact's email.
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                value = value.TrimAndLower();
                uint maxNumberSymbols = 50;
                var pattern =
                    "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                Validator.AssertNullOrWhiteSpace(value, "Email");
                Validator.AssertLengthString(value,"Email", maxNumberSymbols);
                
                if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException(
                        "Contact's email entered is incorrect. The value of the entered string: " +
                        value);
                }

                _email = value;
            }
        }

        /// <summary>
        /// Gets or sets contact's surname.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                uint maxNumberSymbols = 50;
                value = value.TrimAndLower();

                Validator.AssertNullOrWhiteSpace(value, "Surname");
                Validator.AssertLengthString(value, "Surname", maxNumberSymbols);

                if (!value.All(symbol =>
                        Validator.IsRussianLetter(symbol) ||
                        Validator.IsHyphen(symbol)) &&
                    value.Count(Validator.IsHyphen) <= 1)
                {
                    throw new ArgumentException(
                        "Contact's surname contains invalid symbols. The value of the entered string: " +
                        value);
                }

                if (Validator.IsHyphen(value.First()) || Validator.IsHyphen(value.Last()))
                {
                    throw new ArgumentException(
                        "The beginning or end of the surname contains a hyphen. The value of the entered string: " +
                        value);
                }


                if (value.Contains("-"))
                {
                    var index = value.IndexOf('-') + 1;
                    var subString = value.Substring(index, 1).ToUpper();
                    subString = subString + value.Remove(0, index + 1);
                    value = value.Remove(index) + subString;
                }

                value = value.Substring(0, 1).ToUpper() + value.Remove(0, 1);
                _surname = value;
            }
        }

        /// <summary>
        /// Gets or sets contact's name.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                uint maxNumberSymbols = 50;
                value = value.TrimAndLower();

                Validator.AssertNullOrWhiteSpace(value, "Name");
                Validator.AssertLengthString(value, "Name", maxNumberSymbols);

                if (!value.All(Validator.IsRussianLetter))
                {
                    throw new ArgumentException(
                        "Contact's name contains invalid symbols. The value of the entered string: " +
                        value);
                }

                value = value.Substring(0, 1).ToUpper() + value.Remove(0, 1);
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets contact's birthday.
        /// </summary>
        public DateTime BirthDay
        {
            get => _birthday;
            set
            {
                var minBirthDate = new DateTime(1900, 1, 1);
                var maxBirthDate = DateTime.Now;

                if (value < minBirthDate || value > maxBirthDate)
                {
                    throw new ArgumentException(
                        "Birthday must be between " + minBirthDate + " and " +
                        maxBirthDate + ", but was entered " + value);
                }

                _birthday = value;
            }
        }

        /// <summary>
        /// Gets or sets contact's ID in VK.
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                uint maxNumberSymbols = 15;
                uint maxNumberUnderscore = maxNumberSymbols - 1;
                value = value.TrimAndLower();

                Validator.AssertNullOrWhiteSpace(value, "ID in VK");
                Validator.AssertLengthString(value, "ID in VK", maxNumberSymbols);

                if (!(value.All(symbol =>
                          Validator.IsLatinLetter(symbol) ||
                          Validator.IsDigital(symbol) ||
                          Validator.IsUnderscore(symbol)) &&
                      value.Count(Validator.IsUnderscore) <= maxNumberUnderscore))
                {
                    throw new ArgumentException(
                        "The ID address entered is incorrect. The value of the entered string: " +
                        value);
                }

                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets contact's phone number.
        /// </summary>
        public PhoneNumber Phone
        {
            get => _phone;
            set
            {
                const long MinValueNumber = 79000000000;
                const long MaxValueNumber = 79999999999;

                if (value.Number < MinValueNumber || value.Number > MaxValueNumber)
                {
                    throw new ArgumentException(
                        "Phone number must be between " + MinValueNumber + " and " +
                        MaxValueNumber + ", but was entered " + value.Number);
                }

                _phone = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Creating a contact clone.
        /// </summary>
        /// <returns>Returns a contact with cloned data.</returns>
        public object Clone()
        {
            return new Contact
            {
                Name = Name,
                Surname = Surname,
                BirthDay = BirthDay,
                Email = Email,
                Id = Id,
                Phone = (PhoneNumber) Phone.Clone()
            };
        }

        #endregion
    }
}