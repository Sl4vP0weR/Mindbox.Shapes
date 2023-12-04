namespace Mindbox.Shapes.API.Mediator.Handlers;

public record CalculateCircleHandler : IRequestHandler<CalculateCircleRequest, Circle>
{
    private readonly IMemoryCache cache;
    public CalculateCircleHandler(IMemoryCache cache)
    {
        this.cache = cache;
    }
    public virtual Circle Handle(CalculateCircleRequest request)
    {
        if (cache.TryGetValue(request, out Circle result))
            return result;
        
        return cache.GetOrCreate(request, (entry) => request switch
        {
            { Radius: { } radius and > 0 } => 
                Circle.WithRadius(radius),

            { Diameter: { } diameter and > 0 } => 
                Circle.WithDiameter(diameter),

            { Perimeter: { } perimeter and > 0 } => 
                Circle.WithPerimeter(perimeter),
            
            { Area: { } area and > 0 } => 
                Circle.WithArea(area),

            _ => new()
        });
    }
    public Task<Circle> Handle(CalculateCircleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Handle(request));
}
