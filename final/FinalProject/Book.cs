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
            int chapterNumber = int.Parse(line.Split(",")[14]);
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
}