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
    }

    protected override void SetNumber(string csvLine)
    {
        // Set number.
    }

    protected override void SetName(string csvLine)
    {
        // Set name.
    }

    protected override void DisplaySearchResult()
    {
        // Display search result.
    }
}