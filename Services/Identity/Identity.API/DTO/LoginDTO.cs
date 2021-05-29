using System.ComponentModel.DataAnnotations;

namespace Identity.DTO
{
    public class LoginDTO
    {
        /// <summary>
        ///     User email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        ///     User password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}