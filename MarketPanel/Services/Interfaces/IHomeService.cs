using MarketPanel.Models.ViewModels;

namespace MarketPanel.Services.Interfaces;

public interface IHomeService
{
    Task<HomeViewModel> GetDatasAsync();
}
