using System.ComponentModel.DataAnnotations.Schema;

namespace eApp.Models;

public class Cart : EntityBase
{
    [NotMapped]
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}