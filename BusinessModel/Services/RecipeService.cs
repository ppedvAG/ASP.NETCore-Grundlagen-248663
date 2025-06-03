using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services;

public class RecipeService : IRecipeService
{
    private readonly DemoMvcDbContext _context;

    public RecipeService(DemoMvcDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recipe>> GetAll()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task<Recipe?> GetById(int id)
    {
        return await _context.Recipes.FindAsync(id);
    }

    public async Task<int> Create(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        return recipe.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);
        if (recipe == null)
        {
            return false;
        }

        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Recipe recipe)
    {
        var exists = await _context.Recipes.AnyAsync(r => r.Id == recipe.Id);
        if (!exists)
        {
            return false;
        }

        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
        return true;
    }
}
