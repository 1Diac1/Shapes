namespace HHTask.Library;

public abstract class Shape
{
    public string Name { get; protected set; }

    protected Shape(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public abstract double GetArea();

    public override string ToString()
    {
        return $"(Shape type - {this.GetType().Name}); Name: {this.Name}; Area: {this.GetArea()}";
    }
}