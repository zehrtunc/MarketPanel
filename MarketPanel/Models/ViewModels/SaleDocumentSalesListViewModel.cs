namespace MarketPanel.Models.ViewModels;

public class SaleDocumentSalesListViewModel
{
    public long Id { get; set; }
    public string DocumentNumber { get; set; }
    public string Description { get; set; }
    public DateTime InsertDate { get; set; }
    public decimal TotalAmount { get; set; }
}

