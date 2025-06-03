using BusinessLogic.Models.Enums;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data;

public class Seed
{
    public const int DEFAULT_ORDER_ID = 1;
    public const string DEFAULT_USER_NAME = "John Doe";

    internal static void SeedData(ModelBuilder modelBuilder)
    {
        var recipes = RecipeReader.FromJsonFile();

        if (recipes == null)
        {
            throw new InvalidDataException("Failed to read recipes");
        }

        var orderItems = new List<OrderItem>
        {
            new OrderItem { Id = 1, OrderId = 1, RecipeId = 1, Quantity = 1, Rating = 5 },
            new OrderItem { Id = 2, OrderId = 1, RecipeId = 2, Quantity = 2, Rating = 2 },
            new OrderItem { Id = 3, OrderId = 1, RecipeId = 3, Quantity = 3, Rating = 3 },
        };

        var orders = new List<Order>
        {
            new Order
            {
                Id = DEFAULT_ORDER_ID,
                UserName = DEFAULT_USER_NAME,
                OrderDate = new DateTime(2023, 1, 1), // Bitte hier konstate Daten verwenden
                Rating = 4.5f,
                Status = OrderStatus.Pending,
            }
        };

        modelBuilder.Entity<Recipe>().HasData(recipes);
    }
}