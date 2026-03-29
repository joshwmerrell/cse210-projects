using System.Reflection.Metadata.Ecma335;

public class Goals
{
    private File _file;
    private List<Goal> _goals = new List<Goal>{};
    private List<string> _goalTypes = new List<string>{};

    public Goals()
    {
        _goalTypes.Add("Simple Goal");
        _goalTypes.Add("Eternal Goal");
        _goalTypes.Add("Checklist Goal");
    }

    public void CreateGoal()
    {
        ListGoalTypes();
        bool incorrectChoice = true;
        while (incorrectChoice)
        {
            Console.Write("Which type of goal would you like to create? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                incorrectChoice = false;
                _goals.Add(new SimpleGoal(GetNewName(), GetNewDescription(), GetNewAmount()));
            }
            else if (choice == "2")
            {
                incorrectChoice = false;
                _goals.Add(new EternalGoal(GetNewName(), GetNewDescription(), GetNewAmount()));
            }
            else if (choice == "3")
            {
                incorrectChoice = false;
                _goals.Add(new ChecklistGoal(GetNewName(), GetNewDescription(), GetNewChecklistAmount(), GetNewBonusAmount(), GetNewChecklistIterationAmount()));
            } 
        }
        Console.WriteLine();
    }

    private void ListGoalTypes()
    {
        Console.WriteLine("The types of Goals are:");
        int i = 1;
        foreach (string goalType in _goalTypes)
        {
            Console.WriteLine($"  {i}. {goalType}");
            i++;
        }
    }

    private string GetNewName()
    {
        Console.Write("What is the name of your goal? ");
        return Console.ReadLine();
    }

    private string GetNewDescription()
    {
        Console.Write("What is the description of you goal? ");
        return Console.ReadLine();
    }

    private int GetNewAmount()
    {
        Console.Write("How many points is your goal worth? ");
        return int.Parse(Console.ReadLine());
    }

    private int GetNewChecklistAmount()
    {
        Console.Write("How many points is each accomplishment of your goal worth? ");
        return int.Parse(Console.ReadLine());
    }

    private int GetNewBonusAmount()
    {
        Console.Write("How many bonus points do you want when you complete this goal? ");
        return int.Parse(Console.ReadLine());
    }

    private int GetNewChecklistIterationAmount()
    {
        Console.Write("");
        return int.Parse(Console.ReadLine());
    }

    public void ListGoals(bool nameOnly = false)
    {
        if (ThereAreNoGoals())
        {
            Console.WriteLine("You have no goals.");
        }
        else if (nameOnly)
        {
            Console.WriteLine("Your goals are:");
            int i = 1;
            foreach (Goal goal in _goals)
            {
                Console.Write($"{i}. ");
                goal.DisplayNameOnly();
                i++;
            } 
        }
        else
        {
            Console.WriteLine("Your goals are:");
            int i = 1;
            foreach (Goal goal in _goals)
            {
                Console.Write($"{i}. ");
                goal.Display();
                i++;
            }  
        }
        Console.WriteLine();
    }

    public void SaveToFile(int totalPoints)
    {
        _file.UpdatePoints(totalPoints);
        _file.UpdateGoals(_goals);
        _file.WriteToFile(GetFileName());
    }

    public void NewFile()
    {
        _file = new File(GetFileName());
    }

    public int GetTotalPointsFromFile()
    {
        return _file.Points();
    }

    public void DownloadGoals()
    {
        List<Goal> existingGoals = _file.Goals();
        foreach (Goal existingGoal in existingGoals)
        {
            _goals.Insert(0, existingGoal);
        }
    }

    private string GetFileName()
    {
        Console.Write("What is the file name? ");
        return Console.ReadLine();
    }
    
    public int RecordEvent()
    {
        if (ThereAreNoGoals())
        {
            Console.WriteLine("I'm sorry, but you need to create a goal to accomplish first.");
            return 0;
        }
        else
        {
            bool nameOnly = true;
            ListGoals(nameOnly);
            return MarkGoalCompleted();
        }
    }

    private bool ThereAreNoGoals()
    {
        if (_goals.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int MarkGoalCompleted()
    {
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        if (GoalIsCompleted(goalIndex))
        {
            Console.Write("That goal is already completed.");
            return 0;
        }
        else
        {
            return _goals[goalIndex].MarkAsComplete();
        }
    }

    private bool GoalIsCompleted(int goalIndex)
    {
        if (_goals[goalIndex].IsComplete())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}