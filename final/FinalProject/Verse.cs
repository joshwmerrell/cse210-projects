public class Verse : Scripture
{
    private string _verse;

    public Verse(List<string> verseInListFormat) : base(verseInListFormat[0])
    {
        SetScripture(verseInListFormat);
    }

    protected override void SetScripture(List<string> csvList)
    {
        // Sets the verses list.
        string line = csvList[0];
        List<string> reverseLine = new List<string>{};
        foreach (string part in line.Split('"'))
        {
            reverseLine.Insert(0, part);
        }
        // THIS DOESN'T ACCOUNT FOR QUOTES WITHIN THE VERSE LIKE IN D&C AND POFGP.
        _verse = reverseLine[5];
    }

    protected override void SetNumber(string csvLine)
    {
        // Set number.
        List<string> reverseLine = new List<string>{};
        foreach (string part in csvLine.Split('"'))
        {
            reverseLine.Insert(0, part);
        }
        int verseNumber = int.Parse(reverseLine[1].Split(":")[1]);
        _number = verseNumber;
    }

    protected override void SetName(string csvLine)
    {
        // Set name.
        List<string> reverseLine = new List<string>{};
        foreach (string part in csvLine.Split('"'))
        {
            reverseLine.Insert(0, part);
        }
        string verseName = reverseLine[3];
        _name = verseName;
    }

    public override string GetSearchResult(string searchingFor)
    {
        // Display search result.
        string result = "";
        if (searchingFor.ToLower() == _name.ToLower())
        {
            result = $"\n\n{_name}\n\n{_verse}";
        }
        return result;
    }
}