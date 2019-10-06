using System;

namespace ContactsApp
{
    /// <summary>
    ///     Contact's phone number
    /// </summary>
    public class PhoneNumber
    {
        #region Private fields

        /// <summary>
        ///     Phone number
        /// </summary>
        private long _number;

        #endregion
        
        #region Properties

        /// <summary>
        ///     Phone number
        /// </summary>
        public long Number
        {
            get => _number;
            set
            {
                if (!Validation.IsPhoneNumber(value))
                {
                    throw new ArgumentException(
                        "The phone number entered is incorrect. The value of the entered number: " +
                        value);
                }

                _number = value;
            }
        }

        #endregion
    }
}