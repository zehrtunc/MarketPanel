using AutoMapper;
using MarketPanel.Data;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using System.Security.Cryptography.Xml;

namespace MarketPanel.Services.Implementations;

public class SaleDocumentService : ISaleDocumentService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SaleDocumentService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private string GenerateDocumentNumber()
    {

        var documentNumber = $"SD-{Guid.NewGuid().ToString("N")[..4].ToUpper()}";

        return documentNumber;
    }

    public async Task<List<SaleDocumentListViewModel>> GetAllAsync()
    {
        var saleDocuments = await _context.SaleDocuments.ToListAsync();

        var models = _mapper.Map<List<SaleDocumentListViewModel>>(saleDocuments);

        return models;
    }

    public async Task<SaleDocumentViewModel> GetByIdAsync(long id)
    {
        var saleDocument = await _context.SaleDocuments.FindAsync(id);

        var model = _mapper.Map<SaleDocumentViewModel>(saleDocument);

        return model;
    }

    public async Task<bool> CreateAsync(SaleDocumentAddViewModel model)
    {
        var saleItems = await _context.SaleItems
            .Where(x => model.SaleItemIds.Contains(x.Id) && x.SaleDocumentId == null) //SaleItem daha önce bir SaleDocument'a ait mi değil mi?
            .ToListAsync();

        if (!saleItems.Any()) throw new Exception("Seçilen satış kalemleri bulunamadı. Liste boş.");


        var totalAmount = saleItems.Sum(x => x.Total); // satislarin net ucretlerinin toplami

        var saleDocument = _mapper.Map<SaleDocument>(model);

        // Entityde olan ama modelde olmayanlari kendimiz mapleyecegiz
        saleDocument.TotalAmount = totalAmount;
        saleDocument.InsertDate = DateTime.Now;
        saleDocument.DocumentNumber = GenerateDocumentNumber();

        //her bir satiri iliskilendirebilmek icin foreach ile her birini donerek mapleyecegiz

        foreach(var item in saleItems)
        {
            item.SaleDocument = saleDocument;
        }

        await _context.SaleDocuments.AddAsync(saleDocument);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(SaleDocumentViewModel model)
    {
        var saleDocument = await _context.SaleDocuments.FindAsync(model.Id); // View modeldan gelen verinin DB`de eslesen kaydini bulmak icin

        if (saleDocument == null) throw new Exception("Güncellemek istediğiniz satış evrağı bulunamadı.");

        _mapper.Map(model, saleDocument); // Viewmodelden gelen veriler ile Db`den gelen verileri mapleriz. yeni instance olusturulmadan

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var saleDocument = await _context.SaleDocuments.FindAsync(id);

        if (saleDocument == null) throw new Exception("Silmek istediğiniz satış evrağı bulunamadı.");

        _context.SaleDocuments.Remove(saleDocument);
        await _context.SaveChangesAsync();

        return true;
    }
}
