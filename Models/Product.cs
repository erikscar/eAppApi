namespace eApp.Models;

public class Product : EntityBase 
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public virtual ICollection<Cart>? Carts { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}