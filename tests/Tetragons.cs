using static Mindbox.Shapes.Concrete.Tetragon;

namespace Mindbox.Tests;

partial class Polygons
{
    [TestFixture]
    internal partial class Tetragons
    {   
        private class Square
        {
            public Rectangle Shape { get; } = Rectangle.WithEdges(1);
    
            [Test(ExpectedResult = 1)]
            public double Area() => Shape.Area;
        
            [Test(ExpectedResult = 4)]
            public double Perimeter() => Shape.Perimeter;
        }
    
        private class Rect_2x1
        {
            public Rectangle Shape { get; } = Rectangle.WithEdges(2, 1);
    
            [Test(ExpectedResult = 2)]
            public double Area() => Shape.Area;
        
            [Test(ExpectedResult = 6)]
            public double Perimeter() => Shape.Perimeter;
            
            [Test(ExpectedResult = 2)]
            public double Width() => Shape.Width;
        
            [Test(ExpectedResult = 1)]
            public double Height() => Shape.Height;
        
            [Test(ExpectedResult = false)]
            public bool NotEquilateral() => Shape.Is(PolygonType.Equilateral);
        }
    
        private class Rhombus
        {
            public Tetragon Shape { get; } = WithVertices((0, 0), (1, 2), (2, 0), (1, -2));

            [Test(ExpectedResult = 4)]
            public double Area() => Shape.Area;
        
            [Test(ExpectedResult = 8.9442719099991592)]
            public double Perimeter() => Shape.Perimeter;
        
            [Test(ExpectedResult = true)]
            public bool Equilateral() => Shape.Is(PolygonType.Equilateral);
        }
    }
}