using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarketPanel.Models.Entities;

public class SaleItem
{
    public long Id { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Precision(18,2)]
    public decimal UnitPrice { get; set; }

    [Required]
    [Precision(5,2)]
    public decimal VATRate { get; set; } //KDV ratio

    [Required]
    [Precision(18,2)]
    public decimal Discount { get; set; } //Iskonto

    [Required]
    [Precision(18,2)]
    public decimal Total { get; set; } //o urun icin Total


    public long? SaleDocumentId { get; set; }
    public virtual SaleDocument SaleDocument { get; set; }

    public long ProductId { get; set; }
    public virtual Product Product { get; set; }
}
