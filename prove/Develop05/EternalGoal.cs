public class EternalGoal : Goal
{
    private string _goalType = "EternalGoal";

    public EternalGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points, isComplete)
    {
        
    }

    public override int MarkAsComplete()
    {
        return GetPoints();
    }

    public override string GetForFile()
    {
        return $"{GetGoalType()}~`{GetName()}~`{GetDescription()}~`{GetPoints()}";
    }

    private string GetGoalType()
    {
        return _goalType;
    }
}