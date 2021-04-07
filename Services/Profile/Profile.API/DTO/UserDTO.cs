﻿using EventBus.DTO;

namespace Profile.API.DTO
{
    /// <summary>
    /// DTO for event producer
    /// </summary>
    public class UserDTO : IUserDTO
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Profile Id
        /// </summary>
        public int ProfileId { get; set; }
        
        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public string CreationDate { get; set; }
    }
}