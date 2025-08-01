namespace eApp.Models;

public class User : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; } = "User";
    public string? Phone { get; set; }
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public virtual Cart? Cart { get; set; }
    public virtual Address? Address { get; set; }

}
