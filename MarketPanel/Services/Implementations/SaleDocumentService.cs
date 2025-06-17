using AutoMapper;
using MarketPanel.Data;
using MarketPanel.Models.Entities;
using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

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

    public async Task<bool> CreateAsync(SaleDocumentAddViewModel model)
    {
        var selectedSaleItemIds = await _context.SaleItems
            .Select(x => x.Id).ToListAsync();

        var saleItems = await _context.SaleItems
            .Where(x => selectedSaleItemIds.Contains(x.Id) && x.SaleDocumentId == null) //SaleItem daha önce bir SaleDocument'a ait mi değil mi?
            .ToListAsync();

        if (saleItems == null) throw new Exception("Satış kalemleri alınamadı. Satışlar listesi null döndü.");

        if (!saleItems.Any()) throw new Exception("Seçilen satış kalemleri bulunamadı. Liste boş.");

        var totalAmount = saleItems.Sum(x => x.Total); // satislarin net ucretlerinin toplami

        var saleDocument = _mapper.Map<SaleDocument>(model);

        // Entityde olan ama modelde olmayanlari kendimiz mapleyecegiz
        saleDocument.TotalAmount = totalAmount;
        saleDocument.InsertDate = DateTime.Now;
        saleDocument.DocumentNumber = GenerateDocumentNumber();

        //her bir satiri iliskilendirebilmek icin foreach ile her birini donerek mapleyecegiz

    }
}
