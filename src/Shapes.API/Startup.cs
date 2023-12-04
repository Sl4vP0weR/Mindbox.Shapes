namespace Mindbox.Shapes.API;

public class Startup : IApplicationConfigurator
{
    public virtual bool UseSwagger { get; set; }
    public WebApplication App { get; private set; }
    public WebApplicationBuilder Host { get; private set; }

    public virtual void Configure(WebApplicationBuilder host)
    {
        Host = host;
        var services = host.Services;

        services.AddOutputCache();

        services.AddEndpointsApiExplorer();

        services.AddHttpContextAccessor();

        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblies(typeof(Program).Assembly);
        });

        services.AddMemoryCache(opt => { });

        services.AddControllers();

        if (UseSwagger)
            SwaggerStartup.Configure(services);
    }

    public virtual void Setup(WebApplication app)
    {
        App = app;

        app.UseHttpsRedirection();

        app.UseOutputCache();

        if (UseSwagger)
            SwaggerStartup.Setup(app);
    }
}
