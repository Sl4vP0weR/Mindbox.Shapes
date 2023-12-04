using static Mindbox.Shapes.Concrete.Polygon;

namespace Mindbox.Tests;

partial class Polygons
{
    [TestFixture]
    private class Regular
    {
        private abstract class Abstraction
        {
            public abstract Polygon Shape { get; }
        
            [Test(ExpectedResult = true)]
            public bool Equilateral() => Shape.Is(PolygonType.Equilateral);
        }
        
        private class Pentagon : Abstraction
        {
            public override Polygon Shape { get; } = Regular(5);

            [Test(ExpectedResult = 1.720477400588968)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 5)]
            public double Perimeter() => Shape.Perimeter;
        }

        private class Hexagon : Abstraction
        {
            public override Polygon Shape { get; } = Regular(6);

            [Test(ExpectedResult = 2.598076211353316)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 6)]
            public double Perimeter() => Shape.Perimeter;
        }

        private class Heptagon : Abstraction
        {
            public override Polygon Shape { get; } = Regular(7);

            [Test(ExpectedResult = 3.633912444001588)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 7)]
            public double Perimeter() => Shape.Perimeter;
        }

        private class Octagon : Abstraction
        {
            public override Polygon Shape { get; } = Regular(8);

            [Test(ExpectedResult = 4.8284271247461881)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 8)]
            public double Perimeter() => Shape.Perimeter;
        }

        private class Nonagon : Abstraction
        {
            public override Polygon Shape { get; } = Regular(9);

            [Test(ExpectedResult = 6.1818241937729024)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 9)]
            public double Perimeter() => Shape.Perimeter;
        }

        private class Decagon : Abstraction
        {
            public override Polygon Shape { get; } = Regular(10);

            [Test(ExpectedResult = 7.6942088429381359)]
            public double Area() => Shape.Area;

            [Test(ExpectedResult = 10)]
            public double Perimeter() => Shape.Perimeter;
        }
    }
}