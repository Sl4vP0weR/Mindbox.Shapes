namespace Mindbox.Shapes.API;

public class ControllerRouteAttribute : RouteAttribute
{
    public ControllerRouteAttribute(string name) : base($"api/{name}/")
    {

    }
}