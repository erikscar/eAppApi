using eApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eApp.Data;

public class EAppContext : DbContext
{
    public EAppContext(DbContextOptions<EAppContext> options): base(options) {}
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}