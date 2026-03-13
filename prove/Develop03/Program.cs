using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> _scriptures;
        bool _memorizingScripture = true;
        bool _nextScripture = false;


        void SetScripturesList()
        {
            _scriptures = new List<Scripture>{};
            _scriptures.Add(new Scripture());
            _scriptures.Add(new Scripture("1 Corinthians 13:8", "Charity never faileth: but whether there be prophecies, they shall fail; whether there be tongues, they shall cease; whether there be knowledge, it shall vanish away."));
            _scriptures.Add(new Scripture("John 3:16-17", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life. For God sent not his Son into the world to condemn the world; but that the world through him might be saved."));
        }

        SetScripturesList();
        Scripture scripture = _scriptures[new Random().Next(0, _scriptures.Count - 1)];

        void ClearConsole()
        {
            Console.Clear();
        }

        void DisplayScripture()
        {
            Console.WriteLine($"\n{scripture.GetScripture()}\n\n");
        }

        void QuitNextOrContinueProgram()
        {
            if (_memorizingScripture)
            {
                bool correctEntry = false;
                while (correctEntry == false)
                {
                    Console.Write("Press enter to continue, type 'next' to move to the next scripture, or type 'quit' to finish: ");
                    string quitNextOrContinue = Console.ReadLine();
                    if(quitNextOrContinue == "")
                    {
                        correctEntry = true;
                    }
                    else if (quitNextOrContinue == "next")
                    {
                        _nextScripture = true;
                        correctEntry = true;
                    }
                    else if (quitNextOrContinue == "quit")
                    {
                        _memorizingScripture = false;
                        correctEntry = true;
                    }
                }
            }
        }

        void NextScripture()
        {
            int previousScriptureIndex = _scriptures.IndexOf(scripture);
            SetScripturesList();
            if (previousScriptureIndex == _scriptures.Count - 1)
            {
                scripture = _scriptures[0];
            }
            else
            {
                scripture = _scriptures[previousScriptureIndex + 1]; 
            }
            _nextScripture = false;
        }

        void RemoveWords()
        {
            if (scripture.AmountOfVisibleWords() == 0)
            {
                _memorizingScripture = false;
            }
            else
            {
                scripture.BlankOutWords();
            }
        }


        int i = 0;
        while (_memorizingScripture)
        {
            ClearConsole();
            if (_nextScripture)
            {
                NextScripture();
            }
            else if (i != 0)
            {
                RemoveWords();
            }
            DisplayScripture();
            QuitNextOrContinueProgram();
            i++;
        }
    }   
}