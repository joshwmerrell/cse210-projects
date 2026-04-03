using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueProgram = true;
        List<string> commands = new List<string>{"volume", "book", "verse", "word"};

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


        // 
        // 
        //
        void Search()
        {
            string inquiry = GetInquiry();
            if (continueProgram)
            {
                string result = GetSearchResult(inquiry);
                Console.WriteLine(result);
            }
        }
        // 
        // 
        // 

        string GetInquiry()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input == "exit")
            {
                continueProgram = false;
            }
            return input;
        }

        string GetSearchResult(string inquiry)
        {
            string result = "Please enter a command and a search inquiry.";
            if (CommandAndSearchAreGiven(inquiry))
            {
                string command = GetCommand(inquiry);
                string searchingFor = GetSearchingFor(inquiry);
                if (command == commands[0])
                {
                    Search search = new SearchVolume(command, searchingFor);
                    // string result = search.Result();
                    result = "Searched for a volume.";
                }
                else if (command == commands[1])
                {
                    Search search = new SearchBook(command, searchingFor);
                    // string result = search.Result();
                    result = "Searched for a book.";
                }
                else if (command == commands[2])
                {
                    Search search = new SearchVerse(command, searchingFor);
                    // string result = search.Result();
                    result = "Searched for a verse.";
                }
                else if (command == commands[3])
                {
                    Search search = new SearchWord(command, searchingFor);
                    // string result = search.Result();
                    result = "Searched for a word.";
                }
            }
            return result;
        }

        bool CommandAndSearchAreGiven(string inquiry)
        {
            if (inquiry.Split("@ ").Length > 1 && IsACommand(GetCommand(inquiry)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsACommand(string commandGiven)
        {
            bool IsCommand = false;
            foreach (string command in commands)
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
        while (continueProgram)
        {
            Console.WriteLine();
            DisplayMenu();
            Search();
        }
        ClearTerminal();
    }
}