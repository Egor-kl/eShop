using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Profile.API.DTO;

namespace Profile.API.Common.Interfaces
{
    public interface IProfileService
    {
        /// <summary>
        /// Register new profile.
        /// </summary>
        /// <param name="profileDTO">Profile model.</param>
        /// <returns>Profile Id and operation status.</returns>
        Task<(int id, bool success)> RegisterNewProfileAsync(ProfileDTO profileDTO);

        /// <summary>
        /// Get profile by identifier.
        /// </summary>
        /// <param name="id">Profile identifier.</param>
        /// <returns>Profile object.</returns>
        Task<ProfileDTO> GetProfileByIdAsync(int id);


        /// <summary>
        /// Get profile by account identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Profile object.</returns>
        Task<ProfileDTO> GetProfileByUserIdAsync(int userId);

        /// <summary>
        /// Get all registered profiles.
        /// </summary>
        /// <returns>Profiles collection.</returns>
        Task<ICollection<ProfileDTO>> GetAllProfilesAsync();

        /// <summary>
        /// Update profile information.
        /// </summary>
        /// <param name="profileDTO">Profile object.</param>
        /// <returns>Operation status.</returns>
        Task<bool> UpdateProfileAsync(ProfileDTO profileDTO);

        /// <summary>
        /// Delete profile from application.
        /// </summary>
        /// <param name="id">Profile identifier.</param>
        /// <returns>Operation status.</returns>
        Task<bool> DeleteProfileByIdAsync(int id);

        /// <summary>
        /// Delete profile from application by account id.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Operation status.</returns>
        Task<bool> DeleteProfileByUserIdAsync(int userId);
    }
}