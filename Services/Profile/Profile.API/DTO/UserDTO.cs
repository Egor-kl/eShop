using EventBus.DTO;

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
        
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}