namespace Mindbox.Shapes.API.Mediator.Requests;

public record CalculateTriangleRequest(
    double AB, 
    double BC, 
    double CA
) : IRequest<Triangle>;