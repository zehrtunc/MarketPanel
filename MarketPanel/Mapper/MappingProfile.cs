using AutoMapper;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;

namespace MarketPanel.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
    }
   
}
