﻿using Identity.DTO;
using Identity.Models;

namespace Identity.Common.Mapping
{
    /// <summary>
    /// Define Automapper profile for Identity entities.
    /// </summary>
    public class MappingProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Constructor automapper
        /// </summary>
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}