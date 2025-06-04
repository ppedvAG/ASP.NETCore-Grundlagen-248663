using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessModel;

// Klassen fuer Extensions muessen static sein
public static class SetupExtensions
{
    // Wir geben IServiceCollection wieder zuruck, damit wir sie chainen (verketten) koennen
    // Eine Methode wird zur Extension Methode durch das this Keyword und durch static
    public static IServiceCollection AddInMemoryRecipeConfiguration(this IServiceCollection services)
    {
        // Wir registrieren das als Singleton, weil wir die Rezpte InMemory halten. 
        // Sonst wuerden neue Rezepte wieder verschwinden. Deshalb zu Testzwecken ein Singleton.
        services.AddSingleton<IRecipeService, SimpleRecipeService>(); 
        return services;
    }

    public static void AddLocalDbRecipeConfiguration(this IServiceCollection services, string connectionString)
    {
        services.AddSqlServer<DemoMvcDbContext>(connectionString);
        services.AddTransient<IRecipeService, RecipeService>(); 
    }
}
