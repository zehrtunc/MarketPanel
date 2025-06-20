using MarketPanel.Models.ViewModels;

namespace MarketPanel.Services.Interfaces;

public interface ISaleDocumentService
{
    Task<List<SaleDocumentListViewModel>> GetAllAsync();

    Task<SaleDocumentViewModel> GetByIdAsync(long id);

    Task<bool> CreateAsync(SaleDocumentAddViewModel model);

    Task<bool> UpdateAsync(SaleDocumentViewModel model);

    Task<bool> DeleteAsync(long id);
    Task<SaleDocumentDetailViewModel> DetailAsync(long id);
}
