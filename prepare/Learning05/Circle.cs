public class Circle : Shape
{
    private double _radius;

    public Circle(double radius = 1, string color = "blue") : base(color)
    {
        SetRadius(radius);
    }

    public Circle(string color = "blue", double radius = 1) : base(color)
    {
        SetRadius(radius);
    }

    private void SetRadius(double radius)
    {
        _radius = radius;
    }
}