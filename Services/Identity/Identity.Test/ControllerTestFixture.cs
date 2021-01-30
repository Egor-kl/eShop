using System;
using System.Collections.Generic;
using Identity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Identity.Test
{
    public class ControllerTestFixture
    {
        /// <summary>
        /// Generate collection of User DTO.
        /// </summary>
        /// <returns>Collection of User DTO.</returns>
        public ICollection<UserDTO> GetAllAccounts()
        {
            return new List<UserDTO>()
            {
               new UserDTO()
                {
                    Id = 123,
                    Email = "test@gmail.com",
                    Password = "passw@rd123",
                    UserName = "test",
                    Role = "User"
                },

               new UserDTO()
               {
                   Id = 234,
                   Email = "admin@gmail.com",
                   Password = "passw@rd123",
                   UserName = "admin",
                   Role = "Admin"
               },
            };
        }

        /// <summary>
        /// Generate single User DTO.
        /// </summary>
        /// <returns>User DTO.</returns>
        public UserDTO GetAccount()
        {
            return new UserDTO()
            {
                Id = 111,
                Email = "test@gmail.com",
                Password = "passw@rd123",
                UserName = "test",
                Role = "User"
            };
        }

        /// <summary>
        /// Get null User DTO.
        /// </summary>
        /// <returns>Null object.</returns>
        public UserDTO GetNullAccount() => null;

        /// <summary>
        /// Generate single Login DTO.
        /// </summary>
        /// <returns>Login DTO.</returns>
        public LoginDTO GetLoginData()
        {
            return new LoginDTO()
            {
                Email = "test@gmail.com",
                Password = "passw@rd123",
            };
        }

        /// <summary>
        /// Generate single JWT.
        /// </summary>
        /// <returns>Token DTO.</returns>
        public TokenDTO GetToken()
        {
            return new TokenDTO()
            {
                Username = "admin",
                Role = "Admin",
                Token = "aasd123asdaW1p23asd6"
            };
        }

        /// <summary>
        /// Get null Token DTO.
        /// </summary>
        /// <returns>Null object.</returns>
        public TokenDTO GetNullToken() => null;

        /// <summary>
        /// Get fake controller context.
        /// </summary>
        /// <returns></returns>
        public ControllerContext GetFakeContext()
        {
            var responseMock = new Mock<HttpResponse>();
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(a => a.Response).Returns(responseMock.Object);

            var context = new ControllerContext { HttpContext = httpContextMock.Object };

            return context;
        }
    }
}