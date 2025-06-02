using BusinessLogic.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DemoMvcApp.Models;

[DebuggerDisplay("{Id}, {Name}, {Difficulty}, {Cuisine}, {CaloriesPerServing}, {Rating}, {Tags}")]
public class RecipeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    [Display(Name = "Zutaten")]
    public string[] Ingredients { get; set; } = [];

    [Display(Name = "Zubereitung")]
    public string[] Instructions { get; set; } = [];

    [Display(Name = "Vorbereitung")]
    public int PrepTimeMinutes { get; set; }

    [Display(Name = "Kochzeit")]
    public int CookTimeMinutes { get; set; }

    [Display(Name = "Portionen")]
    public int Servings { get; set; }
    public Difficulty Difficulty { get; set; }
    public string Cuisine { get; set; }

    [Display(Name = "Kalorien pro Portion")]
    public int CaloriesPerServing { get; set; }
    public string[] Tags { get; set; } = [];
    public int UserId { get; set; }
    public string ImageUrl { get; set; }
    public float Rating { get; set; }
    public int ReviewCount { get; set; }
    public string? MealType { get; set; }
}
