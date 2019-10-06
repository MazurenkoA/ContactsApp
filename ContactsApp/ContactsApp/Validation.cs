using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContactsApp
{
    /// <summary>
    ///     Validation of received values.
    /// </summary>
    public static class Validation
    {
        #region Private methods

        /// <summary>
        ///     Checking if a symbol is an underscore.
        /// </summary>
        /// <param name="symbol">The value of the symbol.</param>
        /// <returns>The value indicates whether the underscore symbol is.</returns>
        private static bool IsUnderscore(char symbol)
        {
            return symbol == '_';
        }

        /// <summary>
        ///     Checking if a symbol is a hyphen
        /// </summary>
        /// <param name="symbol">The value of the symbol.</param>
        /// <returns>The value indicates whether the hyphen symbol is.</returns>
        private static bool IsHyphen(char symbol)
        {
            return symbol == '-';
        }

        /// <summary>
        ///     Checking if the symbol is a Latin letter.
        /// </summary>
        /// <param name="symbol">The value of the symbol.</param>
        /// <returns>The value indicates whether the symbol is a Latin letter.</returns>
        private static bool IsLatinLetter(char symbol)
        {
            return symbol >= 'a' && symbol <= 'z';
        }

        /// <summary>
        ///     Checking whether the symbol is a digit.
        /// </summary>
        /// <param name="symbol">The value of the symbol.</param>
        /// <returns>The value indicates whether the symbol is a digit.</returns>
        private static bool IsDigital(char symbol)
        {
            return char.IsDigit(symbol);
        }

        /// <summary>
        ///     Checking if the symbol is a Russian letter.
        /// </summary>
        /// <param name="symbol">The value of the symbol.</param>
        /// <returns>The value indicates whether the symbol is a Russian letter.</returns>
        private static bool IsRussianLetter(char symbol)
        {
            return (symbol >= 'а' && symbol <= 'я');
        }

        /// <summary>
        ///     Checking string for null or white space.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="name">Name of the entered string.</param>
        private static void CheckNullOrWhiteSpace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Contact's " + name +
                    " can't be empty! Current value " + name + " is " + value);
            }
        }

        /// <summary>
        ///     Validation the number of symbols in the entered string.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="name">Name of the entered string.</param>
        /// <param name="maxNumberSymbols">Maximum number of symbols per line.</param>
        private static void CheckLengthString(string value, string name,
            uint maxNumberSymbols)
        {
            if (value.Length > maxNumberSymbols)
            {
                throw new ArgumentException(
                    "Contact's " + name + " length should be no more than " +
                    maxNumberSymbols +
                    " symbols ! Current " + name + " length is " +
                    value.Length);
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Validation the entered ID.
        /// </summary>
        /// <param name="id">
        ///     The value of ID. The string must contain only Latin letters, numbers, the sign "_" and have a length
        ///     of not more than 15 symbols.
        /// </param>
        /// <returns>The value indicates whether all symbols in the string match the specified condition.</returns>
        public static bool IsId(string id)
        {
            uint maxNumberSymbols = 15;
            uint maxNumberUnderscore = maxNumberSymbols - 1;
            CheckNullOrWhiteSpace(id, "ID in VK");
            CheckLengthString(id, "ID in VK", maxNumberSymbols);

            if (id.All(symbol => IsLatinLetter(symbol) || IsDigital(symbol) || IsUnderscore(symbol)) &&
                id.Count(IsUnderscore) <= maxNumberUnderscore)
            {
                return true;
            }

            throw new ArgumentException(
                "The ID address entered is incorrect. The value of the entered string: " +
                id);
        }

        /// <summary>
        ///     Validation the entered contact's name.
        /// </summary>
        /// <param name="name">The value of the name entered. The name should contain only symbols of the Russian alphabet.</param>
        /// <returns>The value indicates whether all symbols in the name string match the specified condition.</returns>
        public static bool IsName(string name)
        {
            uint maxNumberSymbols = 50;

            CheckNullOrWhiteSpace(name, "Name");
            CheckLengthString(name, "Name", maxNumberSymbols);
            if (!name.All(IsRussianLetter))
            {
                throw new ArgumentException(
                    "Contact's name contains invalid symbols. The value of the entered string: " +
                    name);
            }

            return true;
        }

        /// <summary>
        ///     Validation the entered contact's surname.
        /// </summary>
        /// <param name="surname">
        ///     The value of the surname entered. The surname should contain only symbols of the Russian alphabet
        ///     and hyphen.
        /// </param>
        /// <returns>The value indicates whether all symbols in the surname string match the specified condition.</returns>
        public static bool IsSurname(string surname)
        {
            uint maxNumberSymbols = 50;

            CheckNullOrWhiteSpace(surname, "Surname");
            CheckLengthString(surname, "Surname", maxNumberSymbols);
            if (!surname.All(symbol =>
                IsRussianLetter(symbol) || IsHyphen(symbol)) && surname.Count(IsHyphen) <= 1)
            {
                throw new ArgumentException(
                    "Contact's surname contains invalid symbols. The value of the entered string: " +
                    surname);
            }

            if (IsHyphen(surname.First()) || IsHyphen(surname.Last()))
            {
                throw new ArgumentException(
                    "The beginning or end of the last name contains a hyphen. The value of the entered string: " +
                    surname);
            }

            return true;
        }

        /// <summary>
        ///     Validation the entered contact's Email.
        /// </summary>
        /// <param name="email">The value of the Email entered.</param>
        /// <returns>The value indicates whether the check passed by email or not.</returns>
        public static bool IsEmail(string email)
        {

            var pattern =
                "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email address must not be empty!");
            }

            if (email.Length > 50)
            {
                throw new ArgumentException(
                    "Email address must not exceed 50 symbols !");
            }

            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException(
                    "Contact's surname entered is incorrect. The value of the entered string: " +
                    email);
            }

            return true;
        }

        /// <summary>
        ///     Method that removes spaces at the beginning and end of a string and returns a lowercase string.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns>Formatted string.</returns>
        public static string GetCorrectString(string value)
        {
            value = value.Trim();
            value = value.ToLower();
            return value;
        }


        /// <summary>
        ///     Validation the entered contact's phone number.
        /// </summary>
        /// <param name="number">Phone number. The phone number must be within the allowed number range.</param>
        /// <returns>The value indicates whether the entered phone number value is within the specified range.</returns>
        public static bool IsPhoneNumber(long number)
        {
            const long MinValueNumber = 79000000000;
            const long MaxValueNumber = 79999999999;

            if (number < MinValueNumber || number > MaxValueNumber)
            {
                throw new ArgumentException(
                    "Phone number must be between " + MinValueNumber + " and " +
                    MaxValueNumber + ", but was entered " + number);
            }

            return true;
        }

        #endregion
    }
}