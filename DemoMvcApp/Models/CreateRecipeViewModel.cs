using BusinessLogic.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DemoMvcApp.Models;

public class CreateRecipeViewModel
{
    [Required(ErrorMessage = "Name fuer das Rezept ist erforderlich")]
    [MinLength(4, ErrorMessage = "Name fuer das Rezept muss mindestens 4 Zeichen haben")]
    [MaxLength(100, ErrorMessage = "Name fuer das Rezept darf nicht mehr als 100 Zeichen haben")]
    public required string Name { get; set; }

    [Display(Name = "Zutaten")]
    public string? Ingredients { get; set; }

    [Display(Name = "Zubereitung")]
    public string? Instructions { get; set; }

    [Display(Name = "Vorbereitung")]
    [Range(0, 120, ErrorMessage = "Vorbereitungsdauer darf nicht mehr als 120 Minuten betragen")]
    public int PrepTimeMinutes { get; set; }

    [Display(Name = "Kochzeit")]
    [Range(0, 120, ErrorMessage = "Vorbereitungsdauer darf nicht mehr als 120 Minuten betragen")]
    public int CookTimeMinutes { get; set; }

    [Display(Name = "Portionen")]
    public int Servings { get; set; }

    public Difficulty Difficulty { get; set; }

    public Cuisine Cuisine { get; set; }

    [Display(Name = "Kalorien pro Portion")]
    public int CaloriesPerServing { get; set; }

    public string? Tags { get; set; }

    public string? ImageUrl { get; set; }

    [Range(0, 5, ErrorMessage = "Die Bewertung muss zwischen 0 und 5 liegen")]
    public float Rating { get; set; } = 0;

    public MealType MealType { get; set; }
}
