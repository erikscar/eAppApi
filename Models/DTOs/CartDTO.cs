using eApp.Models;

public class CartDTO
{
    public string TotalBRL { get; set; }
     public string TotalWithDiscountBRL { get; set; }
      public string TotalDiscountAmountBRL { get; set; }

    public string DiscountPercentageAmount { get; set; }

    public ICollection<CartItem> CartItems { get; set; }

}