using System.Data.SqlTypes;

public class Book : Scripture
{
    private List<int> _verseAmountsInChapters = new List<int>{};

    public Book(List<string> bookCsvList) : base(bookCsvList[0])
    {
        SetScripture(bookCsvList);
    }

    protected override void SetScripture(List<string> csvList)
    {
        // DANDC HAS MOSES INSTEAD OF POFGP FIX THIS!!!!!!!
        // Sets the verse amount in each chapter list.
        int chapterNumber = 0;
        int verseAmount = 0;
        int i = 0;
        foreach (string line in csvList)
        {
            int chapterId = int.Parse(line.Split(",")[2]);
            bool lastLine = i == csvList.Count - 1;
            if (i == 0)
            {
                chapterNumber = chapterId;
            }
            bool newChapter = chapterNumber != chapterId;
            if (newChapter || lastLine)
            {
                if (lastLine)
                {
                    verseAmount += 1;
                }
                _verseAmountsInChapters.Add(verseAmount);
                chapterNumber = chapterId;
                verseAmount = 0;
            }
            verseAmount += 1;
            i += 1;
        }
    }

    protected override void SetNumber(string csvLine)
    {
        _number = int.Parse(csvLine.Split(",")[1]);
    }

    protected override void SetName(string csvLine)
    {
        string name = csvLine.Split(",")[5];
        bool nameHasQuotes = name.Split('"').Length > 1;
        if (nameHasQuotes)
        {
            name = name.Split('"')[1];
        }
        _name = name;
    }

    public override string GetSearchResult(string searchingFor)
    {
        // Display search result.
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
            result += $"{_name}:";
            int chapterNumber = 0;
            foreach (int verseAmount in _verseAmountsInChapters)
            {
                chapterNumber += 1;
                result += $"\n {chapterNumber}:{verseAmount}";
            }
            result = $"\n\n{result}";
        }
        return result;
    }
}