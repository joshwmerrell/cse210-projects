public class Volume : Scripture
{
    private List<string> _booksNames = new List<string>{};

    public Volume(List<string> volumeBooksLines) : base(volumeBooksLines[0])
    {
        SetScripture(volumeBooksLines);
    }

    protected override void SetScripture(List<string> csvList)
    {
        foreach (string newBookLine in csvList)
        {
            string bookName = newBookLine.Split(",")[5];
            bool bookNameHasQuotes = bookName.Split('"').Length > 1;
            if (bookNameHasQuotes)
            {
                bookName = bookName.Split('"')[1];
            }
            _booksNames.Add(bookName);
        }
    }

    protected override void SetNumber(string csvLine)
    {
        _number = int.Parse(csvLine.Split(",")[0]);
    }

    protected override void SetName(string csvLine)
    {
        _name = csvLine.Split(",")[6].Split('"')[1];
    }

    public override string GetSearchResult(string searchingFor)
    {
        string result = "";
        double amountOfWordsMatched = 0;
        string[] searchingForSplit = searchingFor.Split(" ");
        foreach (string word in searchingForSplit)
        {
            foreach (string pieceOfName in _name.Split(" "))
            {
                if (word.ToLower() == pieceOfName.ToLower())
                {
                    amountOfWordsMatched += 1;
                    break;
                }
            }
        }
        if (amountOfWordsMatched == searchingForSplit.Length)
        {
            result = result + $"{_name}:";
            foreach (string book in _booksNames)
            {
                result = result + $"\n {book}";
            }
            result = $"\n\n{result}";
        }
        return result;
    }
}