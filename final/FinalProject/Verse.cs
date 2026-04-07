public class Verse : Scripture
{
    string wholeVerse;
    List<Word> _words = new List<Word>{};

    public Verse(int number, List<string> csvLineInListForm) : base()
    {
        SetNumber(number);
        SetScriptures(csvLineInListForm);
    }

    protected override void SetScriptures(List<string> csvLineInListForm)
    {
        // string[] wordsAndPunctuationSplit = csvLineInListForm[0].Split(" ");
    }
}