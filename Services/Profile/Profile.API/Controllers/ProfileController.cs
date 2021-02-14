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

        /// <summary>
        /// Get profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize("User, Admin")]
        public async Task<IActionResult> GetProfileById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var profile = await _profileService.GetProfileByIdAsync(id);
            
            if (profile == null)
            {
                _logger.Warning($"{id} profile not found");
                return NoContent();
            }
            
            _logger.Information($"{id} get profile by id success");
            return Ok(profile);
        }

        /// <summary>
        /// Get profile by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("/GetByuserId")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetProfileByUserId(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var profile = await _profileService.GetProfileByUserIdAsync(userId);
            if (profile is null)
            {
                _logger.Warning($"{userId} profile not found");
                return NoContent();
            }
            
            _logger.Information($"{userId} get profile by user id success");
            return Ok(profile);
        }

        /// <summary>
        /// Delete profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteProfileById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _profileService.DeleteProfileByIdAsync(id);
            if (!success)
            {
                _logger.Warning($"{id} profile not found");
                return NotFound(id);
            }

            _logger.Information($"{id} delete profile success");
            return Ok(id);
        }
    }
}