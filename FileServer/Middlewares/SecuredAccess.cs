namespace FileServer.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecuredAccess
    {
        private readonly RequestDelegate _next;

        // Einfachfaches Beispiel: Natuerlich sollten wir den ApiKey hier nicht hart codieren
        public const string ApiKey = "7F12CA09-0EE3-461B-8BA2-3059E3A855CD";

        public SecuredAccess(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "GET"
                || context.Request.Headers.TryGetValue("X-API-KEY", out var extractedKey)
                && extractedKey.ToString().Equals(ApiKey, StringComparison.OrdinalIgnoreCase))
            {
                if (!await CheckForScriptTags(context))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Script tags are not allowed");
                }

            }
            else
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Missing or invalid API-Key");
            }
        }

        private static async Task<bool> CheckForScriptTags(HttpContext httpContext)
        {
            var fileContent = httpContext.Request.Form.Files.FirstOrDefault()?.OpenReadStream();

            if (fileContent != null)
            {
                var ext = Path.GetExtension(httpContext.Request.Form.Files.FirstOrDefault()!.FileName);
                if (!ext.Equals(".html", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                var content = await new StreamReader(fileContent).ReadToEndAsync();
                return content.Contains("<script>");
            }

            return false;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SecuredAccessExtensions
    {
        public static IApplicationBuilder UseSecuredAccess(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecuredAccess>();
        }
    }
}
