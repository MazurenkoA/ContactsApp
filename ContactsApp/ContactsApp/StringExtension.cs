namespace ContactsApp
{
    /// <summary>
    /// Extension for class <see cref="string" />.
    /// </summary>
    public static class StringExtension
    {
        #region Public methods

        /// <summary>
        /// Method that removes spaces at the beginning and end of a string and returns a lowercase string.
        /// </summary>
        /// <param name="str">The string to be formatted.</param>
        /// <returns>Returns the processed string.</returns>
        public static string TrimAndLower(this string str)
        {
            str = str.Trim().ToLower();
            return str;
        }

        #endregion
    }
}