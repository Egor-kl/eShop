using AutoMapper;
using Catalog.API.DTO;
using Catalog.API.Models;

namespace Catalog.API.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}