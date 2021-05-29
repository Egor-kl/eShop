using System;

namespace Profile.API.Models
{
    /// <summary>
    ///     Profile entity.
    /// </summary>
    public class Profile
    {
        /// <summary>
        ///     Profile identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     First name user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Last name user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Date of birthday user.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        ///     User mobile phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     User discount.
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        ///     Creation date.
        /// </summary>
        public string CreationDate { get; set; }

        /// <summary>
        ///     User id.
        /// </summary>
        public int UserId { get; set; }
    }
}