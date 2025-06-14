using AutoMapper;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;

namespace MarketPanel.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>(); // Db`den veri okuma ve ekrana yansitmak icin ViewModele donusum (entitiy -> ViewModel)
        CreateMap<ProductViewModel, Product>()  // Viewden alinan verinin DB`deki veriye  guncelleme yapmasi (ViewModel -> entity)
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Id korunur (Db deki mevcut entitiy uzerinde guncelleme yapabilmesi icin)

        CreateMap<Product, ProductListViewModel>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<ProductListViewModel, Product>();


        CreateMap<Category, CategoryViewModel>().ReverseMap();

        CreateMap<SaleItem, SaleItemListViewModel>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));




    }

}
