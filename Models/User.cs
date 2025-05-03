namespace eApp.Models;

public class User : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Phone { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public virtual Cart? Cart { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

}
