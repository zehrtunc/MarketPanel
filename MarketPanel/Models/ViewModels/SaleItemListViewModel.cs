namespace MarketPanel.Models.ViewModels;

public class SaleItemListViewModel
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal VATRate { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; } 
    public string ProductName { get; set; }
    public long? SaleDocumentId { get; set; }


}
