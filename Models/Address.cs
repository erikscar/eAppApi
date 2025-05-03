namespace eApp.Models
{
    public class Address : EntityBase
    {
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? PostalCode  { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
