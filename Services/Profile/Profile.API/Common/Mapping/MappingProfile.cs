using Profile.API.DTO;

namespace Profile.API.Common.Mapping
{
    /// <summary>
    ///     Define Automapper profile for Profile entities.
    /// </summary>
    public class MappingProfile : AutoMapper.Profile
    {
        /// <summary>
        ///     Constructor automapper
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Models.Profile, ProfileDTO>().ReverseMap();
        }
    }
}