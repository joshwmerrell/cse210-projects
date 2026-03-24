public class Rectangle : Shape
{
    private double _length;
    private double _width;

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