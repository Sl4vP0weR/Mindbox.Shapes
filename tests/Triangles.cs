using static Mindbox.Shapes.Concrete.Triangle;

namespace Mindbox.Tests;

partial class Polygons
{
    [TestFixture]
    internal partial class Triangles
    {
        private class Regular
        {
            public Triangle Shape { get; } = Regular(1);

            [Test(ExpectedResult = 0.43301270189221902)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 3)]
            public double Perimeter() => Shape.Perimeter;

            [Test(ExpectedResult = true)]
            public bool Equilateral() => Shape.Is(PolygonType.Equilateral);
            
            [Test(ExpectedResult = true)]
            public bool Isosceles() => Shape.Is(TriangleType.Isosceles);
        }
        
        private class Edges_2_3_4
        {
            public Triangle Shape { get; } = WithEdges(2, 3, 4);
            
            [Test]
            public void Catheti() => Assert.AreEqual(Shape.Catheti, new Catheti(2, 3));

            [Test(ExpectedResult = 2.904737509655562)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 9)]
            public double Perimeter() => Shape.Perimeter;

            [Test(ExpectedResult = true)]
            public bool Scalene() => Shape.Is(PolygonType.Scalene);

            [Test(ExpectedResult = false)]
            public bool NotEquilateral() => Shape.Is(PolygonType.Equilateral);
            
            [Test(ExpectedResult = true)]
            public bool Obtuse() => Shape.Is(TriangleType.Obtuse);
        }

        private class Edges_4_5_6
        {
            public Triangle Shape { get; } = WithEdges(4, 5, 6);
            
            [Test]
            public void Catheti() => Assert.AreEqual(Shape.Catheti, new Catheti(4, 5));

            [Test(ExpectedResult = 9.921567416492214)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 15)]
            public double Perimeter() => Shape.Perimeter;

            [Test(ExpectedResult = true)]
            public bool Scalene() => Shape.Is(PolygonType.Scalene);

            [Test(ExpectedResult = false)]
            public bool NotEquilateral() => Shape.Is(PolygonType.Equilateral);
            
            [Test(ExpectedResult = true)]
            public bool Acute() => Shape.Is(TriangleType.Acute);
        }

        private class Edges_3_4_5
        {
            public Triangle Shape { get; } = WithEdges(3, 4, 5);

            [Test]
            public void Catheti() => Assert.AreEqual(Shape.Catheti, new Catheti(3, 4));

            [Test(ExpectedResult = 6)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 12)]
            public double Perimeter() => Shape.Perimeter;
            
            [Test(ExpectedResult = true)]
            public bool Rectangular() => Shape.Is(TriangleType.Rectangular);

            [Test(ExpectedResult = true)]
            public bool Scalene() => Shape.Is(PolygonType.Scalene);

            [Test(ExpectedResult = false)]
            public bool NotEquilateral() => Shape.Is(PolygonType.Equilateral);
        }

        private class Edges_1_2_3
        {
            public Triangle Shape { get; } = WithEdges(1, 2, 3);
            
            [Test]
            public void Catheti() => Assert.AreEqual(Shape.Catheti, new Catheti(1, 2));
            
            [Test(ExpectedResult = 0)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 6)]
            public double Perimeter() => Shape.Perimeter;

            [Test(ExpectedResult = false, Description = "Check if triangle is invalid.")]
            public bool IsInvalid() => Shape.IsValid;

            [Test(ExpectedResult = true)]
            public bool Scalene() => Shape.Is(PolygonType.Scalene);

            [Test(ExpectedResult = false)]
            public bool NotEquilateral() => Shape.Is(PolygonType.Equilateral);
        }
    }
}