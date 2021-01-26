using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Identity.Common.Interfaces;
using Identity.DTO;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IIdentityContext _identityContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of service for managing user accounts.
        /// </summary>
        /// <param name="identityContext">Identity service.</param>
        /// <param name="mapper">Mapping service.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserService( IIdentityContext identityContext, IMapper mapper)
        {
            _identityContext = identityContext ?? throw new ArgumentNullException(nameof(identityContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<TokenDTO> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return null;
            
            var user = await _identityContext.Users.SingleOrDefaultAsync(x=> x.Email == loginDTO.Email && x.Password == loginDTO.Password);
           
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secret");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(31),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            var userToken = new TokenDTO
            {
                Id = user.Id,
                Username = user.UserName,
                Role = user.Role,
                Token = jwtSecurityToken
            };

            return userToken;
        }
        
        /// <inheritdoc/>
        public async Task<(int id, bool result, string message)> RegisterAsync(UserDTO userDTO)
        {
            var user = await _identityContext.Users.FirstOrDefaultAsync(a => a.Email == userDTO.Email || a.UserName == userDTO.UserName 
                                                                         || a.Email == userDTO.Email && a.UserName == userDTO.UserName);
            if (user != null)
            {
                return (0, false, "User already exist" );
            }

            var account = _mapper.Map<UserDTO, User>(userDTO);

            await _identityContext.Users.AddAsync(account);
            await _identityContext.SaveChangesAsync(new CancellationToken());

            var id = account.Id;
            return (id, true, "Registration success!");
        }
        
        /// <inheritdoc/>
        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _identityContext.Users.FirstOrDefaultAsync(a => a.Email == email);
            var userDTO = _mapper.Map<User, UserDTO>(user);

            return userDTO;
        }
        
        /// <inheritdoc/>
        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _identityContext.Users.FirstOrDefaultAsync(a => a.Id == userId);
            var userDTO = _mapper.Map<User, UserDTO>(user);

            return userDTO;
        }
        
        /// <inheritdoc/>
        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            var user = await _identityContext.Users.FirstOrDefaultAsync(a => a.UserName == username);
            var userDTO = _mapper.Map<User, UserDTO>(user);

            return userDTO;
        }
        
        /// <inheritdoc/>
        public async Task<ICollection<UserDTO>> GetAllUsersAsync()
        {
            var userCollection = await _identityContext.Users.Select(a => a).ToListAsync();
            var collectionOfuserDTO = new List<UserDTO>();

            foreach (var account in userCollection)
            {
                var userDTO = _mapper.Map<UserDTO>(account);
                collectionOfuserDTO.Add(userDTO);
            }

            return collectionOfuserDTO;
        }
        
        /// <inheritdoc/>
        public async Task<bool> UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _identityContext.Users.FirstOrDefaultAsync(a => a.Id == userDTO.Id);

            if (user == null)
            {
                return false;
            }

            user.UserName = userDTO.UserName;
            user.Role = userDTO.Role;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;

            _identityContext.Update(user);
            await _identityContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
        
        /// <inheritdoc/>
        public async Task<bool> DeleteUserByIdAsync(int userId)
        {
            var user = await _identityContext.Users.FirstOrDefaultAsync(a => a.Id == userId);
            if (user == null)
            {
                return false;
            }

            _identityContext.Remove(user);
            await _identityContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
    }
}