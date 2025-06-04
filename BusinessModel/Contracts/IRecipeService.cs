using BusinessModel.Models;
using System.Threading;

namespace BusinessModel.Contracts;

public interface IRecipeService
{
    Task<int> Create(Recipe recipe);
    Task<int> CreateWithImage(Recipe recipe, string fileName, Stream stream, CancellationToken cancellationToken = default);
    Task<bool> Delete(int id);
    Task<IEnumerable<Recipe>> GetAll();
    Task<Recipe?> GetById(int id);
    Task<bool> Update(Recipe recipe);
}