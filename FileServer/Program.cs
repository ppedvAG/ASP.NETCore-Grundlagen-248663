
using FileServer.Middlewares;
using Microsoft.Extensions.FileProviders;

namespace FileServer
{
    public class Program
    {
        public const string FILE_PATH = "files";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var fileProvider = InitFileProvider(builder.Environment, FILE_PATH);

            // Zugriff auf Dateien auf Server erlauben
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = fileProvider,
                RequestPath = $"/{FILE_PATH}"
            });

            // Zum Anzeigen der Dateien im Browser
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = fileProvider,
                RequestPath = $"/{FILE_PATH}"
            });

            app.UseSecuredAccess();

            app.MapPost("/upload", Upload);

            app.Run();
        }

        private static PhysicalFileProvider InitFileProvider(IWebHostEnvironment environment, string path)
        {
            var rootPath = Path.Combine(environment.ContentRootPath, path);
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            return new PhysicalFileProvider(rootPath);
        }

        private static async Task<IResult> Upload(HttpContext context)
        {
            var file = context.Request.Form.Files.FirstOrDefault();
            if (file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), FILE_PATH, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                    var url = $"{context.Request.Scheme}://{context.Request.Host.Value}/{FILE_PATH}/{file.FileName}";
                    return Results.Content(url, "text/plain");
                }
            }

            return Results.BadRequest("No files were uploaded.");
        }
    }
}
