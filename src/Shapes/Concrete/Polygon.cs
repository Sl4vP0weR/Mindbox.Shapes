using static System.Math;

namespace Mindbox.Shapes.Concrete;

/// <summary>
/// Shape with 3 or more vertices.
/// </summary>
public class Polygon : IShape2D, IEdges, IVertices<Vector2>, ITyped<PolygonType>
{
    public Polygon(IReadOnlyList<Vector2> vertices, bool enclose = true)
    {
        if (vertices.Count < 3)
            throw IncorrectVerticesCount;
        
        List<double> edges = new (vertices.Count);
        
        var a = vertices.First();
        for (var i = 1; i < vertices.Count; i++)
        {
            var b = vertices.ElementAt(i);
            edges.Add(a.Distance(b));
            a = b;
        }
        if(enclose)
            edges.Add(a.Distance(vertices.First()));

        Edges = edges.AsReadOnly();
        Vertices = vertices.ToArray().AsReadOnly();
        Perimeter = Edges.Sum();
        IsValid = enclose;
    }

    public static ArgumentOutOfRangeException IncorrectVerticesCount => new (nameof(Vertices));

    public virtual IReadOnlyList<Vector2> Vertices { get; }
    public virtual IReadOnlyList<double> Edges { get; }

    public virtual bool IsValid { get; }

    protected double? area;
    public virtual double Area
    {
        get
        {
            if (area.HasValue) return area.Value;
            
            var sum = 0d;

            var vertices = Vertices;
            var a = vertices[^1];

            for (var i = 0; i < vertices.Count; i++)
            {
                var b = vertices[i];
                sum += ((a.X + b.X) * (a.Y - b.Y)).Round();
                a = b;
            }
            
            return area ??= Abs(sum / 2).Round();
        }
    }

    public virtual double Perimeter { get; }
    
    private PolygonType? type;
    public PolygonType Type
    {
        get
        {
            if (type.HasValue) return type.Value;

            type = PolygonType.None;

            var distinctEdges = Edges.Distinct().Count();

            if (distinctEdges == 1)
                type |= PolygonType.Equilateral;

            if (distinctEdges == Edges.Count)
                type |= PolygonType.Scalene;

            return type!.Value;
        }
    }
    public bool Is(PolygonType type) => Type.HasFlag(type);
    
    public static Vector2[] GetVerticesFromLength(int verticesCount, double edgeLength = 1)
    {
        //edgeLength = edgeLength.Round();
        var radius = (edgeLength / (2 * Sin(PI / verticesCount)));
        
        var vertices = new Vector2[verticesCount];
        for (var i = 0; i < verticesCount; i++)
        {
            var angle = (2 * PI * i / verticesCount);
            var x = radius * Cos(angle);
            var y = radius * Sin(angle);
            vertices[i] = (x, y);
        }

        return vertices;
    }

    /// <summary>
    /// Create new regular polygon with <paramref name="verticesCount"/> and <paramref name="edgeLength"/>.
    /// </summary>
    public static Polygon Regular(int verticesCount, double edgeLength = 1) =>
        WithVertices(GetVerticesFromLength(verticesCount, edgeLength));
    
    /// <inheritdoc cref="WithVertices(System.Collections.Generic.IReadOnlyList{Mindbox.Shapes.Vector2})"/>
    public static Polygon WithVertices(params Vector2[] vertices) =>
        WithVertices(vertices as IReadOnlyList<Vector2>);

    /// <summary>
    /// Use arguments as vertices of the new polygon.
    /// </summary>
    /// <returns><see cref="Triangle"/> | <see cref="Tetragon"/> | <see cref="Polygon"/></returns>
    public static Polygon WithVertices(IReadOnlyList<Vector2> vertices) =>
        vertices switch
        {
            [var a, var b, var c] => (Polygon)Triangle.WithVertices(a, b, c),
            [var a, var b, var c, var d] => (Polygon)Tetragon.WithVertices(a, b, c, d),
            _ => new(vertices)
        };
}