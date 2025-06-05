namespace MarketPanel.Models.Entities;

public class SaleDocument
{
    public long Id { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public decimal TotalAmount { get; set; } //Hesaplanacak

    public virtual ICollection<SaleItem> SaleItems { get; set; }


}
