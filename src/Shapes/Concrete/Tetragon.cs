namespace Mindbox.Shapes.Concrete;

/// <summary>
/// Shape with 4 vertices. (Quadrilateral)
/// </summary>
public class Tetragon : Polygon
{
    protected Tetragon(IReadOnlyList<Vector2> vertices) : base(vertices) { }
    public Tetragon(Vector2 a, Vector2 b, Vector2 c, Vector2 d) : this([a, b, c, d]) { }

    /// <summary>
    /// Use arguments as vertices of the new tetragon.
    /// </summary>
    public static Tetragon WithVertices(Vector2 a, Vector2 b, Vector2 c, Vector2 d) =>
        new(a, b, c, d);
}