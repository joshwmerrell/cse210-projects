public class Rectangle : Shape
{
    private double _length = 1;
    private double _width = 1;

    public Rectangle(double length = 1, double width = 1, string color = "red") : base(color)
    {
        SetLength(length);
        SetWidth(width);
    }

    public Rectangle(string color = "red", double length = 1, double width = 1) : base(color)
    {
        SetLength(length);
        SetWidth(width);
    }

    public Rectangle() : base("red")
    {
        
    }

    private void SetLength(double length)
    {
        _length = length;
    }

    private void SetWidth(double width)
    {
        _width = width;
    }

    public override double GetArea()
    {
        return GetLength() * GetWidth();
    }

    private double GetLength()
    {
        return _length;
    }

    private double GetWidth()
    {
        return _width;
    }
}