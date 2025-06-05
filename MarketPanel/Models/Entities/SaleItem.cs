namespace MarketPanel.Models.Entities;

public class SaleItem
{
    public long Id { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal VATRate { get; set; } //KDV ratio
    public decimal Discount { get; set; } //Iskonto

    public long SaleDocumentId { get; set; }
    public virtual SaleDocument SaleDocument { get; set; }

    public long ProductId { get; set; }
    public virtual Product Product { get; set; }
}
