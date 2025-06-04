using BusinessModel;
using BusinessModel.Data;
using BusinessModel.Services;
using Microsoft.AspNetCore.Identity;

namespace DemoMvcAuthApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // In Memory Demo
        //builder.Services.AddInMemoryRecipeConfiguration();

        // Local DB Demo
        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddLocalDbRecipeConfiguration(connectionString);

        // File Upload Konfiguration
        var config = builder.Configuration.GetSection("FileService");
        builder.Services.Configure<FileServiceOptions>(config);
        builder.Services.AddTransient<IFileService, RemoteFileService>();
        builder.Services.AddHttpClient();

        // Registrierungen fuer Benutzerverwaltung
        // AddIdentity ist generisch, weil wir somit diese Tabellen mit eigenen Properties erweitern koennten
        // AddIdentity stellt uns den UserManager und SignInManager bereit
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<DemoMvcDbContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
