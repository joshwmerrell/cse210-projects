using System.Data.SqlTypes;

public class Volume : Scripture
{
    private List<Book> _books = new List<Book>{};
    public Volume(List<string> volumeCsvLines) : base()
    {
        SetNumber(int.Parse(volumeCsvLines[0].Split(",")[0]));
        SetName(volumeCsvLines[0].Split(",")[6].Split('"')[1]);
        SetScriptures(volumeCsvLines);
    }

    override protected void SetScriptures(List<String> csvLines)
    {
        List<string> bookCsvLines = new List<string>{};
        int bookNumber = 0;
        int allPreviousBooks = 0;
        int csvLineCount = 0;
        foreach (string line in csvLines)
        {
            csvLineCount++;
            int currentBookId = int.Parse(line.Split(",")[1]);
            if (bookNumber == 0)
            {
                bookNumber = 1;
                allPreviousBooks = currentBookId - 1;
            }
            else if (csvLineCount == csvLines.Count)
            {
                bookCsvLines.Add(line);
                _books.Add(new Book(bookNumber, bookCsvLines));
            }
            else if (bookNumber != currentBookId - allPreviousBooks)
            {
                _books.Add(new Book(bookNumber, bookCsvLines));
                bookCsvLines.Clear();
                bookNumber++;
            }
            bookCsvLines.Add(line);
        }
    }

    public override string GetSearch(int searchDepth, string searchString)
    {
        if (searchDepth == 0)
        {
            return VolumeSearch(searchString);
        }
        else
        {
            return "";
        }
    }

    private string VolumeSearch(string searchString)
    {
        string[] splitSearchString = searchString.Split(" ");
        List<string> splitVolumeName = new List<string>{};
        foreach (string word in GetName().Split(" "))
        {
            splitVolumeName.Add(word);
        }

        double amountWordsMatched = 0;
        foreach (string searchWord in splitSearchString)
        {
            foreach (string nameWord in splitVolumeName)
            {
                if (searchWord.ToLower() == nameWord.ToLower())
                {
                    amountWordsMatched += 1;
                    break;
                }
            }
        }

        if (amountWordsMatched / splitSearchString.Length >= 0.5)
        {
            return $"Matched: {GetName()}:\n{GetAllBooks()}";
        }
        else
        {
            return ""; 
        }
    }

    private string GetAllBooks()
    {
        string books = "";
        foreach (Book book in GetBooks())
        {
            books = books + $"{book.GetName()}\n";
        }
        return books;
    }

    private List<Book> GetBooks()
    {
        return _books;
    }
}