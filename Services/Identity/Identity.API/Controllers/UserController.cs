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
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        /// <summary>
        ///     Constructor of controller for user manage.
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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (id, success, message) = await _userService.RegisterAsync(userDTO);
            if (!success)
            {
                _logger.Warning($"{userDTO.Email} user already exist");
                return Conflict(new {message});
            }

            _logger.Information($"{userDTO.Email} registration success!");
            userDTO.Id = id;
            return CreatedAtAction(nameof(RegisterNewAccount), userDTO);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var token = await _userService.LoginAsync(loginDTO);
            if (token == null)
            {
                _logger.Warning($"{loginDTO.Email} user not found");
                return NoContent();
            }

            _logger.Information($"{loginDTO.Email} is login");

            Response.ContentType = "application/json";
            return Accepted(token);
        }

        [HttpGet]
        public async Task<ICollection<UserDTO>> GetAccounts()
        {
            var users = await _userService.GetAllUsersAsync();
            var count = users.Count;

            _logger.Information($"{count} count of users");
            return users;
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetAccountById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                _logger.Warning($"User with id: {id} not found");
                return NoContent();
            }

            _logger.Information($"{user.UserName} user found");
            return Ok(user);
        }

        [HttpGet("getByUsername/{username}")]
        public async Task<IActionResult> GetAccountByUserName([FromRoute] string username)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userService.GetUserByUsernameAsync(username);
            if (user == null)
            {
                _logger.Warning($"User with username: {username} not found");
                return NoContent();
            }

            _logger.Information($"{user.UserName} user found");
            return Ok(user);
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> DeleteAccountById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _userService.DeleteUserByIdAsync(id);
            if (!success)
            {
                _logger.Warning($"User with id: {id} not found");
                return NotFound(id);
            }

            _logger.Information($"{id} successfully delete");
            return Ok(id);
        }

        [HttpPut("updateById/{id}")]
        public async Task<IActionResult> UpdateAccount([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userService.GetUserByEmailAsync(userDTO.Email);
            if (user == null)
            {
                _logger.Warning($"{userDTO.Email}");
                return NotFound(userDTO.Id);
            }

            var success = await _userService.UpdateUserAsync(userDTO);
            if (!success)
            {
                _logger.Warning($"{userDTO.Email} update conflict");
                return Conflict();
            }

            _logger.Information($"{userDTO.Email} update user succes");
            return Ok(userDTO);
        }
    }
}