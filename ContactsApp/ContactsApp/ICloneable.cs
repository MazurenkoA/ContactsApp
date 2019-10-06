using System;

namespace ContactsApp
{
    /// <summary>
    ///     Interface.
    /// </summary>
    public interface ICloneable
    {
        #region Properties

        /// <summary>
        ///     Contact's surname.
        /// </summary>
        string Surname { get; set; }

        /// <summary>
        ///     Contact's name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Contact's birthday.
        /// </summary>
        DateTime BirthDay { get; set; }

        /// <summary>
        ///     Contact's email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        ///     Contact's ID in VK.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Contact's phone number.
        /// </summary>
        PhoneNumber Phone { get; set; }

        #endregion
    }
}