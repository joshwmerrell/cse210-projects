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

        _menuOptions.Add("Create New Goal");
        _menuOptions.Add("List Goals");
        _menuOptions.Add("Record Event");
        _menuOptions.Add("Load Goals");
        _menuOptions.Add("Save Goals and Quit");
        _menuOptions.Add("Quit without Saving");

        void ClearConsole()
        {
            Console.Clear();
        }

        void DisplayPoints()
        {
            Console.WriteLine($"Your Points: {_points.Get()}");
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
                RecordEvent();
            }
            else if (option == "4")
            {
                LoadPointsAndGoals();
            }
            else if (option == "5")
            {
                SaveGoalsAndQuit();
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

        void LoadPointsAndGoals()
        {
            _goals.NewFile();
            _points.Add(_goals.GetTotalPointsFromFile());
            _goals.DownloadGoals();
            Console.WriteLine("The existing goals have been downloaded!");
        }

        void RecordEvent()
        {
            _points.Add(_goals.RecordEvent());
        }

        void SaveGoalsAndQuit()
        {
            _goals.SaveToFile(_points.Get());
            Quit();
        }

        void Quit()
        {
            _continueProgram = false;
        }


        while (_continueProgram)
        {
            DisplayPoints();
            ListMenu();
            ChooseOption();
        }
        ClearConsole();
    }
}