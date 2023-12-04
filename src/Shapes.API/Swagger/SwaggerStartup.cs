using Microsoft.OpenApi.Models;

namespace Mindbox.Shapes.API;

public static class SwaggerStartup
{
    public const string
        Title = "Mindbox Shapes",
        Description = "Mindbox shapes calculation API.",
        Version = "v1";

    public static void Configure(IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc(
                    Version,
                    new OpenApiInfo()
                    {
                        Title = Title,
                        Description = Description,
                        Version = Version
                    });
            TryIncludeXmlComments(opt);
        });
    }

    public static void Setup(WebApplication app, string route = "swagger")
    {
        app.UseSwagger(opt =>
        {
            opt.RouteTemplate = "api/{documentName}/swagger.json";
        });
        app.UseSwaggerUI(opt =>
        {
            opt.SwaggerEndpoint($"/api/{Version}/swagger.json", Version);
            opt.DocumentTitle = Title;
            opt.RoutePrefix = route;
        });
    }

    private static void TryIncludeXmlComments(SwaggerGenOptions opt)
    {
        var fileName = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "xml");
        var filePath = Path.Combine(AppContext.BaseDirectory, fileName);

        if (File.Exists(filePath))
            opt.IncludeXmlComments(filePath);
    }
}