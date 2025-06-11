using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;

namespace MarketPanel.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductListViewModel>> GetAllAsync();
        Task<Product> GetByIdAsync(long id);
        Task<bool> CreateAsync(Product product);
        Task<bool> UpdateAsync(ProductViewModel product);
        Task<bool> DeleteAsync(long id);
    }
}
