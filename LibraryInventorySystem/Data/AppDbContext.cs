// Testing for branch update
using LibraryInventorySystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventorySystem.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Employee> Employee { get; set; }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

}