public class Goals
{
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

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals.");
        }
        else
        {
            Console.WriteLine("The goals are:");
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

    public void LoadGoals()
    {
        
    }

    private void SetGoal()
    {
        
    }

    public void RecordEvent()
    {
        
    }

    private bool GoalIsCompleted(int goalIndex)
    {
        return false;
    }

    private void MarkGoalCompleted(int goalIndex)
    {
        
    }

    private int GetPoints(int goalIndex)
    {
        return 0;
    }
}