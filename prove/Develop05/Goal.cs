abstract public class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    public Goal(string name, string description, int points, bool isComplete)
    {
        SetName(name);
        SetDescription(description);
        SetPoints(points);
        SetIsComplete(isComplete);
    }

    private void SetName(string name)
    {
        _name = name;
    }

    private void SetDescription(string description)
    {
        _description = description;
    }

    private void SetPoints(int points)
    {
        _points = points;
    }

    private void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    virtual public void Display()
    {
        Console.WriteLine($"{GetCompletionBox()} {GetName()} ({GetDescription()})");
    }

    public void DisplayNameOnly()
    {
        Console.WriteLine(GetName());
    }

    protected string GetCompletionBox()
    {
        string completionBox = "[ ]";
        if (IsComplete())
        {
            completionBox = "[X]";
        }
        return completionBox;
    }

    public bool IsComplete()
    {
        return _isComplete;
    }

    protected string GetName()
    {
        return _name;
    }

    protected string GetDescription()
    {
        return _description;
    }

    // protected string GetCompleted()
    // {
    //     string completed = "False";
    //     if (IsComplete())
    //     {
    //         completed = "True";
    //     }
    //     return completed;
    // }

    virtual public int MarkAsComplete()
    {
        _isComplete = true;
        return _points;
    }

    public int GetPoints()
    {
        return _points;
    }

    abstract public string GetForFile();
}