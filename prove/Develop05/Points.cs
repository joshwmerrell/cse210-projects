using System.ComponentModel;

public class Points
{
    private int _amount = 0;

    public Points()
    {
        
    }

    public void AddPoints(int points)
    {
        _amount += points;
    }

    public int GetPoints()
    {
        return _amount;
    }
}