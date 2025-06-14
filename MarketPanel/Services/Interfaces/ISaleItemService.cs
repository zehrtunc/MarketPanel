

using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketPanel.Services.Interfaces;
public interface ISaleItemService
{
    decimal CalculateTotal();

    Task<List<SelectListItem>> GetProductsAsync();

    Task<List<SaleItemListViewModel>> GetAllAsync();

    Task<SaleItemViewModel> GetByIdAsync(long id);

    Task<bool> CreateAsync(SaleItemViewModel model);

    Task<bool> UpdateAsync(SaleItemViewModel model);
    Task<bool> DeleteAsync(long id);
}

