namespace eApp.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Offer { get; set; }
        public double AverageRating { get; set; }
        public int CategoryId { get; set; }
    }
}
