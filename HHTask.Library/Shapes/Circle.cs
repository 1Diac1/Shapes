namespace HHTask.Library.Shapes;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string name, double radius)
        : base(name)
    {
        Radius = radius;

        if (Radius <= 0)
            throw new ArgumentException("Radius must be positive");
    }

    public override double GetArea()
    {
        double area = Math.Pow(Radius, 2) * Math.PI;
        
        return Math.Round(area, 6);
    }
}