using MarketPanel.Models.ViewModels;

namespace MarketPanel.Services.Interfaces;

public interface ISaleDocumentService
{
    Task<List<SaleDocumentListViewModel>> GetAllAsync();

    Task<bool> CreateAsync(SaleDocumentAddViewModel model);
    Task<SaleDocumentViewModel> GetByIdAsync(long id);
}
