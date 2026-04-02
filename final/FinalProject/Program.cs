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

        void ClearTerminal()
        {
            Console.Clear();
        }

        void GiveIntro()
        {
            Console.Write("");
        }

        void DisplayMenu()
        {
            Console.WriteLine("");
        }

        void Search()
        {
            string result = GetSearchResult(GetInquiry());
            Console.WriteLine(result);
        }

        string GetInquiry()
        {
            return "";
        }

        string GetSearchResult(string inquiry)
        {
            GetCommand(inquiry);
            return "";
        }

        string GetCommand(string inquiry)
        {
            return "";
        }


        ClearTerminal();
        GiveIntro();
        while (_continueProgram)
        {
            DisplayMenu();
            Search();
        }
        ClearTerminal();
    }
}