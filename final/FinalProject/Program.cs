using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> _volumes = new List<Scripture>{};
        List<Scripture> _books = new List<Scripture>{};
        List<Scripture> _chapters = new List<Scripture>{};
        List<Scripture> _verses = new List<Scripture>{};

        // bool continueProgram = true;
        // List<string> scripturesCsvLines;

        // void SetScriptures()
        // {
        //     // Will eventually add a loading bar and or number while this loads.
        //     scripturesCsvLines = new List<string>{};
        //     string[] csvLines = System.IO.File.ReadAllLines("lds-scriptures.csv");
        //     int i = 0;
        //     foreach (string line in csvLines)
        //     {
        //         if (i != 0)
        //         {
        //             scripturesCsvLines.Add(line);
        //         }
        //         i++;
        //     }
        // }

        // List<string> GetScriptures()
        // {
        //     return scripturesCsvLines;
        // }

        // void ClearTerminal()
        // {
        //     Console.Clear();
        // }

        // void GiveIntro()
        // {
        //     Console.Write("Welcome to the Scripture Searcher!");
        //     Console.WriteLine();
        // }

        // void DisplayMenu()
        // {
        //     Console.WriteLine("Search for...");
        //     // Console.WriteLine("  word@ [enter word or phrase]");
        //     // Console.WriteLine("  verse@ [enter verse or verses]");
        //     Console.WriteLine("  verse@ [enter verse]");
        //     // Console.WriteLine("  chapter@ [enter chapter]");
        //     Console.WriteLine("  book@ [enter book]");
        //     Console.WriteLine("  volume@ [enter volume]");
        // }

        // // 
        // // 
        // //
        // void Search()
        // {
        //     if (continueProgram)
        //     {
        //         SearchScriptures search = new SearchScriptures(GetScriptures(), GetInquiry());
        //     }
        //     Console.WriteLine();
        // }
        // // 
        // // 
        // // 

        // string GetInquiry()
        // {
        //     Console.Write("> ");
        //     string input = Console.ReadLine();
        //     if (input == "exit")
        //     {
        //         continueProgram = false;
        //     }
        //     return input;
        // }


        // ClearTerminal();
        // SetScriptures();
        // GiveIntro();
        // while (continueProgram)
        // {
        //     DisplayMenu();
        //     Search();
        // }
        // ClearTerminal();
    }
}