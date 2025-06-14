using AutoMapper;
using MarketPanel.Data;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarketPanel.Services.Implementations;

public class SaleItemService : ISaleItemService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public SaleItemService(ApplicationDbContext context, IMapper mapper)
    {

        _context = context;
        _mapper = mapper;
    }

    public decimal CalculateTotal(SaleItemViewModel model)
    {
        var subTotal = model.Quantity + model.UnitPrice;
        var discounted = subTotal - model.Discount; // indirimli fiyat
        var vatAmount = discounted * model.VATRate / 100; // KDV Tutari 

        var total = Math.Round(discounted + vatAmount, 2); // 2 Ondalik basamakli sayi -> Math.Round(value, 2)

        return total;
    }

    public async Task<List<SelectListItem>> GetProductsAsync()
    {
        var productList = await _context.Products.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToListAsync();

        return productList;
    }

    public async Task<List<SaleItemListViewModel>> GetAllAsync()
    {
        var saleItems = await _context.SaleItems.ToListAsync();

        var models = _mapper.Map<List<SaleItemListViewModel>>(saleItems);

        return models;
    }

    public async Task<SaleItemViewModel> GetByIdAsync(long id)
    {
        var saleItem = await _context.SaleItems.FindAsync(id);
        if (saleItem == null) throw new Exception("Satış satırı bulunamadı");

        var model = _mapper.Map<SaleItemViewModel>(saleItem);

        model.Products = await GetProductsAsync();

        return model;
    }


    public async Task<bool> CreateAsync(SaleItemViewModel model)
    {
        var saleItem = _mapper.Map<SaleItem>(model);
        saleItem.Total = CalculateTotal(model); // DB`ye total deger yazilir

        await _context.SaleItems.AddAsync(saleItem);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(SaleItemViewModel model)
    {
        var saleItem = await _context.SaleItems.FindAsync(model.Id);

        if (saleItem == null) throw new Exception("Güncellemek istediğiniz satış bulunamadı.");

        _mapper.Map(model, saleItem);

        saleItem.Total = CalculateTotal(model); // DB`ye total deger yazilir

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var saleItem = await _context.SaleItems.FindAsync(id);

        if (saleItem == null) throw new Exception("Silmek istediğiniz satış bulunamadı.");

        _context.SaleItems.Remove(saleItem);
        await _context.SaveChangesAsync();

        return true;

    }
}
