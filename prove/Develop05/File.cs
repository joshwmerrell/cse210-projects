public class File
{
    private int _totalPointsInFile;
    private List<string> _goalsInFile;

    public File()
    {
    }

    public void New(string fileName)
    {
        SetPoints(int.Parse(GetFirstFileLine(fileName)));
        SetGoals(GetFileLines(fileName, 1));
    }

    private void SetPoints(int amount)
    {
        _totalPointsInFile = amount;
    }

    private void SetGoals(List<string> goalsInFile)
    {
        _goalsInFile = goalsInFile;
    }

    private string GetFirstFileLine(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        return lines[0];
    }

    private List<string> GetFileLines(string fileName, int howManyLinesToSkip = 0)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        List<string> fileLines = new List<string>{};
        int i = 1;
        foreach (string line in lines)
        {
            if (i > howManyLinesToSkip)
            {
                fileLines.Add(line);
            }
            i++;
        }
        return fileLines;
    }

    public int Points()
    {
        return _totalPointsInFile;
    }

    public List<Goal> Goals()
    {
        List<Goal> goals = new List<Goal>{};
        foreach (string line in _goalsInFile)
        {
            string[] parts = line.Split("~`");
            string goalType = parts[0];
            string goalName = parts[1];
            string goalDescription = parts[2];
            int goalPoints = int.Parse(parts[3]);
            bool goalCompleted = false;
            if (parts.Length > 4 && parts[4] == "True")
            {
                goalCompleted = true;
            }
            if (goalType == "SimpleGoal")
            {
                goals.Add(new SimpleGoal(goalName, goalDescription, goalPoints, goalCompleted));
            }
            else if (goalType == "EternalGoal")
            {
                goals.Add(new EternalGoal(goalName, goalDescription, goalPoints, goalCompleted));
            }
            else if (goalType == "ChecklistGoal")
            {
                int goalBonusPoints = int.Parse(parts[4]);
                int goalIterationAmountToComplete = int.Parse(parts[5]);
                int goalIterationsCompleted = int.Parse(parts[6]);
                goalCompleted = false;
                if (goalIterationAmountToComplete == goalIterationsCompleted)
                {
                    goalCompleted = true;
                }
                goals.Add(new ChecklistGoal(goalName, goalDescription, goalPoints, goalBonusPoints, goalIterationAmountToComplete, goalIterationsCompleted, goalCompleted));
            }
        }
        return goals;
    }

    public void UpdatePoints(int points)
    {
        SetPoints(points);
    }

    public void UpdateGoals(List<Goal> updatedGoalsList)
    {
        SetGoals(new List<string>{});
        foreach (Goal goal in updatedGoalsList)
        {
            AddNewGoal(goal.GetForFile());
        }
    }

    private void AddNewGoal(string newGoal)
    {
        _goalsInFile.Add(newGoal);
    }

    public void WriteToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(GetPoints());
            foreach (string line in GetGoals())
            {
                outputFile.WriteLine(line);
            }
        }
    }

    private int GetPoints()
    {
        return _totalPointsInFile;
    }

    private List<string> GetGoals()
    {
        return _goalsInFile;
    }
}