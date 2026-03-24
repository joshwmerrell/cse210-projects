public class Shape
{
    private string _color;

    protected Shape(string color)
    {
        SetColor(color);
    }

    private void SetColor(string color)
    {
        _color = color;
    }
}