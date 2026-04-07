public class Chapter : Scripture
{
    List<Verse> _verses = new List<Verse>{};
    public Chapter(int number, List<string> chapterCsvLines) : base()
    {
        SetNumber(number);
        SetScriptures(chapterCsvLines);
    }

    protected override void SetScriptures(List<string> csvLines)
    {
        foreach (string line in csvLines)
        {
            int verseNumber = GetVerseNumber(line);
            List<string> verseNames = GetVerseNames(line);
            List<string> reversedCsvSplitList = new List<string>{};
            foreach (string part in line.Split('"'))
            {
                reversedCsvSplitList.Insert(0, part);
            }
            string verseItself = reversedCsvSplitList[5];
            _verses.Add(new Verse(verseNumber, verseNames, new List<string>{verseItself}));
        }
    }

    private int GetVerseNumber(string csvLine)
    {
        List<string> reversedCsvLineSplitByQuotationMark = new List<string>{};
        foreach (string piece in csvLine.Split('"'))
        {
            reversedCsvLineSplitByQuotationMark.Insert(0, piece);
        }
        // Reverse the next piece again!
        // GET SAME SOLUTION FROM BOOK.CS
        // 10 instead of 6 (+2 or +4) if there are words quoted within the scripture. If words quoted, the [6] will be "".
        // BECAUSE OF THIS CHANGE OF THERE BEING QUOTED TEXT WITHIN THE VERSE, THERE WILL BE VERSES IN THE D&C AND POFGP INCOMPLETE.
        int csvPieceIndexWithinLine = 6;
        string csvPiece = reversedCsvLineSplitByQuotationMark[csvPieceIndexWithinLine];
        while (csvPiece == "")
        {
            csvPieceIndexWithinLine += 2;
            csvPiece = reversedCsvLineSplitByQuotationMark[csvPieceIndexWithinLine];
        }
        List<string> reversedCsvPieceSplitByComma = new List<string>{};
        foreach (string part in csvPiece.Split(","))
        {
            reversedCsvPieceSplitByComma.Insert(0, part);
        }
        int number = int.Parse(reversedCsvPieceSplitByComma[1]);
        return number;
    }

    private List<string> GetVerseNames(string csvLine)
    {
        List<string> reversedCsvLineSplitByQuotationMark = new List<string>{};
        foreach (string piece in csvLine.Split('"'))
        {
            reversedCsvLineSplitByQuotationMark.Insert(0, piece);
        }
        string shortName = reversedCsvLineSplitByQuotationMark[1];
        string longName = reversedCsvLineSplitByQuotationMark[3];
        return new List<string>{shortName, longName};

    }

    public override string GetSearch(int searchDepth, string searchString)
    {
        // if (searchDepth == 0)
        // {
        //     return ChapterSearch(searchString);
        // }
        // else
        // {
            
        // }
        string verseSearchResult = "";
        foreach (Verse verse in GetVerses())
        {
            verseSearchResult = verseSearchResult + $"{verse.GetSearch(searchDepth - 1, searchString)}";
        }
        return verseSearchResult;
    }

    // private string ChapterSearch(string searchString)
    // {
    //     return "";
    // }

    private List<Verse> GetVerses()
    {
        return _verses;
    }

    public int GetVerseAmount()
    {
        return _verses.Count;
    }
}