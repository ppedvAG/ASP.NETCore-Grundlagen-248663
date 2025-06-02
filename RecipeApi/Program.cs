
using BusinessModel.Contracts;
using BusinessModel.Services;

namespace RecipeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Wir registrieren das als Singleton, weil wir die Rezpte InMemory halten. 
            // Sonst wuerden neue Rezepte wieder verschwinden. Deshalb zu Testzwecken ein Singleton.
            builder.Services.AddSingleton<IRecipeService, SimpleRecipeService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
