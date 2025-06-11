namespace MarketPanel.Models.ViewModels;

public class CategoryViewModel
{
    public long Id { get; set; }
    public string Name{ get; set; }

    // Product gibi listelemek ve editleme - ekleme için iki ayrı vıewmodele ihityaç duyacağım bir farklı durum söz konusu değil
    // kategori eklerken veya editlerken sadece isim bilgisi üzerinden işlem yapabilirim
    // kategorileri listelerken de yine saedece İsim üzerinden listeleyecegim
    // Id bilgisi ise Delete ve edit işleminde mevcut kullanıcıyı ıd bılgısı uzerınden getirebilmnek için lazım
}