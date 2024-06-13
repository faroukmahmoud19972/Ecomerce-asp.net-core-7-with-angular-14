using AutoMapper;
using Ecom.api.DTOS;
using Ecom.core.Entities;

namespace Ecom.api.MappingProfiles
{
    public class MappingCategory : Profile
    {
        public MappingCategory()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<ListingCategoryDTO, Category>().ReverseMap();
        }
    }
}
