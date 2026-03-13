public class Reference
{
    private string _book;
    private string _chapter;
    private string _verses;

    public Reference(string reference)
    {
        string[] bookAndNumbers = reference.Split(" ");
        if (bookAndNumbers.Length > 2)
        {
            string[] chapterAndVerses = bookAndNumbers[2].Split(":");
            _book = bookAndNumbers[0] + " " + bookAndNumbers[1];
            _chapter = chapterAndVerses[0];
            _verses = chapterAndVerses[1];
        }
        else
        {
            string[] chapterAndVerses = bookAndNumbers[1].Split(":");
            _book = bookAndNumbers[0];
            _chapter = chapterAndVerses[0];
            _verses = chapterAndVerses[1];
        }

    }

    public string GetReference()
    {
        return _book + " " + _chapter + ":" + _verses;
    }
}