using static Mindbox.Shapes.Concrete.Polygon;

namespace Mindbox.Tests;

[TestFixture]
internal partial class Polygons
{
    private void ThrowException_Vertices_0() => WithVertices();
    private void ThrowException_Vertices_1() => WithVertices((0,0));
    private void ThrowException_Vertices_2() => WithVertices((0,0), (0,1));

    [Test]
    public void InvalidVerticesCount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(ThrowException_Vertices_0);
        Assert.Throws<ArgumentOutOfRangeException>(ThrowException_Vertices_1);
        Assert.Throws<ArgumentOutOfRangeException>(ThrowException_Vertices_2);
        Assert.DoesNotThrow(() =>
        {
            Assert.IsAssignableFrom(typeof(Triangle), WithVertices(
                (0,0), 
                (0,1), 
                (1,1))
            );
            Assert.IsAssignableFrom(typeof(Tetragon), WithVertices(
                (0,0), 
                (0,1), 
                (1,1), 
                (1,0))
            );
        });
    }
}