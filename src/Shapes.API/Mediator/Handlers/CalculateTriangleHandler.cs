namespace Mindbox.Shapes.API.Mediator.Handlers;

public record CalculateTriangleHandler : IRequestHandler<CalculateTriangleRequest, Triangle>
{
    private readonly IMemoryCache cache;
    public CalculateTriangleHandler(IMemoryCache cache)
    {
        this.cache = cache;
    }
    public virtual Triangle Handle(CalculateTriangleRequest request)
    {
        if (cache.TryGetValue(request, out Triangle result))
            return result;
        
        return cache.GetOrCreate(request, (entry) =>
        {
            var (ab, bc, ca) = request;
            return Triangle.WithEdges(ab, bc, ca);
        });
    }
    public Task<Triangle> Handle(CalculateTriangleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Handle(request));
}
