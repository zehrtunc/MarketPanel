using MarketPanel.Models.ViewModels;

namespace MarketPanel.Services.Interfaces;

public interface ISaleDocumentService
{
    Task<bool> CreateAsync(SaleDocumentAddViewModel model);
}
