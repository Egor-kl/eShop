using System.ComponentModel.DataAnnotations;

namespace EventBus.DTO
{
    public interface IUserDTO
    {
        /// <summary>
        /// Identifier.
        /// </summary>
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
    }
}