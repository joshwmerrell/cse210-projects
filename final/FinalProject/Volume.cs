public class Volume : Scripture
{
    private List<string> _booksNames = new List<string>{};

    public Volume(List<string> volumeBooksLines) : base(volumeBooksLines[0])
    {
        SetScripture(volumeBooksLines);
    }

    protected override void SetScripture(List<string> csvList)
    {
        // Sets the books names list.
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