public class ChecklistGoal : Goal
{
    private string _goalType = "ChecklistGoal";
    private int _iterationAmountToComplete;
    private int _iterationsCompleted;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int iterationAmountToComplete, int iterationsCompleted = 0, bool isComplete = false) : base(name, description, points, isComplete)
    {
        SetIterationAmountToComplete(iterationAmountToComplete);
        SetIterationsCompleted(iterationsCompleted);
        SetBonusPoints(bonusPoints);
    }

    private void SetIterationAmountToComplete(int amount)
    {
        _iterationAmountToComplete = amount;
    }

    private void SetIterationsCompleted(int amount)
    {
        _iterationsCompleted = amount;
    }

    private void SetBonusPoints(int amount)
    {
        _bonusPoints = amount;
    }
    
    public override void Display()
    {
        Console.WriteLine($"{GetCompletionBox()} {GetName()} ({GetDescription()}) -- Accomplished {GetIterationsCompleted()}/{GetIterationAmountToComplete()}");
    }

    public override int MarkAsComplete()
    {
        if (isLastIteration())
        {
            SetIsComplete(true);
            SetIterationsCompleted(GetIterationsCompleted() + 1);
            return GetPoints() + GetBonusPoints();
        }
        else
        {
            SetIterationsCompleted(GetIterationsCompleted() + 1);
            return GetPoints();
        }
    }

    private bool isLastIteration()
    {
        if (GetIterationsCompleted() == GetIterationAmountToComplete() - 1)
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
        return $"{GetGoalType()}~`{GetName()}~`{GetDescription()}~`{GetPoints()}~`{GetBonusPoints()}~`{GetIterationAmountToComplete()}~`{GetIterationsCompleted()}";
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
        else if (GetIterationsCompleted() != 0)
        {
            completionBox = "[-]"; 
        }
        return completionBox;
    }

    private int GetIterationAmountToComplete()
    {
        return _iterationAmountToComplete;
    }

    private int GetIterationsCompleted()
    {
        return _iterationsCompleted;
    }

    private int GetBonusPoints()
    {
        return _bonusPoints;
    }
}