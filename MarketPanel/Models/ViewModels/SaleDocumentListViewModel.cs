namespace MarketPanel.Models.ViewModels;

public class SaleDocumentListViewModel
{
    public long Id { get; set; } // listleme ekraninda spesifik bir dokumanin silme ve guncelleme islemlerini gerceklestirebilmek icin gerekli
    public string DocumentNumber { get; set; }
    public string Description { get; set; }
    public DateTime InsertDate { get; set; }
    public decimal TotalAmount { get; set; }
}

