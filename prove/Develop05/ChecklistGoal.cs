public class ChecklistGoal : Goal
{
    private string _goalType = "ChecklistGoal";
    private int _iterationAmountToComplete;
    private int _iterationsAccomplished;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int iterationAmountToComplete, int iterationsAccomplished = 0, bool isComplete = false) : base(name, description, points, isComplete)
    {
        SetIterationAmountToComplete(iterationAmountToComplete);
        SetIterationsAccomplished(iterationsAccomplished);
        SetBonusPoints(bonusPoints);
    }

    private void SetIterationAmountToComplete(int amount)
    {
        _iterationAmountToComplete = amount;
    }

    private void SetIterationsAccomplished(int amount)
    {
        _iterationsAccomplished = amount;
    }

    private void SetBonusPoints(int amount)
    {
        _bonusPoints = amount;
    }
    
    public override void Display()
    {
        Console.WriteLine($"{GetCompletionBox()} {GetName()} ({GetDescription()}) -- Accomplished {GetIterationsAccomplished()}/{GetIterationAmountToComplete()}");
    }

    public override int MarkAsComplete()
    {
        if (isLastIteration())
        {
            SetIsComplete(true);
            SetIterationsAccomplished(GetIterationsAccomplished() + 1);
            return GetPoints() + GetBonusPoints();
        }
        else
        {
            SetIterationsAccomplished(GetIterationsAccomplished() + 1);
            return GetPoints();
        }
    }

    private bool isLastIteration()
    {
        if (GetIterationsAccomplished() == GetIterationAmountToComplete() - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetForFile()
    {
        return $"{GetGoalType()}~`{GetName()}~`{GetDescription()}~`{GetPoints()}~`{GetBonusPoints()}~`{GetIterationAmountToComplete()}~`{GetIterationsAccomplished()}";
    }

    private string GetGoalType()
    {
        return _goalType;
    }
    
    protected override string GetCompletionBox()
    {
        string completionBox = "[ ]";
        if (IsComplete())
        {
            completionBox = "[X]";
        }
        else if (GetIterationsAccomplished() != 0)
        {
            completionBox = "[-]"; 
        }
        return completionBox;
    }

    private int GetIterationAmountToComplete()
    {
        return _iterationAmountToComplete;
    }

    private int GetIterationsAccomplished()
    {
        return _iterationsAccomplished;
    }

    private int GetBonusPoints()
    {
        return _bonusPoints;
    }
}