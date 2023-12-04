using static System.Math;

namespace Mindbox.Shapes.Concrete;

/// <summary>
/// Represents circle shape. <br/>Calculated by radius.
/// </summary>
public sealed class Circle : IShape2D
{
    public Circle(double radius = 0)
    {
        Radius = radius = radius.Round();
        
        if (radius < 0)
            throw IncorrectRadiusException;

        var diameter = radius * 2;
        Diameter = diameter;
        
        Area = PI * radius.Sqr();
        Perimeter = PI * diameter;
        IsValid = radius > 0;
    }

    private Exception IncorrectRadiusException =>
        new ArgumentOutOfRangeException(nameof(Radius), 
            "Circle radius only accepts value of [0..+infinity].\nTry using Math.Abs.");
    
    /// <summary>
    /// Is circle valid. <br/>Radius should be greater than zero to be valid.
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    /// Distance from the center of a circle to it's boundary.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Distance across the circle. <br/>Basically <see cref="Radius"/> * 2
    /// </summary>
    public double Diameter { get; }
    
    public double Area { get; }

    public double Perimeter { get; }

    /// <summary>
    /// Use <see cref="Diameter"/> as a base of the new circle.
    /// </summary>
    public static Circle WithDiameter(double diameter) => 
        WithRadius(diameter / 2);
    
    /// <summary>
    /// Use <see cref="Area"/> as a base of the new circle.
    /// </summary>
    public static Circle WithArea(double area) => 
        WithRadius((area / PI).Sqrt());
    
    /// <summary>
    /// Use <see cref="Perimeter"/> as a base of the new circle.
    /// </summary>
    public static Circle WithPerimeter(double perimeter) => 
        WithRadius(perimeter / PI / 2);
    
    /// <summary>
    /// Use <see cref="Radius"/> as base of the new circle.
    /// </summary>
    public static Circle WithRadius(double radius) => 
        new(radius);
}