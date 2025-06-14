using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketPanel.Models.ViewModels
{
    public class SaleItemViewModel
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VATRate { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public long ProductId { get; set; }

        public List<SelectListItem>? Products { get; set; }

    }
}
