namespace HHTask.Library.UnitTests;

public class ShapeTests
{
    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(6, 8, 10, 24)]
    [InlineData(6, 9, 10, 26.66341D)]
    public void TriangleArea_ShouldReturnsCorrectArea(double aSide, double bSize, double cSize, double expected)
    {
        // arrange
        Shape triangle = new Triangle("Triangle", aSide, bSize, cSize);

        // act
        double actualArea = triangle.GetArea();

        // assert
        Assert.InRange(actualArea, expected - 0.01D, expected + 0.01D);
    }

    [Theory]
    [InlineData(0, 4, 5)]
    [InlineData(3, 0, 5)]
    [InlineData(3, 4, 0)]
    public void TriangleArea_ShouldThrowException_WhenSidesNegative(double aSide, double bSide, double cSide)
    {
        // act & assert 
        Assert.Throws<ArgumentException>(() => { new Triangle("Triangle 1", aSide, bSide, cSide); });
    }

    [Theory]
    [InlineData(123, 4, 5)]
    [InlineData(123, 34, 5)]
    [InlineData(3, 34, 18)]
    public void TriangleArea_ShouldThrowException_WhenSidesInvalid(double aSide, double bSide, double cSide)
    {
        // act & assert
        Assert.Throws<ArgumentException>(() => { new Triangle("Triangle", aSide, bSide, cSide); });
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 8, 10, true)]
    [InlineData(6, 9, 10, false)]
    public void TriangleArea_ShouldReturnsTrue_WhenTriangleRight(double aSide, double bSide, double cSide, bool isRightExpected)
    {
        // arrange
        Triangle triangle = new Triangle("Triangle", aSide, bSide, cSide);
        
        // act
        bool isRightActual = triangle.IsRight();

        // act & arrange
        Assert.Equal(isRightExpected, isRightActual);
    }

    [Theory]
    [InlineData(1, 3.141593D)]
    [InlineData(6, 113.097336D)]
    public void CircleArea_ShouldReturnsCorrectArea(double radius, double expected)
    {
        // arrange
        Shape circle = new Circle("Circle", radius);
        
        // act
        double actual = circle.GetArea();
        
        // assert
        Assert.Equal(expected, actual);
    } 
    
    [Theory]
    [InlineData(0)]
    [InlineData(-12)]
    public void CircleArea_ShouldThrowException_WhenRadiusNegativeOrNull(double radius)
    {
        // act & assert
        Assert.Throws<ArgumentException>(() => { new Circle("Circle", radius); });
    }
}