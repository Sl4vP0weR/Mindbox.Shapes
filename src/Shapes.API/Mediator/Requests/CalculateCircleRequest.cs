namespace Mindbox.Shapes.API.Mediator.Requests;

public record CalculateCircleRequest(
    double? Radius,
    double? Area,
    double? Perimeter,
    double? Diameter
) : IRequest<Circle>;