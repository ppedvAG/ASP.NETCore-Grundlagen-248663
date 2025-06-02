using BusinessModel.Models;
using DemoMvcApp.Models;

namespace DemoMvcApp.Mappers;

public static class RecipesMapper
{
    public static RecipeViewModel ToViewModel(this Recipe domainModel)
    {
        return new RecipeViewModel
        {
            Id = domainModel.Id,
            Name = domainModel.Name,
            Ingredients = domainModel.Ingredients,
            Instructions = domainModel.Instructions,
            ImageUrl = domainModel.ImageUrl,
            CaloriesPerServing = domainModel.CaloriesPerServing,
            MealType = domainModel.MealType.FirstOrDefault(),
            PrepTimeMinutes = domainModel.PrepTimeMinutes,
            CookTimeMinutes = domainModel.CookTimeMinutes,
            Cuisine = domainModel.Cuisine,
            Difficulty = domainModel.Difficulty,
            Rating = domainModel.Rating,
            Servings = domainModel.Servings,
            Tags = domainModel.Tags,
        };
    }
}
