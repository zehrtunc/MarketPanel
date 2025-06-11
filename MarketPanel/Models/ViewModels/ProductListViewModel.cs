namespace MarketPanel.Models.ViewModels
{
    public class ProductListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }

        //ProductViewModel da kategorilerin selecyt option yağısında listelenebilmesi için bir lisleme satırı mevcut
        //Ürünleri listelerken kategorilerin selecyt option yapısı olmamalı ilgili ürünün sahip olduüu kategori bilgisi ile gelmeli
        //Bu sebeple Select only yanı sadece okuma ıslemı olan bu lısteleme durumunda ayrı bır viewmodele ihtiyac duydum
    }
}
