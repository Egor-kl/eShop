using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.DTO;

namespace Identity.Common.Interfaces
{
    /// <summary>
    ///     Interface for service to manage user.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     User login.
        /// </summary>
        /// <param name="loginDTO">User login data.</param>
        /// <returns>Application Token.</returns>
        Task<TokenDTO> LoginAsync(LoginDTO loginDTO);

        /// <summary>
        ///     User registration.
        /// </summary>
        /// <param name="userDTO">User data.</param>
        /// <returns>Operation result.</returns>
        Task<(int id, bool result, string message)> RegisterAsync(UserDTO userDTO);

        /// <summary>
        ///     Get user by email address.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <returns>UserDTO.</returns>
        Task<UserDTO> GetUserByEmailAsync(string email);

        /// <summary>
        ///     Get user by user Id.
        /// </summary>
        /// <param name="userId">User Identifier.</param>
        /// <returns>UserDTO.</returns>
        Task<UserDTO> GetUserByIdAsync(int userId);

        /// <summary>
        ///     Get user by username.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>UserDTO.</returns>
        Task<UserDTO> GetUserByUsernameAsync(string username);

        /// <summary>
        ///     Get all user.
        /// </summary>
        /// <returns>Collection of user DTO.</returns>
        Task<ICollection<UserDTO>> GetAllUsersAsync();

        /// <summary>
        ///     Update user account.
        /// </summary>
        /// <param name="userDTO">User account DTO.</param>
        /// <returns>Operation result.</returns>
        Task<bool> UpdateUserAsync(UserDTO userDTO);

        /// <summary>
        ///     Delete user account.
        /// </summary>
        /// <param name="userId">Account identifier.</param>
        /// <returns>Operation result.</returns>
        Task<bool> DeleteUserByIdAsync(int userId);
    }
}