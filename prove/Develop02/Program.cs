using System;

class Program
{
    static void Main(string[] args)
    {
        string _filename = "";
        string _journal;
        List<string> _journalPrompts = new List<string>{"Read Journal", "Add Entry", "Write to Journal"};

        string OpenJournal()
        {
            try
            {
                Console.Write("What is the name of your Journal txt file? ");
                _filename = Console.ReadLine();
                string[] lines = System.IO.File.ReadAllLines(_filename);
                string journal = "";
                int i = 1;
                foreach (string line in lines)
                {
                    if (i == 1)
                    {
                        journal = line;
                    }
                    else
                    {
                       journal = journal + "\n" + line; 
                    }
                    i++;
                }
                return journal;  
            }
            catch (FileNotFoundException)
            {
                return "";
            }
        }

        _journal = OpenJournal();
        bool journalOpen = true;
        Journal journal = new Journal();
        journal._entries = _journal;

        Prompt journalPrompts = new Prompt();
        journalPrompts._prompts = _journalPrompts;

        void DisplayJournal()
        {
            journal.DisplayEntries();
        }

        void ModifyJournal()
        {
            journal.AddEntry();
        }

        void WriteJournal()
        {
            _journal = journal._entries;
            using (StreamWriter outputFile = new StreamWriter(_filename))
            {
                outputFile.WriteLine(_journal);
            }
        }

        while (journalOpen)
        {
            Console.WriteLine("What would you like to do?");
            journalPrompts.ListAllPrompts();
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