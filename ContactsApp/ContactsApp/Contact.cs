using System;

namespace ContactsApp
{
    /// <summary>
    ///     Contact's personal data.
    /// </summary>
    public class Contact : ICloneable
    {
        #region Private fields

        /// <summary>
        ///     Contact's birthday.
        /// </summary>
        private DateTime _birthday = DateTime.Now;

        /// <summary>
        ///     Contact's email.
        /// </summary>
        private string _email;

        /// <summary>
        ///     Contact's ID in VK.
        /// </summary>
        private string _id;

        /// <summary>
        ///     Contact's name.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Contact's phone number.
        /// </summary>
        private PhoneNumber _phone = new PhoneNumber();

        /// <summary>
        ///     Contact's surname.
        /// </summary>
        private string _surname;

        #endregion

        #region Properties

        /// <summary>
        ///     Contact`s email.
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                value = Validation.GetCorrectString(value);

                if (!Validation.IsEmail(value))
                {
                    throw new ArgumentException(
                        "Contact's Email entered is incorrect. The value of the entered string: " +
                        value);
                }

                _email = value;
            }
        }

        /// <summary>
        ///     Contact's surname.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                value = Validation.GetCorrectString(value);
                if (!Validation.IsSurname(value))
                {
                    throw new ArgumentException(
                        "Contact's surname entered is incorrect. The value of the entered string: " +
                        value);
                }

                if (value.Contains("-"))
                {
                    var index = value.IndexOf('-') + 1;
                    var subString = value.Substring(index, 1).ToUpper();
                    subString = subString + value.Remove(0, index + 1 );
                    value = value.Remove(index) + subString;
                }

                value = value.Substring(0, 1).ToUpper() + value.Remove(0, 1);
                _surname = value;
            }
        }

        /// <summary>
        ///     Contact's name.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                value = Validation.GetCorrectString(value);

                if (!Validation.IsName(value))
                {
                    throw new ArgumentException(
                        "Contact's name entered is incorrect. The value of the entered string: " +
                        value);
                }

                value = value.Substring(0, 1).ToUpper() + value.Remove(0, 1);
                _name = value;
            }
        }

        /// <summary>
        ///     Contact's birthday.
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
        ///     Contact`s ID in VK.
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                value = Validation.GetCorrectString(value);

                if (!Validation.IsId(value))
                {
                    throw new ArgumentException(
                        "The ID address entered is incorrect. The value of the entered string: " +
                        value);
                }

                _id = value;
            }
        }

        /// <summary>
        ///     Contact`s phone number.
        /// </summary>
        public PhoneNumber Phone
        {
            get => _phone;
            set
            {
                if (Validation.IsPhoneNumber(value.Number))
                {
                    _phone = value;
                }

                throw new ArgumentException(
                    "The phone number entered is incorrect. The value of the entered number: " +
                    value.Number);
            }
        }

        #endregion
    }
}