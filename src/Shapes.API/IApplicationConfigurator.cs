namespace Mindbox.Shapes.API;

public interface IApplicationConfigurator
{
    void Setup(WebApplication app);
    void Configure(WebApplicationBuilder host);
}