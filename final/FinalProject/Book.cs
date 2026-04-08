public class Book : Scripture
{
    private List<int> _verseAmountInEachChapter = new List<int>{};

    public Book(List<string> bookCsvList) : base(bookCsvList[0])
    {
        SetScripture(bookCsvList);
    }

    protected override void SetScripture(List<string> csvList)
    {
        // Sets the verse amount in each chapter list.
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