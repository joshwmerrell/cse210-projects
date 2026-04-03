using System;

class Program
{
    static void Main(string[] args)
    {
        bool _continueProgram = true;
        List<string> _commands = new List<string>{};
        _commands.Add("volume");
        _commands.Add("book");
        // _commands.Add("chapter");
        _commands.Add("verse");
        _commands.Add("word");

        void ClearTerminal()
        {
            Console.Clear();
        }

        void GiveIntro()
        {
            Console.Write("Welcome to the Scripture Searcher!");
            Console.WriteLine();
        }

        void DisplayMenu()
        {
            Console.WriteLine("Search for...");
            Console.WriteLine("  word@ [enter word or phrase]");
            // Console.WriteLine("  verse@ [enter verse or verses]");
            Console.WriteLine("  verse@ [enter verse]");
            // Console.WriteLine("  chapter@ [enter chapter]");
            Console.WriteLine("  book@ [enter book]");
            Console.WriteLine("  volume@ [enter volume]");
            Console.WriteLine();
        }

        void Search()
        {
            string inquiry = GetInquiry();
            if (_continueProgram)
            {
                string result = GetSearchResult(inquiry);
                Console.WriteLine(result);
            }
        }

        string GetInquiry()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input == "exit")
            {
                _continueProgram = false;
            }
            return input;
        }

        string GetSearchResult(string inquiry)
        {
            if (CommandAndSearchIsGiven(inquiry))
            {
                GetCommand(inquiry);
                GetSearchingFor(inquiry);
                return "Search Found";
            }
            else
            {
                return "Please enter a command and a search inquiry.";
            }
        }

        bool CommandAndSearchIsGiven(string inquiry)
        {
            if (inquiry.Split("@ ").Length > 1 && IsCommand(GetCommand(inquiry)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsCommand(string commandGiven)
        {
            bool IsCommand = false;
            foreach (string command in _commands)
            {
                if (commandGiven == command)
                {
                    IsCommand = true;
                    break;
                }
            }
            return IsCommand;
        }

        string GetCommand(string inquiry)
        {
            return inquiry.Split("@ ")[0].ToLower();
        }

        string GetSearchingFor(string inquiry)
        {
            return inquiry.Split("@ ")[1].ToLower();
        }


        ClearTerminal();
        GiveIntro();
        while (_continueProgram)
        {
            Console.WriteLine();
            DisplayMenu();
            Search();
        }
        ClearTerminal();
    }
}