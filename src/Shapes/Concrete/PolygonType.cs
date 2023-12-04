using System.Text.Json.Serialization;

namespace Mindbox.Shapes.Concrete;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PolygonType
{
    None = 0,
    /// All edges are equal
    Equilateral = 1 << 1,
    /// All edges are distinct
    Scalene = 1 << 2
}