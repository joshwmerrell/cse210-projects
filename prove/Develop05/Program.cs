using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        bool _continueProgram = true;
        Points _points = new Points();
        Goals _goals = new Goals();
        List<string> _menuOptions = new List<string>{};
        List<string> _goalTypes = new List<string>{};

        _menuOptions.Add("Create New Goal");
        _menuOptions.Add("List Goals");
        _menuOptions.Add("Save Goals");
        _menuOptions.Add("Load Goals");
        _menuOptions.Add("Record Event");
        _menuOptions.Add("Quit");

        _goalTypes.Add("Simple Goal");
        _goalTypes.Add("Eternal Goal");
        _goalTypes.Add("Checklist Goal");

        void ClearConsole()
        {
            Console.Clear();
        }

        void DisplayPoints()
        {
            Console.WriteLine($"Your Points: {_points.GetPoints()}");
        }

        void ListMenu()
        {
            Console.WriteLine("Menu Options:");
            int i = 1;
            foreach (string option in _menuOptions)
            {
                Console.WriteLine($"  {i}. {option}");
                i++;
            }
        }

        void ChooseOption()
        {
            Console.Write("Select a choice from the menu: ");
            string option = Console.ReadLine();
            if (option == "1")
            {
                CreateNewGoal();
            }
            else if (option == "2")
            {
                ListGoals();
            }
            else if (option == "3")
            {
                SaveGoals();
            }
            else if (option == "4")
            {
                LoadGoals();
            }
            else if (option == "5")
            {
                RecordEvent();
            }
            else if (option == "6")
            {
                Quit();
            }
        }

        void CreateNewGoal()
        {
            _goals.CreateGoal();
        }

        void ListGoals()
        {
            _goals.ListGoals();
        }

        void SaveGoals()
        {
            
        }

        void LoadGoals()
        {
            
        }

        void RecordEvent()
        {
            _goals.RecordEvent();
        }

        void Quit()
        {
            _continueProgram = false;
        }

        // THIS WILL BE GIVEN TO THE CONSTRUCTOR FOR GOALS AND OTHERS!

        // string GetGoalType()
        // {
        //     ListGoalTypes();
        //     bool incorrectChoice = true;
        //     string type = "";
        //     while (incorrectChoice)
        //     {
        //         Console.Write("Which type of goal would you like to create? ");
        //         string choice = Console.ReadLine();
        //         if (choice == "1")
        //         {
        //             incorrectChoice = false;
        //             type = "simple";
        //         }
        //         else if (choice == "2")
        //         {
        //             incorrectChoice = false;
        //             type = "eternal";
        //         }
        //         else if (choice == "3")
        //         {
        //             incorrectChoice = false;
        //             type = "checklist";
        //         } 
        //     }
        //     return type;
        // }

        // void ListGoalTypes()
        // {
        //     Console.WriteLine("The types of Goals are:");
        //     int i = 1;
        //     foreach (string goalType in _goalTypes)
        //     {
        //         Console.WriteLine($"  {i}. {goalType}");
        //         i++;
        //     }
        // }

        // string GetGoalName()
        // {
        //     Console.WriteLine("What is the name of your goal? ");
        //     return Console.ReadLine();
        // }

        // string GetGoalDescription()
        // {
        //     Console.WriteLine("What is a short description of it? ");
        //     return Console.ReadLine();
        // }

        // int GetGoalAmount()
        // {
        //     Console.WriteLine("What is the amount of points associated with this goal?");
        //     return int.Parse(Console.ReadLine());
        // }

        // int GetChecklistGoalAmount()
        // {
        //     Console.WriteLine("What is the amount of points associated with each accomplishment of this goal? ");
        //     return int.Parse(Console.ReadLine());
        // }

        // int GetChecklistGoalBonusAmount()
        // {
        //     Console.WriteLine("What bonus amount do you want for completing this goal? ");
        //     return int.Parse(Console.ReadLine());
        // }

        while (_continueProgram)
        {
            DisplayPoints();
            ListMenu();
            ChooseOption();
            ClearConsole();
        }
    }
}