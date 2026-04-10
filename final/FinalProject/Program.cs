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

        List<string> commands = new List<string>{"volume", "book", "chapter", "verse"};
        int VOLUME_COMMAND_INDEX = 0;
        int BOOK_COMMAND_INDEX = 1;
        int CHAPTER_COMMAND_INDEX = 2;
        int VERSE_COMMAND_INDEX = 3;

        bool continueProgram = true;


        void SetScriptures()
        {
            string[] lines = System.IO.File.ReadAllLines("lds-scriptures.csv");
            List<string> volumeCsvLines = new List<string>{};
            List<string> bookCsvLines = new List<string>{};
            List<string> chapterCsvLines = new List<string>{};
            int VOLUME_ID_INDEX = 0;
            int BOOK_ID_INDEX = 1;
            int CHAPTER_ID_INDEX = 2;
            int volumeNumber = 0;
            int bookNumber = 0;
            int chapterNumber = 0;
            int i = 0;
            foreach (string line in lines)
            {
                if (i != 0)
                {
                    int volumeId = int.Parse(line.Split(",")[VOLUME_ID_INDEX]);
                    int bookId = int.Parse(line.Split(",")[BOOK_ID_INDEX]);
                    int chapterId = int.Parse(line.Split(",")[CHAPTER_ID_INDEX]);
                    if (i == 1)
                    {
                        volumeNumber += 1;
                        bookNumber += 1;
                        chapterNumber += 1;
                    }
                    bool newVolume = volumeNumber != volumeId;
                    bool newBook = bookNumber != bookId;
                    bool newChapter = chapterNumber != chapterId;
                    bool lastLine = i == lines.Length - 1;
                    if (newVolume || lastLine)
                    {
                        volumeNumber = volumeId;
                        volumes.Add(new Volume(volumeCsvLines));
                        volumeCsvLines.Clear();
                    }
                    if (newBook || lastLine)
                    {
                        bookNumber = bookId;
                        books.Add(new Book(bookCsvLines));
                        bookCsvLines.Clear();
                    }
                    if (newChapter || lastLine)
                    {
                        chapterNumber = chapterId;
                        chapters.Add(new Chapter(chapterCsvLines));
                        chapterCsvLines.Clear();
                    }
                    verses.Add(new Verse(new List<string>{line}));
                    volumeCsvLines.Add(line);
                    bookCsvLines.Add(line);
                    chapterCsvLines.Add(line); 
                }
                i += 1;
            }

            // // DEAR ME, FOR SOME REASON, IT IS PLACING MOSES IN D&C. FIX THIS!!!
            // // MAY NEED TO REDO THIS TO MAKE IT MORE SIMPLE.
            // string[] lines = System.IO.File.ReadAllLines("lds-scriptures.csv");
            // List<string> volumeBooksLines = new List<string>{};
            // List<string> bookCsvLines = new List<string>{};
            // List<string> chapterCsvLines = new List<string>{};
            // int i = 0;
            // int volumeNumber = 0;
            // int bookNumber = 0;
            // int chapterNumber = 0;
            // // // int verseNumber = 0;
            // int previousVolumesBookAmount = 0;
            // int previousBooksChapterAmount = 0;
            // // int previousChaptersVerseAmount = 0;
            // foreach (string line in lines)
            // {
            //     if (i != 0)
            //     {
            //         int volumeId = int.Parse(line.Split(",")[0]);
            //         int bookId = int.Parse(line.Split(",")[1]);
            //         int chapterId = int.Parse(line.Split(",")[2]);
            //         int verseId = int.Parse(line.Split(",")[3]);

            //         // bool newVolume = 
            //         bool lastLine = i == lines.Length - 1;
                    
            //         if (volumeNumber != volumeId || lastLine)
            //         {
            //             volumeNumber = volumeId;
            //             previousVolumesBookAmount = bookId - 1;
            //             if (i != 1)
            //             {
            //                 volumes.Add(new Volume(volumeBooksLines));
            //                 volumeBooksLines.Clear();
            //             }
            //         }
            //         if (bookNumber != bookId - previousVolumesBookAmount || lastLine)
            //         {
            //             bookNumber = bookId - previousVolumesBookAmount;
            //             previousBooksChapterAmount = chapterId - 1;
            //             volumeBooksLines.Add(line);
            //             if (i != 1)
            //             {
            //                 books.Add(new Book(bookCsvLines));
            //                 bookCsvLines.Clear();
            //             }
            //         }
            //         if (chapterNumber != chapterId - previousBooksChapterAmount || lastLine)
            //         {
            //             chapterNumber = chapterId - previousBooksChapterAmount;
            //             // previousChaptersVerseAmount = verseId - 1;
            //             if (i != 1)
            //             {
            //                 chapters.Add(new Chapter(chapterCsvLines));
            //                 chapterCsvLines.Clear();
            //             }
            //         }
            //         // int verseNumber = verseId - previousChaptersVerseAmount;
            //         verses.Add(new Verse(new List<string>{line}));
            //         bookCsvLines.Add(line);
            //         chapterCsvLines.Add(line);
            //     }
            //     i++;
            // }
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
            if (inquiry.ToLower() != "exit")
            {
                string result = "\n\nResult:";
                string command = GetCommand(inquiry);
                bool CommandAndSearchingForArePresent = IsACommand(commands, command) && inquiry.Split("@ ").Length > 1;
                if (CommandAndSearchingForArePresent)
                {
                    bool volumeCommand = command == commands[VOLUME_COMMAND_INDEX];
                    bool bookCommand = command == commands[BOOK_COMMAND_INDEX];
                    bool chapterCommand = command == commands[CHAPTER_COMMAND_INDEX];
                    bool verseCommand = command == commands[VERSE_COMMAND_INDEX];
                    if (volumeCommand)
                    {
                        foreach (Scripture volume in volumes)
                        {
                            result += volume.GetSearchResult(GetSearchingFor(inquiry));
                        }
                    }
                    else if (bookCommand)
                    {
                        foreach (Scripture book in books)
                        {
                            result += book.GetSearchResult(GetSearchingFor(inquiry));
                        }
                    }
                    else if (chapterCommand)
                    {
                        foreach (Scripture chapter in chapters)
                        {
                            result += chapter.GetSearchResult(GetSearchingFor(inquiry));
                        }
                    }
                    else if (verseCommand)
                    {
                        foreach (Scripture verse in verses)
                        {
                            result += verse.GetSearchResult(GetSearchingFor(inquiry));
                        }
                    }
                    if (result == "\n\nResult:")
                    {
                        result = "\n\nNo result found.";
                    }
                }
                else
                {
                    result = "\n\nPlease enter a command and inquiry as formatted above.";
                }
                Console.WriteLine($"{result}\n\n");
            }
            else
            {
                continueProgram = false;
            }
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
            Search(GetInquiry());
        }
    }
}