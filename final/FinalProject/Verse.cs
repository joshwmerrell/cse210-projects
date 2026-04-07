public class Verse : Scripture
{
    string wholeVerse;
    List<Word> _words = new List<Word>{};

    public Verse(int number, List<string> verseInListForm) : base()
    {
        SetNumber(number);
        SetScriptures(verseInListForm);
    }

    protected override void SetScriptures(List<string> verseInListForm)
    {
        string verse = verseInListForm[0];
        wholeVerse = verse;
        foreach (string wordAndPunctuation in verse.Split(" "))
        {
            _words.Add(new Word(wordAndPunctuation));
        }
    }
}