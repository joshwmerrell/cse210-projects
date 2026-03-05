using System;
// using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop02 World!");

        List<string> _entryPrompts = new List<string> {"Who was the most interesting person I interacted with today?","What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};
        List<string> _journalPrompts = new List<string> {"Read Journal", "Add Entry", "Write to Journal"};
        string _filename = "";

        string OpenJournal()
        {
            try
            {
                Console.Write("What is the name of your Journal txt file? ");
                _filename = Console.ReadLine();
                string[] lines = System.IO.File.ReadAllLines(_filename);
                string journalEntries = "";
                int i = 1;
                foreach (string line in lines)
                {
                    if (i == 1)
                    {
                        journalEntries = line;
                    }
                    else
                    {
                       journalEntries = journalEntries + "\n" + line; 
                    }
                    i++;
                }
                return journalEntries;  
            }
            catch (FileNotFoundException)
            {
                return "";
            }
        }

        Journal journal = new Journal();
        journal._entries = OpenJournal();
        bool journalOpen = true;

        void DisplayJournal()
        {
            Console.WriteLine($"\n\nYour Journal:\n\n{journal._entries}");
        }

        DisplayJournal();

        Prompt entryPrompt = new Prompt();
        entryPrompt._prompts = _entryPrompts;
        Prompt journalPrompt = new Prompt();
        journalPrompt._prompts = _journalPrompts;

        void ModifyJournal()
        {
            string prompt = entryPrompt.GetRandomPrompt();
            Console.WriteLine($"\n\nPrompt: {prompt}");
            Console.Write("Entry: ");
            journal._entry = Console.ReadLine();
            journal.AddEntry(prompt);
        }

        void WriteJournal()
        {
            using (StreamWriter outputFile = new StreamWriter(_filename))
            {
                outputFile.WriteLine(journal._entries);
            }
        }

        while (journalOpen)
        {
            Console.WriteLine("What would you like to do?");
            journalPrompt.DisplayPrompts();
            Console.Write("Enter a number: ");
            string entry = Console.ReadLine();

            if (entry == "1")
            {
                DisplayJournal();
            }
            else if (entry == "2")
            {
                ModifyJournal();
            }
            else if (entry == "3")
            {
                WriteJournal();
                journalOpen = false;
            }
            
            Console.WriteLine();
        }
    }
}