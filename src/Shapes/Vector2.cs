using System.Diagnostics;

namespace Mindbox.Shapes;

public record struct Vector2
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly double x;
    public double X
    {
        get => x;
        init => x = value.Round();
    }
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly double y;
    public double Y
    {
        get => y;
        init => y = value.Round();
    }
    
    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }
        
    public static implicit operator Vector2((double x, double y) tuple) => new(tuple.x, tuple.y);

    public static Vector2 operator +(Vector2 a, Vector2 b) => (a.X+b.X, a.Y+b.Y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => (a.X-b.X, a.Y-b.Y);
    public static Vector2 operator *(Vector2 a, Vector2 b) => (a.X*b.X, a.Y*b.Y);
    public static Vector2 operator /(Vector2 a, Vector2 b) => (a.X/b.X, a.Y/b.Y);

    public Vector2 Sqr() => (X.Sqr(), Y.Sqr());
    public Vector2 Sqrt() => (X.Sqrt(), Y.Sqrt());

    public double Distance(Vector2 other) => ((other.X - X).Sqr() + (other.Y - Y).Sqr()).Sqrt().Round();
    
    public void Deconstruct(out double x, out double y)
    {
        x = X;
        y = Y;
    }

    public override string ToString() => $"({X}, {Y})";
}