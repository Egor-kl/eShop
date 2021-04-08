using System;
using EventBus.DTO;
using Microsoft.AspNetCore.Http;

namespace Profile.API.DTO
{
    public class ProfileDTO : IUserDTO
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }

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
        /// User id.
        /// </summary>
        public int UserId { get; set; }
    }
}