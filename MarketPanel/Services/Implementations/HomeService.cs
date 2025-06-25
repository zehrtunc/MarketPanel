using MarketPanel.Data;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPanel.Services.Implementations;

public class HomeService : IHomeService
{
    private readonly ApplicationDbContext _context;

    public HomeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HomeViewModel> GetDatasAsync()
    {
        var model = new HomeViewModel()
        {
            CategoryCount = await _context.Categories.CountAsync(),
            ProductCount = await _context.Products.CountAsync(),
            SaleItemCount = await _context.SaleItems.CountAsync(),
            SaleDocumentCount = await _context.SaleDocuments.CountAsync()
        };

        return model;
    }
}
