using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Profile.API.Common.Interfaces;
using Profile.API.DTO;
using Serilog;

namespace Profile.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IProfileContext _context;

        /// <summary>
        /// Constructor of profile service.
        /// </summary>
        /// <param name="profileContext">Profile context.</param>
        /// <param name="mapper">Automapper.</param>
        /// <param name="logger">Logging service.</param>
        public ProfileService(IMapper mapper, ILogger logger, IProfileContext profileContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = profileContext ?? throw new ArgumentNullException(nameof(profileContext));
        }
        
        /// <inheritdoc/>
        public async Task<(int id, bool success)> RegisterNewProfileAsync(ProfileDTO profileDTO)
        {
            var profile = _mapper.Map<ProfileDTO, Models.Profile>(profileDTO);
            var profileFound = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == profileDTO.Id);

            if (profileDTO.Avatars != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(profileDTO.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int) profileDTO.Avatar.Length);
                }
                profile.Avatars = imageData;
            }
            
            if (profileFound != null)
            {
                _logger.Error("Profile already exist");
                return (-1, false);
            }

            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync(new CancellationToken());

            var id = profile.Id;

            return (id, true);
        }

        /// <inheritdoc/>
        public async Task<ProfileDTO> GetProfileByIdAsync(int id)
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == id);
            
            if(profile == null)
            {
                return null;
            }

            var profileDTO = _mapper.Map<Models.Profile, ProfileDTO>(profile);

            return profileDTO;
        }

        /// <inheritdoc/>
        public async Task<ProfileDTO> GetProfileByUserIdAsync(int userId)
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.UserId == userId);
            
            if(profile == null)
            {
                return null;
            }

            var profileDTO = _mapper.Map<Models.Profile, ProfileDTO>(profile);

            return profileDTO;
        }

        /// <inheritdoc/>
        public async Task<ICollection<ProfileDTO>> GetAllProfilesAsync()
        {
            var profileList = await _context.Profiles.ToListAsync();
            var exceptedList = _mapper.Map<ICollection<Models.Profile>, ICollection<ProfileDTO>>(profileList);

            return exceptedList;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateProfileAsync(ProfileDTO profileDTO)
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == profileDTO.Id);

            if (profile == null)
            {
                return false;
            }

            profile.FirstName = profileDTO.FirstName;
            profile.LastName = profileDTO.LastName;
            profile.BirthDate = profileDTO.BirthDate;
            profile.Phone = profileDTO.Phone;
            profile.Avatars = profileDTO.Avatars;

            _context.Update(profile);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteProfileByIdAsync(int id)
        {
            var profileFound = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == id);
            if (profileFound == null)
            {
                _logger.Error("Profile not found");
                return false;
            }

            _context.Remove(profileFound);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteProfileByUserIdAsync(int userId)
        {
            var profileFound = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            if (profileFound == null)
            {
                _logger.Error("Profile not found");
                return false;
            }

            _context.Remove(profileFound);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }
    }
}