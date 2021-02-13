using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profile.API.Common.Interfaces;
using Profile.API.DTO;
using Serilog;

namespace Profile.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor of profiles controller.
        /// </summary>
        /// <param name="profileService">Service to manage profiles.</param>
        /// <param name="logger">Logging service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProfileController(IProfileService profileService, ILogger logger)
        {
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        /// <summary>
        /// Register new profile
        /// </summary>
        /// <param name="profileDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Admin, User")]
        public async Task<IActionResult> RegisterNewProfile([FromBody] ProfileDTO profileDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (id, success) = await _profileService.RegisterNewProfileAsync(profileDTO);
            if (!success)
            {
                _logger.Warning($"{id} conflict with register");
                return Conflict(new { Message = "Profile already exist" });
            }

            profileDTO.Id = id;

            _logger.Information($"{profileDTO.Id} add profile success");
            return CreatedAtAction(nameof(RegisterNewProfile), profileDTO);
        }

        /// <summary>
        /// Update profile
        /// </summary>
        /// <param name="profileDTO"></param>
        /// <returns></returns>
        [Authorize("Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileDTO profileDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profileById = _profileService.GetProfileByIdAsync(profileDTO.Id);
            if (profileById is null)
            {
                _logger.Warning($"{profileDTO.Id} profile not found!");
                return NotFound(profileDTO.Id);
            }

            var success = await _profileService.UpdateProfileAsync(profileDTO);
            if (!success)
            {
                _logger.Warning($"{profileDTO.Id} Conflict with update");
                return Conflict(new {Message = "Conflict with update"});
            }
            
            _logger.Information($"{profileDTO.Id} update profile success");
            return Ok(profileDTO);
        }
        
        /// <summary>
        /// Get all profiles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Admin")]
        public async Task<ICollection<ProfileDTO>> GetProfiles()
        {
            var profiles = await _profileService.GetAllProfilesAsync();
            var count = profiles.Count;

            _logger.Information($"{count} Get profiles");

            return profiles;
        }
    }
}