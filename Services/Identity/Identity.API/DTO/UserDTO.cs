using System.ComponentModel.DataAnnotations;
using EventBus.DTO;

namespace Identity.DTO
{
    public class UserDTO : IUserDTO
    {
        /// <summary>
        ///     User password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        ///     User role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///     Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     User email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        ///     User username.
        /// </summary>
        [Required]
        public string UserName { get; set; }
    }
}