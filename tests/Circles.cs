using static Mindbox.Shapes.Concrete.Circle;

namespace Mindbox.Tests;

[TestFixture]
internal partial class Circles
{
    private class Abstraction
    {
        public virtual Circle Shape { get; }
    }
    
    private class Radius_4 : Abstraction
    {
        public override Circle Shape { get; } = WithRadius(4);

        public const double
            ExpectedArea = 50.26548245743669,
            ExpectedPerimeter = 25.132741228718345;
        
        [Test(ExpectedResult = 8)]
        public double Diameter() => Shape.Diameter;
        
        [Test(ExpectedResult = ExpectedArea)]
        public double Area() => Shape.Area;
        
        [Test(ExpectedResult = ExpectedPerimeter)]
        public double Perimeter() => Shape.Perimeter;
    }
    
    private class Diameter_8 : Radius_4
    {
        public override Circle Shape { get; } = WithDiameter(8);
        
        [Test(ExpectedResult = 4)]
        public double Radius() => Shape.Radius;
    }
    
    private class Radius_77 : Abstraction
    {
        public override Circle Shape { get; } = WithRadius(77);

        public const double
            ExpectedArea = 18626.502843133883,
            ExpectedPerimeter = 483.80526865282815;
        
        [Test(ExpectedResult = 154)]
        public double Diameter() => Shape.Diameter;
        
        [Test(ExpectedResult = ExpectedArea)]
        public double Area() => Shape.Area;
        
        [Test(ExpectedResult = ExpectedPerimeter)]
        public double Perimeter() => Shape.Perimeter;
        
        [Test(ExpectedResult = 77)]
        public double WithArea_Same_Radius() => WithArea(Shape.Area).Radius;

        [Test(ExpectedResult = 77)]
        public double WithPerimeter_Same_Radius() => WithPerimeter(Shape.Perimeter).Radius;
    }
    
    private class Radius_0 : Abstraction
    {
        public override Circle Shape { get; } = WithRadius(0);

        [Test(ExpectedResult = false, Description = "Check if circle with radius 0 is invalid.")]
        public bool IsInvalid() => Shape.IsValid;
    }
    
    private class Radius_Negative_1
    {
        void ThrowException() => WithRadius(-1);
        
        [Test]
        public void ThrowsException() => Assert.Throws<ArgumentOutOfRangeException>(ThrowException);
    }
}