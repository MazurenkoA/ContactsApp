﻿using System;

namespace ContactsApp
{
    /// <summary>
    /// Contact's phone number.
    /// </summary>
    public class PhoneNumber : ICloneable
    {
        #region Private fields

        /// <summary>
        /// Phone number.
        /// </summary>
        private long _number;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public long Number
        {
            get => _number;
            set
            {
                const long MinValueNumber = 79000000000;
                const long MaxValueNumber = 79999999999;

                if (value < MinValueNumber || value > MaxValueNumber)
                {
                    throw new ArgumentException(
                        "Phone number must be between " + MinValueNumber + " and " +
                        MaxValueNumber + ", but was entered " + value);
                }

                _number = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Creating a contact's phone number clone.
        /// </summary>
        /// <returns>Returns a contact's phone number  with cloned data.</returns>
        public object Clone()
        {
            return new PhoneNumber
                {Number = Number};
        }

        #endregion
    }
}