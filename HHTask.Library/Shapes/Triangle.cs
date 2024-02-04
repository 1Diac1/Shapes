namespace HHTask.Library.Shapes;

public class Triangle : Shape
{
    public double ASide { get; }
    public double BSide { get; }
    public double CSide { get; }
    
    public Triangle(string name, double aSide, double bSide, double cSide) 
        : base(name)
    {
        ASide = aSide;
        BSide = bSide;
        CSide = cSide;

        if (ASide <= 0 || BSide <= 0 || CSide <= 0)
            throw new ArgumentException("Sides must be positive");
            
        if (IsExist() is false)
            throw new ArgumentException("Such a triangle doesn't exist");
    }
    
    public bool IsRight()
    {
        return Math.Pow(ASide, 2) + Math.Pow(BSide, 2) == Math.Pow(CSide, 2) ||
               Math.Pow(ASide, 2) + Math.Pow(CSide, 2) == Math.Pow(BSide, 2) ||
               Math.Pow(BSide, 2) + Math.Pow(CSide, 2) == Math.Pow(ASide, 2);
    }
    
    public override double GetArea()
    {
        // Heron's formula
        double per = (ASide + BSide + CSide) / 2;
        double area = Math.Sqrt(per * (per - ASide) * (per - BSide) * (per - CSide));

        return Math.Round(area, 5);
    }

    public override string ToString()
    {
        return $"{base.ToString()}. Is triangle right: {IsRight()}";
    }
    
    private bool IsExist()
    {
        return (ASide + BSide) > CSide &&
               (BSide + CSide) > ASide &&
               (CSide + ASide) > BSide;
    }

}