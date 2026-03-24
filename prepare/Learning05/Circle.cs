public class Circle : Shape
{
    private double _radius = 1;

    public Circle(double radius = 1, string color = "blue") : base(color)
    {
        SetRadius(radius);
    }

    public Circle(string color = "blue", double radius = 1) : base(color)
    {
        SetRadius(radius);
    }

    public Circle() : base("blue")
    {
        
    }

    private void SetRadius(double radius)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(GetRadius(), 2);
    }

    private double GetRadius()
    {
        return _radius;
    }
}