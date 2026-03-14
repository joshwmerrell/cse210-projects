using System;
using System.Runtime.InteropServices;

// In this program, we will be challenging the user to memorize a scripture by slowly removing words from one we give the user.
class Program
{
    static void Main(string[] args)
    {
        // The Attributes of the program are
        // ... a library of scriptures, and
        // ... a determiner to know if the program should continue running or not. 
        List<Scripture> _scriptures;
        bool _memorizingScripture = true;

        // Here we build our library...
        void SetScripturesList()
        {
            _scriptures = new List<Scripture>{};
            _scriptures.Add(new Scripture());
            _scriptures.Add(new Scripture("1 Corinthians 13:8", "Charity never faileth: but whether there be prophecies, they shall fail; whether there be tongues, they shall cease; whether there be knowledge, it shall vanish away."));
            _scriptures.Add(new Scripture("John 3:16-17", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life. For God sent not his Son into the world to condemn the world; but that the world through him might be saved."));
        }

        // and select a scripture to start our challenge with.
        SetScripturesList();
        Scripture scripture = _scriptures[new Random().Next(0, _scriptures.Count - 1)];

        // We then determine how to
        // ... clear our screen,
        void ClearConsole()
        {
            Console.Clear();
        }

        // ... show our scriture,
        void DisplayScripture()
        {
            Console.WriteLine($"\n{scripture.GetScripture()}\n\n");
        }

        // ... have the user choose what to do with the scripture, ***skip down to RemoveWords() to continue this sentence***
        void Options()
        {
            string entryPrompt = "Press enter to CONTINUE the challenge or...\nType 'reset' to RESET the scripture\nType 'next' to move to the NEXT scripture\nType 'quit' to QUIT";
            // // In order to fully apply all the requirements for this challenege, we need to communicate to the user that when they have removed the entire scripture that the challenge should be finished for that scripture.
            if (scripture.ScriptureIsHidden())
            {
                entryPrompt = "Press enter to QUIT the challenge or...\nType 'reset' to RESET the scripture\nType 'next' to move to the NEXT scripture\nType 'quit' to QUIT";
            }
            Console.WriteLine(entryPrompt);
            bool correctEntry = false;
            while (correctEntry == false)
            {
                // The options we give the user are to
                Console.Write(">");
                string entry = Console.ReadLine();
                if (scripture.ScriptureIsHidden() && entry == "")
                {
                    correctEntry = true;
                    _memorizingScripture = false;
                }
                // ... remove words from the scripture,
                else if (entry == "")
                {
                    correctEntry = true;
                    RemoveWords();
                }
                // ... restore all the words back to the scripture,
                else if (entry == "reset")
                {
                    correctEntry = true;
                    ResetScripture();
                }
                // ... move to a new scripture,
                else if (entry == "next")
                {
                    correctEntry = true;
                    NextScripture();
                }
                // ... or to end the program.
                else if (entry == "quit")
                {
                    correctEntry = true;
                    _memorizingScripture = false;
                }
            }
        }

        // ... remove words from the scripture,
        void RemoveWords()
        {
            scripture.HideWords();
        }

        // ... restore all the words back to the scripture,
        void ResetScripture()
        {
            int scriptureIndex = CurrentScriptureIndex();
            SetScripturesList();
            scripture = _scriptures[scriptureIndex];
        }

        // ... choose a different scripture,
        void NextScripture()
        {
            int previousScriptureIndex = CurrentScriptureIndex();
            SetScripturesList();
            if (previousScriptureIndex == _scriptures.Count - 1)
            {
                scripture = _scriptures[0];
            }
            else
            {
                scripture = _scriptures[previousScriptureIndex + 1]; 
            }
        }

        // ... and finally how to know where the scripture is located in the library.
        int CurrentScriptureIndex()
        {
            return _scriptures.IndexOf(scripture);
        }

        // Now we begin running the challenge for the user.
        while (_memorizingScripture)
        {
            ClearConsole();
            DisplayScripture();
            Options();
        }
    }   
}

// To exceed requirements for this program, I did the following:
// // I allowed the program to start off with a random scripture that is stored in a list of scriptures.
// // I allowed the user the additional options to reset the scripture or move to another scripture.