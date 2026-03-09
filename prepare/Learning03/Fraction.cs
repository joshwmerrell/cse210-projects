public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        SetTop(1);
        SetBottom(1);
    }
    public Fraction(int wholeNumber)
    {
        SetTop(wholeNumber);
        SetBottom(1);
    }
    public Fraction(int top, int bottom)
    {
        SetTop(top);
        SetBottom(bottom);
    }

    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{GetTop()}/{GetBottom()}";
    }
    public double GetDecimalValue()
    {
        return (double)GetTop() / (double)GetBottom();
    }
}