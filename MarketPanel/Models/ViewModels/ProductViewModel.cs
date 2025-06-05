using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketPanel.Models.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }

        public List<SelectListItem>? Categories { get; set; }
    }
}
