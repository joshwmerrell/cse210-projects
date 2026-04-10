public class Chapter : Scripture
{
    private List<string> _verses = new List<string>{};

    public Chapter(List<string> chapterCsvList) : base(chapterCsvList[0])
    {
        SetScripture(chapterCsvList);
    }

    protected override void SetScripture(List<string> csvList)
    {
        // Sets the verses list.
        foreach (string line in csvList)
        {
            List<string> reverseLine = new List<string>{};
            foreach (string part in line.Split('"'))
            {
                reverseLine.Insert(0, part);
            }
            // THIS DOESN'T ACCOUNT FOR QUOTES WITHIN THE VERSE LIKE IN D&C AND POFGP.
            _verses.Add(reverseLine[5]);
        }
    }

    protected override void SetNumber(string csvLine)
    {
        // Set number.
        List<string> reverseLine = new List<string>{};
        foreach (string part in csvLine.Split(","))
        {
            reverseLine.Insert(0, part);
        }
        // Account for verse titles with a number in the front.
        string[] verseNameSplitBySpace = reverseLine[0].Split('"')[1].Split(" ");
        string chapterColonVerse = verseNameSplitBySpace[1];
        if (verseNameSplitBySpace.Length > 2)
        {
            chapterColonVerse = verseNameSplitBySpace[2];
        }
        int chapterNumber = int.Parse(chapterColonVerse.Split(":")[0]);
        _number = chapterNumber;
    }

    protected override void SetName(string csvLine)
    {
        // Set name.
        List<string> reverseLine = new List<string>{};
        foreach (string part in csvLine.Split(","))
        {
            reverseLine.Insert(0, part);
        }
        string chapterName = reverseLine[1].Split('"')[1].Split(":")[0];
        _name = chapterName;
    }

    public override string GetSearchResult(string searchingFor)
    {
        // Display search result.
        string result = "";
        if (searchingFor.ToLower() == _name.ToLower())
        {
            result = $"{_name}";
            int verseNumber = 1;
            foreach (string verse in _verses)
            {
                result += $"\n\n  {verseNumber}.  {verse}";
                verseNumber += 1;
            }
            result = $"\n\n{result}";
        }
        return result;
    }
}