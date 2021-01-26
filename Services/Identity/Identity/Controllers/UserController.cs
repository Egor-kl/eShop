using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Common.Interfaces;
using Identity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor of controller for user manage.
        /// </summary>
        /// <param name="userService">User management service.</param>
        /// <param name="logger">Logging service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(IUserService userService, ILogger logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewAccount(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (id, success, message) = await _userService.RegisterAsync(userDTO);
            if (!success)
            {
                _logger.Warning($"{userDTO.Email} account already exist");
                return Conflict(new { message });
            }

            _logger.Information($"{userDTO.Email} registration success!");
            userDTO.Id = id;
            return CreatedAtAction(nameof(RegisterNewAccount), userDTO);
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _userService.LoginAsync(loginDTO);
            if (token == null)
            {
                _logger.Warning($"{loginDTO.Email} account not found");
                return NoContent();
            }

            _logger.Information($"{loginDTO.Email} get account");

            Response.ContentType = "application/json";
            return Accepted(token);
        }
    }
}