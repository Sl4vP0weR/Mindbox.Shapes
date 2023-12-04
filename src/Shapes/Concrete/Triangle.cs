namespace Mindbox.Shapes.Concrete;

/// <summary>
/// Shape with 3 vertices.
/// </summary>
public sealed class Triangle : Polygon, ITyped<TriangleType>
{
    public Triangle(Vector2 a, Vector2 b, Vector2 c) : base([a, b, c])
    {
        var ec = Hypotenuse = Edges.Max();
        var (ea, eb) = Edges.Except(Hypotenuse, 1);
        Catheti = new(ea, eb);
        IsValid = ea + eb > ec && ea + ec > eb && eb + ec > ea;
    }

    public override bool IsValid { get; }
    
    private TriangleType? type;
    public new TriangleType Type
    {
        get
        {
            if (type.HasValue) return type.Value; // cached

            type = TriangleType.None;

            var (a, b, c) = this;

            if (a.Equals(b))
                type |= TriangleType.Isosceles;

            var distinctEdges = Edges.Distinct().Count();

            var catethiSqr = a.Sqr() + b.Sqr();
            var hypotenuseSqr = c.Sqr();

            if (hypotenuseSqr > catethiSqr) // с^2 > a^2 + b^2
                type |= TriangleType.Obtuse;

            if (hypotenuseSqr.Equals(catethiSqr)) // с^2 == a^2 + b^2
                type |= TriangleType.Rectangular;

            if (hypotenuseSqr < catethiSqr) // с^2 > a^2 + b^2
                type |= TriangleType.Acute;

            return type!.Value;
        }
    }
    public bool Is(TriangleType type) => Type.HasFlag(type);

    public static (Vector2 a, Vector2 b, Vector2 c) GetVerticesFromEdges(double a, double b, double c)
    {
        var cosAngleC = (a.Sqr() + c.Sqr() - b.Sqr()) / (2 * a * c);
        var sinAngleC = (1 - cosAngleC.Sqr()).Sqrt();

        return ((0, 0), (a, 0), (c * cosAngleC, c * sinAngleC));
    }

    /// <summary>
    /// Other two edges(legs) of the triangle, except <see cref="Hypotenuse"/>.
    /// </summary>
    public Catheti Catheti { get; }

    /// <summary>
    /// Longest edge of the triangle.
    /// </summary>
    public double Hypotenuse { get; }

    /// <summary>
    /// Deconstruct triangle to its edges.
    /// </summary>
    /// <param name="a">First cathetus.</param>
    /// <param name="b">Second cathetus.</param>
    /// <param name="c"><see cref="Hypotenuse"/>.</param>
    public void Deconstruct(out double a, out double b, out double c)
    {
        a = Catheti.A;
        b = Catheti.B;
        c = Hypotenuse;
    }

    /// <summary>
    /// Use edge length for each length of the new triangle.
    /// </summary>
    public static Triangle Regular(double edge) =>
        WithEdges(edge, edge, edge);
    
    /// <summary>
    /// Use arguments as edges of the new triangle.
    /// </summary>
    public static Triangle WithEdges(double ab, double bc, double ca)
    {
        var (a, b, c) = GetVerticesFromEdges(ab, bc, ca);
        
        return WithVertices(a, b, c);
    }
    
    /// <summary>
    /// Use arguments as vertices of the new triangle.
    /// </summary>
    public static Triangle WithVertices(Vector2 a, Vector2 b, Vector2 c) =>
        new (a, b, c);
}