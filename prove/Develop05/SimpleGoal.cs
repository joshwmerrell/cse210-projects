public class SimpleGoal : Goal
{
    private string _goalType = "SimpleGoal";

    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points, isComplete)
    {
        
    }

    public override string GetGoalSimplified()
    {
        return $"{GetGoalType()}~`{GetName()}~`{GetDescription()}~`{GetPoints()}~`{GetCompleted()}";
    }

    private string GetGoalType()
    {
        return _goalType;
    }
}