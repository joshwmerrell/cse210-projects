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
            int verseNumber = int.Parse(line.Split(",")[15]);
            List<string> reversedCsvSplitList = new List<string>{};
            foreach (string part in line.Split('"'))
            {
                reversedCsvSplitList.Insert(0, part);
            }
            string verseItself = reversedCsvSplitList[5];
            _verses.Add(new Verse(verseNumber, new List<string>{verseItself}));
        }
    }
}