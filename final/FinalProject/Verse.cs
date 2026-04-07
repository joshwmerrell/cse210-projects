public class Verse : Scripture
{
    private string _shortName;
    private string _longName;
    private string _wholeVerse;
    List<Word> _words = new List<Word>{};

    public Verse(int number, List<string> names, List<string> verseInListFormat) : base()
    {
        SetNumber(number);
        SetNames(names);
        SetScriptures(verseInListFormat);
    }

    private void SetNames(List<string> names)
    {
        _shortName = names[0];
        _longName = names[1];
    }

    protected override void SetScriptures(List<string> verseInListFormat)
    {
        string verse = verseInListFormat[0];
        _wholeVerse = verse;
        foreach (string wordAndPunctuation in verse.Split(" "))
        {
            _words.Add(new Word(wordAndPunctuation));
        }
    }

    public override string GetSearch(int searchDepth, string searchString)
    {
        if (searchDepth == 0)
        {
            return VerseSearch(searchString);
        }
        else
        {
            return ""; 
        }
    }

    private string VerseSearch(string searchString)
    {
        if (searchString.ToLower() == GetShortName().ToLower() || searchString.ToLower() == GetLongName().ToLower())
        {
            return $"Matched: {GetLongName()}\n{GetWholeVerse()}";
        }
        else
        {
            return "";
        }
    }

    private string GetShortName()
    {
        return _shortName;
    }

    private string GetLongName()
    {
        return _longName;
    }

    private string GetWholeVerse()
    {
        return _wholeVerse;
    }
}