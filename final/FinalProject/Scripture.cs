public abstract class Scripture
{
    protected int _number;
    protected string _name;

    public Scripture(string scriptureCsvLine)
    {
        SetNumber(scriptureCsvLine);
        SetName(scriptureCsvLine);
    }

    protected abstract void SetNumber(string csvLine);

    protected abstract void SetName(string csvLine);

    protected abstract void SetScripture(List<string> csvList);

    public int GetNumber()
    {
        return _number;
    }

    public string GetName()
    {
        return _name;
    }

    public abstract string GetSearchResult(string searchingFor);
}