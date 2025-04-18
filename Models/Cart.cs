namespace eApp.Models;

public class Cart : EntityBase
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}