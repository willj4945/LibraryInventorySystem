using LibraryInventorySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventorySystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Inventory> Inventories { get; set; }

}