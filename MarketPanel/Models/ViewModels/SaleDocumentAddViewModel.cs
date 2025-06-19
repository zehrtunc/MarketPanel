namespace MarketPanel.Models.ViewModels;

public class SaleDocumentAddViewModel
{
    public string Description { get; set; }
    public List<long> SaleItemIds { get; set; } = new(); // baslangicta null degil bos liste olarak baslatilmasi icin
}

