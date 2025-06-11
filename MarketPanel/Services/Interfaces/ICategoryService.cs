using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;

namespace MarketPanel.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryViewModel>> GetAllAsync();
    Task<Category> GetByIdAsync(long id);
    Task<bool> CreateAsync(Category category);
    Task<bool> UpdateAsync(CategoryViewModel model);
    Task<bool> DeleteAsync(long id);
}
