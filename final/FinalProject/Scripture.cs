abstract public class Scripture
{
    private int _number;
    protected string _name;

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

    abstract public string GetSearch(int searchDepth, string searchString);

    public int GetNumber()
    {
        return _number;
    }

    public string GetName()
    {
        return _name;
    }
}