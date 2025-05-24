namespace eApp.Models;

public class Product : EntityBase 
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int ReviewsNumber { get; set; }
    public int Offer { get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}