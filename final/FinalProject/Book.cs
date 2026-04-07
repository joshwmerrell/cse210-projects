public class Book : Scripture
{
    private List<Chapter> _chapters = new List<Chapter>{};

    public Book(int number, List<string> bookCsvLines) : base()
    {
        SetNumber(number);
        SetName(bookCsvLines[0].Split(",")[5]);
        SetScriptures(bookCsvLines);
    }

    protected override void SetName(string name)
    {
        if (name.Split('"').Length < 2)
        {
            _name = name;
        }
        else
        {
            _name = name.Split('"')[1];
        }
    }

    override protected void SetScriptures(List<string> csvLines)
    {
        List<string> chapterCsvLines = new List<string>{};
        int previousChapterNumber = 0;
        int csvLineCount = 0;
        foreach (string line in csvLines)
        {
            csvLineCount++;
            int chapterNumber = GetChapterNumber(line);
            if (previousChapterNumber == 0)
            {
            }
            else if (csvLineCount == csvLines.Count)
            {
                chapterCsvLines.Add(line);
                _chapters.Add(new Chapter(chapterNumber, chapterCsvLines));
            }
            else if (previousChapterNumber != chapterNumber)
            {
                _chapters.Add(new Chapter(previousChapterNumber, chapterCsvLines));
                chapterCsvLines.Clear();
            }
            chapterCsvLines.Add(line);
            previousChapterNumber = chapterNumber;
        }
    }

    private int GetChapterNumber(string csvLine)
    {
        List<string> reversedCsvLineSplitByQuotationMark = new List<string>{};
        foreach (string piece in csvLine.Split('"'))
        {
            reversedCsvLineSplitByQuotationMark.Insert(0, piece);
        }
        // Reverse the next piece again!
        // 10 instead of 6 (+2 or +4) if there are words quoted within the scripture. If words quoted, the [2] will be "".
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
        int number = int.Parse(reversedCsvPieceSplitByComma[2]);
        return number;
    }
}