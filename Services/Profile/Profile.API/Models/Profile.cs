using System;
using System.Collections.Generic;

namespace Profile.API.Models
{
    /// <summary>
    /// Profile entity.
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// First name user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Date of birthday user.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// User avatar.
        /// </summary>
        public byte[] Avatars { get; set; }

        /// <summary>
        /// User discount.
        /// </summary>
        public double Discount { get; set; }
        
        /// <summary>
        /// User purchases.
        /// </summary>
        public List<string> Purchases { get; set; }
    }
}