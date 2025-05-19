using eApp.Models;

public class CartDTO
{
    public decimal Total { get; set; }
    public decimal TotalWithDiscount { get; set; }
    public decimal TotalDiscountAmount { get; set; }
    
    public List<CartItem> CartItems { get; set; }

}