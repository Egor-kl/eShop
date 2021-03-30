using System.ComponentModel.DataAnnotations;

namespace Identity.DTO
{
    public class UserDTO
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User username.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// User role.
        /// </summary>
        public string Role { get; set; }
    }
}