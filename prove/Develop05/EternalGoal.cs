public class EternalGoal : Goal
{
    private string _goalType = "EternalGoal";

    public EternalGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points, isComplete)
    {
        
    }

    public override void MarkAsComplete()
    {
    }

    public override string GetSimplified()
    {
        return $"{GetGoalType()}~`{GetName()}~`{GetDescription()}~`{GetPoints()}~`{GetCompleted()}";
    }

    private string GetGoalType()
    {
        return _goalType;
    }
}