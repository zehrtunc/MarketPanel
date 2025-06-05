namespace MarketPanel.Models.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
