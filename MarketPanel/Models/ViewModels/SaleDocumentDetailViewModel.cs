namespace MarketPanel.Models.ViewModels;

public class SaleDocumentDetailViewModel
{
    public long Id { get; set; } 
    public string DocumentNumber { get; set; }
    public string Description { get; set; }
    public DateTime InsertDate { get; set; }
    public decimal TotalAmount { get; set; }

    public List<SaleDocumentItemViewModel> SaleItems { get; set; } = new(); //Baslangicta bos liste olarak tanimliyorum ki null olma durumu olmasin
}
