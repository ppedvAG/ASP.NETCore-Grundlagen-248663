using BusinessModel;
using BusinessModel.Services;

namespace DemoMvcApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // In Memory Demo
        //builder.Services.AddInMemoryRecipeConfiguration();

        // File Upload Konfiguration
        var config = builder.Configuration.GetSection("FileService");
        builder.Services.Configure<FileServiceOptions>(config);
        builder.Services.AddTransient<IFileService, RemoteFileService>();
        builder.Services.AddHttpClient();

        // Local DB Demo
        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddLocalDbRecipeConfiguration(connectionString);

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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
