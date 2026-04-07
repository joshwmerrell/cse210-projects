abstract public class Scripture
{
    private int _number;
    private string _name;

    public Scripture()
    {
    }

    protected void SetNumber(int number)
    {
        _number = number;
    }

    virtual protected void SetName(string name)
    {
        _name = name;
    }

    abstract protected void SetScriptures(List<string> scriptures);

    protected int GetNumber()
    {
        return _number;
    }

    protected string GetName()
    {
        return _name;
    }
}