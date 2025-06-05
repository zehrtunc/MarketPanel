namespace MarketPanel.Models.Entities;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; } //per unit

    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
