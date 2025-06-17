namespace MarketPanel.Models.ViewModels;

public class SaleDocumentAddViewModel
{
    public string Description { get; set; }
    public List<SaleDocumentSalesListViewModel> SaleItems { get; set; } = new();
}


