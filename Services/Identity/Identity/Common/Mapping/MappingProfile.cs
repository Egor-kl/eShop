using AutoMapper;
using Identity.DTO;
using Identity.Models;

namespace Identity.Common.Mapping
{
    /// <summary>
    /// Define Automapper profile for Identity entities.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}