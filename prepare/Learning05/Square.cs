public class Square : Shape
{
    private double _side;

    public Square(double side = 1, string color = "yellow") : base(color)
    {
        SetSide(side);
    }

    public Square(string color = "yellow", double side = 1) : base(color)
    {
        SetSide(side);
    }

    private void SetSide(double side)
    {
        _side = side;
    }
}