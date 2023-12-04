using System.Text.Json.Serialization;

namespace Mindbox.Shapes.Concrete;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TriangleType
{
    None = 0,
    /// a = b
    Isosceles = 1 << 1,
    /// с^2 > a^2 + b^2
    Obtuse = 1 << 2,
    /// с^2 = a^2 + b^2
    Rectangular = 1 << 3,
    /// с^2 > a^2 + b^2
    Acute = 1 << 4
}