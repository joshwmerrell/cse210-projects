using System;
using System.Data;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> volumes = new List<Scripture>{};
        List<Scripture> books = new List<Scripture>{};
        List<Scripture> chapters = new List<Scripture>{};
        List<Scripture> verses = new List<Scripture>{};

        bool continueProgram = true;


        void SetScriptures()
        {
            string[] lines = System.IO.File.ReadAllLines("lds-scriptures.csv");
            List<string> volumeBooksLines = new List<string>{};
            List<string> bookCsvLines = new List<string>{};
            List<string> chapterCsvLines = new List<string>{};
            int i = 0;
            int volumeNumber = 0;
            int bookNumber = 0;
            int chapterNumber = 0;
            // // int verseNumber = 0;
            int previousVolumesBookAmount = 0;
            int previousBooksChapterAmount = 0;
            // int previousChaptersVerseAmount = 0;
            foreach (string line in lines)
            {
                if (i != 0)
                {
                    int volumeId = int.Parse(line.Split(",")[0]);
                    int bookId = int.Parse(line.Split(",")[1]);
                    int chapterId = int.Parse(line.Split(",")[2]);
                    int verseId = int.Parse(line.Split(",")[3]);
                    if (volumeNumber != volumeId)
                    {
                        volumeNumber = volumeId;
                        previousVolumesBookAmount = bookId - 1;
                        if (i != 1)
                        {
                            volumes.Add(new Volume(volumeBooksLines));
                            volumeBooksLines.Clear();
                        }
                    }
                    if (bookNumber != bookId - previousVolumesBookAmount)
                    {
                        bookNumber = bookId - previousVolumesBookAmount;
                        previousBooksChapterAmount = chapterId - 1;
                        volumeBooksLines.Add(line);
                        if (i != 1)
                        {
                            books.Add(new Book(bookCsvLines));
                            bookCsvLines.Clear();
                        }
                    }
                    if (chapterNumber != chapterId - previousBooksChapterAmount)
                    {
                        chapterNumber = chapterId - previousBooksChapterAmount;
                        // previousChaptersVerseAmount = verseId - 1;
                        if (i != 1)
                        {
                            chapters.Add(new Chapter(chapterCsvLines));
                            chapterCsvLines.Clear();
                        }
                    }
                    // int verseNumber = verseId - previousChaptersVerseAmount;
                    verses.Add(new Verse(new List<string>{line}));
                    bookCsvLines.Add(line);
                    chapterCsvLines.Add(line);
                }
                i++;
            }
        }

        void DisplayIntro()
        {
            Console.Write("Welcome to the Scripture Searcher!");
            Console.WriteLine();
        }

        void DisplayMenu()
        {
            Console.WriteLine("Search for...");
            // Console.WriteLine("  word@ [enter word or phrase]");
            // Console.WriteLine("  verse@ [enter verse or verses]");
            Console.WriteLine("  verse@ [enter verse]");
            Console.WriteLine("  chapter@ [enter chapter]");
            Console.WriteLine("  book@ [enter book]");
            Console.WriteLine("  volume@ [enter volume]");
        }

        void Search(string inquiry)
        {
            string result = "";
            List<string> commands = new List<string>{"volume", "book", "chapter", "verse"};
            string command = GetCommand(inquiry);
            bool CommandAndSearchingForArePresent = IsACommand(commands, command) && inquiry.Split("@ ").Length > 1;
            if (CommandAndSearchingForArePresent)
            {
                Console.WriteLine("Result:");
                if (command == commands[0])
                {
                    foreach (Scripture volume in volumes)
                    {
                        result = result + volume.GetSearchResult(GetSearchingFor(inquiry));
                    }
                }
                else if (command == commands[1])
                {
                    foreach (Scripture book in books)
                    {
                        result = result + book.GetSearchResult(GetSearchingFor(inquiry));
                    }
                }
                else if (command == commands[2])
                {
                    foreach (Scripture chapter in chapters)
                    {
                        result = result + chapter.GetSearchResult(GetSearchingFor(inquiry));
                    }
                }
                else if (command == commands[3])
                {
                    foreach (Scripture verse in verses)
                    {
                        result = result + verse.GetSearchResult(GetSearchingFor(inquiry));
                    }
                }
                if (result == "")
                {
                    result = "No result found.";
                }
            }
            else
            {
                result = "Please enter a command and inquiry as formatted above.";
            }
            Console.WriteLine(result);
            Console.WriteLine();
        }

        string GetInquiry()
        {
            Console.Write("Enter an inquiry: ");
            return Console.ReadLine();
        }

        bool IsACommand(List<string> commands, string potentialCommand)
        {
            bool isACommand = false;
            foreach (string command in commands)
            {
                if (potentialCommand == command)
                {
                    isACommand = true;
                    break;
                }
            }
            return isACommand;
        }

        string GetCommand(string inquiry)
        {
            return inquiry.Split("@ ")[0];
        }

        string GetSearchingFor(string inquiry)
        {
            return inquiry.Split("@ ")[1];
        }


        Console.Clear();
        SetScriptures();
        DisplayIntro();
        while (continueProgram)
        {
            DisplayMenu();
            if (continueProgram)
            {
                Search(GetInquiry());
            }
        }
    }
}