namespace MarketPanel.Models.ViewModels;

public class SaleDocumentViewModel
{
    public long Id { get; set; } 
    public string Description { get; set; }
    public DateTime InsertDate { get; set; }
    public decimal TotalAmount { get; set; }
    
    //Dokuman numarasi degismeyeceginden burda property olarak verilmedi
}
