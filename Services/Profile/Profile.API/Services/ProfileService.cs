using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Profile.API.Common.Interfaces;
using Profile.API.DTO;
using Serilog;

namespace Profile.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor of profile service.
        /// </summary>
        /// <param name="profileContext">Profile context.</param>
        /// <param name="mapper">Automapper.</param>
        /// <param name="logger">Logging service.</param>
        /// <param name="userDeletedEventProducer">Producer of the "user deleted" events.</param>
        public ProfileService(IMapper mapper, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<(int id, bool success)> RegisterNewProfileAsync(ProfileDTO profileDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProfileDTO> GetProfileByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProfileDTO> GetProfileByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<ProfileDTO>> GetAllProfilesAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateProfileAsync(ProfileDTO profileDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteProfileByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteProfileByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}