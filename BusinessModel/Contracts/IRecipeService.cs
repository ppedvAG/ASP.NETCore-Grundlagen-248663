using BusinessModel.Models;

namespace BusinessModel.Contracts;

public interface IRecipeService
{
    Task<int> Create(Recipe recipe);
    Task<bool> Delete(int id);
    Task<IEnumerable<Recipe>> GetAll();
    Task<Recipe?> GetById(int id);
    Task<bool> Update(Recipe recipe);
}