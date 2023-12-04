namespace Mindbox.Shapes.API.Controllers;

[ControllerRoute("shapes")]
[ControllerName("Shapes Calculation")]
[OutputCache]
public class ShapesCalculationController : Controller
{
    private readonly IMediator Mediator;
    public ShapesCalculationController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private async Task<IActionResult> Calculate<TRequest>(TRequest request) => Ok(await Mediator.Send(request));
    public async Task<IActionResult> CalculateMany<TRequest>(TRequest[] requests)
    {
        var tasks = requests
            .Select(x => Mediator.Send(x))
            .ToList();
        return Ok(await Task.WhenAll(tasks));
    }

    /// <summary>
    /// Calculates one circle.
    /// </summary>
    [HttpGet("circle")]
    public Task<IActionResult> CalculateCircle([FromQuery] CalculateCircleRequest request) => 
        Calculate(request);

    /// <summary>
    /// Calculates many circles.
    /// </summary>
    [HttpPost("circles")]
    public Task<IActionResult> CalculateCircles([FromBody] CalculateCircleRequest[] requests) =>
        CalculateMany(requests);
    
    /// <summary>
    /// Calculates one triangle.
    /// </summary>
    [HttpGet("triangle")]
    public Task<IActionResult> CalculateTriangle([FromQuery] CalculateTriangleRequest request) => 
        Calculate(request);

    /// <summary>
    /// Calculates many triangles.
    /// </summary>
    [HttpPost("triangles")]
    public Task<IActionResult> CalculateTriangles([FromBody] CalculateTriangleRequest[] requests) =>
        CalculateMany(requests);
}
