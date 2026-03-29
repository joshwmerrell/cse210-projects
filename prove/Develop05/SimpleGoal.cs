public class SimpleGoal : Goal
{
    private string _goalType = "SimpleGoal";

    public SimpleGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points, isComplete)
    {
        
    }

    public override string GetForFile()
    {
        return $"{GetGoalType()}~`{GetName()}~`{GetDescription()}~`{GetPoints()}~`{GetCompleted()}";
    }

    private string GetGoalType()
    {
        return _goalType;
    }
}