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

    private string GetCompletionBox()
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

    private string GetName()
    {
        return _name;
    }

    private string GetDescription()
    {
        return _description;
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