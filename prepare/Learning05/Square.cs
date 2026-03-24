public class Square : Shape
{
    private double _side = 1;

    public Square(double side = 1, string color = "yellow") : base(color)
    {
        SetSide(side);
    }

    public Square(string color = "yellow", double side = 1) : base(color)
    {
        SetSide(side);
    }

    public Square() : base("yellow")
    {
        
    }

    private void SetSide(double side)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return Math.Pow(GetSide(), 2);
    }

    private double GetSide()
    {
        return _side;
    }
}