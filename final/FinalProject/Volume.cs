public class Volume : Scripture
{
    private List<string> _booksNames = new List<string>{};

    public Volume(List<string> volumeCsvLines) : base(volumeCsvLines[0])
    {
        SetScripture(volumeCsvLines);
    }

    protected override void SetScripture(List<string> csvList)
    {
        string previousBookName = "";
        
        foreach (string line in csvList)
        {
            // Gets book name.
            List<string> reverseLine = new List<string>{};
            foreach (string part in line.Split('"'))
            {
                reverseLine.Insert(0, part);
            }
            string verseName = reverseLine[3];
            List<string> reverseVerseName = new List<string>{};
            foreach (string piece in verseName.Split(" "))
            {
                reverseVerseName.Insert(0, piece);
            }
            reverseVerseName.Remove(reverseVerseName[0]);
            List<string> bookNameSplit = new List<string>{};
            foreach (string piece in reverseVerseName)
            {
                bookNameSplit.Insert(0, piece);
            }
            string bookName = "";
            int index = 0;
            foreach (string piece in bookNameSplit)
            {
                bool lastPiece = index == bookNameSplit.Count - 1;
                if (lastPiece)
                {
                    bookName += piece;
                }
                else
                {
                    bookName += $"{piece} ";
                }
                index += 1;
            }

            // Add new book name.
            if (bookName != previousBookName)
            {
                _booksNames.Add(bookName);
            }

            // Assign a new previous book name.
            previousBookName = bookName;
        }

        // foreach (string newBookLine in csvList)
        // {
        //     string bookName = newBookLine.Split(",")[5];
        //     bool bookNameHasQuotes = bookName.Split('"').Length > 1;
        //     if (bookNameHasQuotes)
        //     {
        //         bookName = bookName.Split('"')[1];
        //     }
        //     _booksNames.Add(bookName);
        // }
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
            result = $"{_name}:";
            foreach (string book in _booksNames)
            {
                result += $"\n {book}";
            }
            result = $"\n\n{result}";
        }
        return result;
    }
}