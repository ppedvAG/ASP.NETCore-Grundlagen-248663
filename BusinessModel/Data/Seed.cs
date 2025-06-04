﻿using BusinessLogic.Models.Enums;
using BusinessModel.Models;
using Microsoft.AspNetCore.Identity;
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

    #region Identity
    public const string ADMIN_ROLE_ID = "d4e8321b-447b-43d2-bdce-f4738b588bec";
    public const string ADMIN_ROLE = "Admin";
    public const string USER_ROLE_ID = "eb6b2a41-9e08-4243-bf9b-74f5ac6d9297";
    public const string USER_ROLE = "User";

    public const string ROOT_USER_ID = "3a32e868-9191-4c77-a8ea-4c825571b5bf";
    public const string ROOT_USER_NAME = "R. Root";
    public const string ROOT_USER_EMAIL = "root@example.com";

    public const string JOHN_USER_ID = "4b43c757-9e01-4243-bf9b-f4738b588bec";
    public const string JOHN_USER_NAME = "John Doe";
    public const string JOHN_USER_EMAIL = "john.doe@example.com";

    // Syst3m
    public const string DEFAULT_PWD_HASH = "AQAAAAIAAYagAAAAEI9bnzxidZZ+yhCWxSEb3S6FK1cSyK/2GPjRLnssQErapeLrjxRDdlzL22WyyowLRA==";

    public static void SeedIdentity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = ADMIN_ROLE,
                    NormalizedName = ADMIN_ROLE.ToUpper()
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = USER_ROLE,
                    NormalizedName = USER_ROLE.ToUpper()
                }
            });

        modelBuilder.Entity<IdentityUser>().HasData(new List<IdentityUser>()
            {
                new IdentityUser
                {
                    Id = ROOT_USER_ID,
                    UserName = ROOT_USER_NAME,
                    NormalizedUserName = ROOT_USER_NAME.ToUpper(),
                    Email = ROOT_USER_EMAIL,
                    NormalizedEmail = ROOT_USER_EMAIL.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = DEFAULT_PWD_HASH
                },
                new IdentityUser
                {
                    Id = JOHN_USER_ID,
                    UserName = JOHN_USER_NAME,
                    NormalizedUserName = JOHN_USER_NAME.ToUpper(),
                    Email = JOHN_USER_EMAIL,
                    NormalizedEmail = JOHN_USER_EMAIL.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = DEFAULT_PWD_HASH
                }
            });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ROOT_USER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = JOHN_USER_ID
                }
            });
    }

    #endregion

}