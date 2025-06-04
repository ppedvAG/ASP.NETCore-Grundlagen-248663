using BusinessModel.Models;
using DemoMvcAuthApp.Models;

namespace DemoMvcAuthApp.Mappers;

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

    public static Recipe ToDomainModel(this CreateRecipeViewModel viewModel)
    {
        return new Recipe
        {
            Name = viewModel.Name,
            Ingredients = viewModel.Ingredients != null ? viewModel.Ingredients.Split('\n') : [],
            Instructions = viewModel.Instructions?.Split('\n') ?? [], // Kurzform von obiger Zeile
            CaloriesPerServing = viewModel.CaloriesPerServing,
            MealType = [viewModel.MealType.ToString()],
            PrepTimeMinutes = viewModel.PrepTimeMinutes,
            CookTimeMinutes = viewModel.CookTimeMinutes,
            Cuisine = viewModel.Cuisine.ToString(),
            Difficulty = viewModel.Difficulty,
            Rating = viewModel.Rating,
            Servings = viewModel.Servings,
            Tags = viewModel.Tags?.Split(',') ?? [],
        };
    }
}
