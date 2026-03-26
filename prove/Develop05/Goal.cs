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

    virtual public string GetGoal()
    {
        return $"{GetCompletionBox()} {GetName()} ({GetDescription()})";
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

    private bool IsComplete()
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

    protected string GetCompleted()
    {
        string completed = "False";
        if (IsComplete())
        {
            completed = "True";
        }
        return completed;
    }

    virtual public void MarkAsComplete()
    {
        _isComplete = true;
    }

    public int GetPoints()
    {
        return _points;
    }

    abstract public string GetGoalSimplified();
}