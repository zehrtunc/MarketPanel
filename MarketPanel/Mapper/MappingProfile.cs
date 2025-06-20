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


        CreateMap<ProductListViewModel, Product>();
        CreateMap<Product, ProductListViewModel>()
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));


        CreateMap<Category, CategoryViewModel>().ReverseMap();


        CreateMap<SaleItemListViewModel, SaleItem>();
        CreateMap<SaleItem, SaleItemListViewModel>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        CreateMap<SaleItemViewModel, SaleItem>().ReverseMap();
        //CreateMap<SaleItem, SaleItemViewModel>()
        //    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.Price));

        CreateMap<SaleDocumentAddViewModel, SaleDocument>()
            .ForMember(dest => dest.TotalAmount, opt => opt.Ignore())
            .ForMember(dest => dest.DocumentNumber , opt => opt.Ignore())
            .ForMember(dest => dest.SaleItems, opt => opt.Ignore())
            .ForMember(dest => dest.InsertDate, opt => opt.Ignore());

        CreateMap<SaleDocument, SaleDocumentListViewModel>();

        CreateMap<SaleDocument, SaleDocumentViewModel>().ReverseMap();

        CreateMap<SaleDocument, SaleDocumentDetailViewModel>().ReverseMap();
        CreateMap<SaleItem, SaleDocumentItemViewModel>().ReverseMap();

    }

}
