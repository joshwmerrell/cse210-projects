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
    }

    protected override void SetNumber(string csvLine)
    {
        // Set number.
    }

    protected override void SetName(string csvLine)
    {
        // Set name.
    }

    public override string GetSearchResult(string searchingFor)
    {
        // Display search result.
        return "";
    }
}