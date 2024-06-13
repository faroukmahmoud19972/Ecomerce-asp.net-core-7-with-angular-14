using AutoMapper;
using Ecom.api.DTOS;
using Ecom.core.Entities;

namespace Ecom.api.MappingProfiles
{
    public class MappingPorduct : Profile
    {
        public MappingPorduct()
        {
            CreateMap<Product ,ProductDTO>()
                .ForMember(d=>d.CategoryName,o=> o.MapFrom(s=>s.Category.Name))
                .ReverseMap();
            CreateMap<Product ,CreateProductDTO >().ReverseMap();
        }
    }
}
