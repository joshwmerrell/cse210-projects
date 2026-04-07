public class Chapter : Scripture
{
    public Chapter(int number, List<string> chapterCsvLines) : base()
    {
        SetNumber(number);
        SetScriptures(chapterCsvLines);
    }

    protected override void SetScriptures(List<string> csvLines)
    {
        
    }
}