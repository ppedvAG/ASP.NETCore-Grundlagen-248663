using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data;

public class DemoMvcDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DemoMvcDbContext(DbContextOptions<DemoMvcDbContext> options) 
        : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Seed.SeedData(modelBuilder);

        #region Alternative zu DataAnnotations
        modelBuilder.Entity<Recipe>()
            .Property(o => o.Ingredients)
            .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<Recipe>()
            .Property(o => o.Instructions)
            .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<Recipe>()
            .Property(o => o.Tags)
            .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId);
        #endregion
    }
}
