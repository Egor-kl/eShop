using System;
using System.Collections.Generic;
using Profile.API.DTO;

namespace Profile.Tests
{
    public class ControllerTestFixture
    {
        /// <summary>
        /// Generate collection of User DTO.
        /// </summary>
        /// <returns>Collection of User DTO.</returns>
        public ICollection<ProfileDTO> GetAllProfiles()
        {
            return new List<ProfileDTO>()
            {
               new ProfileDTO()
                {
                    Id = 123,
                    FirstName = "Some",
                    LastName = "Something",
                    Phone = "3752901231210",
                    BirthDate = DateTime.Today,
                    UserId = 123
                },

               new ProfileDTO()
               {
                   Id = 234,
                   FirstName = "Ivan",
                   LastName = "Ivanov",
                   Phone = "375290000000",
                   BirthDate = DateTime.Today,
                   UserId = 234
               }
            };
        }

        /// <summary>
        /// Generate single User DTO.
        /// </summary>
        /// <returns>User DTO.</returns>
        public ProfileDTO GetProfile()
        {
            return new ProfileDTO()
            {
                Id = 111,
                FirstName = "Petr",
                LastName = "Patrick",
                Phone = "375290000001",
                BirthDate = DateTime.Today,
                UserId = 111
            };
        }
    }
}