﻿using System;

namespace Profile.API.DTO
{
    public class ProfileDTO
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        public int Id { get; set; }
        
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
        /// User mobile phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// User avatar.
        /// </summary>
        public byte[] Avatars { get; set; }
    }
}