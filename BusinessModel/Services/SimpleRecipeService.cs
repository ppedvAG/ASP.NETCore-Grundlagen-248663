using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;

namespace BusinessModel.Services;

/// <summary>
/// Service welcher den Datenbankzugriff simulieren soll, vgl. <see cref="https://de.wikipedia.org/wiki/Repository_(Entwurfsmuster)"/>.
/// Dieser Service bildet CRUD Operationen auf die Recipes ab, <see cref="https://de.wikipedia.org/wiki/CRUD"/>.
/// </summary>
public class SimpleRecipeService : IRecipeService
{
    private readonly List<Recipe> _recipes = RecipeReader.FromJsonFile() ?? new List<Recipe>();

    public Task<IEnumerable<Recipe>> GetAll()
    {
        return Task.FromResult(_recipes.AsEnumerable());
    }

    public Task<Recipe?> GetById(int id)
    {
        return Task.FromResult(_recipes.FirstOrDefault(r => r.Id == id));
    }

    public Task Create(Recipe recipe)
    {
        recipe.Id = _recipes.Max(r => r.Id) + 1;

        _recipes.Insert(0, recipe);
        return Task.CompletedTask;
    }

    public Task<bool> Update(Recipe recipe)
    {
        var index = _recipes.FindIndex(r => r.Id == recipe.Id);
        if (index > 0)
        {
            _recipes[index] = recipe;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> Delete(int id)
    {
        var index = _recipes.FindIndex(r => r.Id == id);
        if (index > 0)
        {
            _recipes.RemoveAt(index);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
