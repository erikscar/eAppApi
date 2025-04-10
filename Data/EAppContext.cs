using eApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eApp.Data;

public class EAppContext : DbContext
{
    public EAppContext(DbContextOptions<EAppContext> options): base(options) {}
    public DbSet<User> Users { get; set; }

}