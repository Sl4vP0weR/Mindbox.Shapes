namespace Mindbox.Shapes.Concrete;

/// <summary>
/// <inheritdoc cref="Tetragon"/><br/>
/// Calculated by width and height.
/// </summary>
public sealed class Rectangle : Tetragon
{
    public Rectangle(double width, double height) : base(GetVerticesFromEdges(width, height).ToArray())
    {
        Width = width;
        Height = height;
        Area = width * height;
    }

    public double Width { get; init; }
    public double Height { get; init; }

    public override double Area { get; }

    /// <summary>
    /// Use length of every edge for the new rectangle(square).
    /// </summary>
    public static Rectangle WithEdges(double length) => WithEdges(length, length);

    /// <summary>
    /// Use width and height as edges of the new rectangle.
    /// </summary>
    public static Rectangle WithEdges(double width, double height) =>
        new(width, height);
    
    public static (Vector2 a, Vector2 b, Vector2 c, Vector2 d) GetVerticesFromEdges(double width, double height) =>
    (
        (0, 0),
        (0, height),
        (width, height),
        (width, 0)
    );
}