using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        bool memorizeScripture = true;
        Scripture scripture = new Scripture();
        // void StoreScripture()
        // {
            
        // }

        void DisplayScripture()
        {
            Console.WriteLine($"\n{scripture.GetScripture()}\n\n");
        }

        void QuitOrContinueProgram()
        {
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string quitOrContinue = Console.ReadLine();
            if (quitOrContinue == "quit")
            {
                memorizeScripture = false;
            }
        }

        void ClearConsole()
        {
            Console.Clear();
        }

        void RemoveWords()
        {
            scripture.BlankOutWords();
        }

        int i = 0;
        while (memorizeScripture)
        {
            if (i != 0)
            {
                RemoveWords();
            }
            DisplayScripture();
            QuitOrContinueProgram();
            ClearConsole();
            i++;
        }
    }   
}