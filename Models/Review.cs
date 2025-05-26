
namespace eApp.Models
{
    public class Review : EntityBase
    {
        public string? Content { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
