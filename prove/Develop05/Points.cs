using System.ComponentModel;

public class Points
{
    private int _amount = 0;

    public Points()
    {
        
    }

    public void Add(int points)
    {
        _amount += points;
    }

    public int Get()
    {
        return _amount;
    }
}