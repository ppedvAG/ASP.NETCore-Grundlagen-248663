using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        // Wir fuegen hier ein Converter hinzu, um ein string array als konkatinierten String mit Zeilenumbruch
        // in die Db zu schreiben (convertToProviderExpression). Der 2. Parameter (convertFromProviderExpression)
        // ist die Konvertierungslogik zum lesen der Daten aus der Db. 
        modelBuilder.Entity<Recipe>()
            .Property(o => o.Ingredients)
            .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<Recipe>()
            .Property(o => o.Instructions)
            .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<Recipe>()
            .Property(o => o.Tags)
            .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));

        // Formuliert die Beziehung (sog. Constraints) von Order zur OrderItems (1:N Beziehung)
        // mit OrderId als ForeignKey
        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Order) // has one relation to order table
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId);

        #endregion
    }
}
