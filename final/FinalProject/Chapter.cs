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
            List<string> reversedCsvSplitList = new List<string>{};
            foreach (string part in line.Split('"'))
            {
                reversedCsvSplitList.Insert(0, part);
            }
            string verseItself = reversedCsvSplitList[5];
            _verses.Add(new Verse(verseNumber, new List<string>{verseItself}));
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
        int number = int.Parse(reversedCsvPieceSplitByComma[1]);
        return number;
    }
}