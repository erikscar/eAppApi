namespace eApp.Models;

public class Cart : EntityBase
{
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}