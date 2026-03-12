public class Scripture
{
    private string _reference;
    private List<Word> _words = new List<Word>{};

    public Scripture(string reference = "John 11:35", string words = "Jesus wept.")
    {
        _reference = reference;
        // In the scope of this program, even though it is required, the Reference class is redundant and unnessesary.
        // That is why this will be the only time this class will be 'referenced' ;)
        Reference reference1 = new Reference(_reference);
        string[] wordsSplit = words.Split();
        foreach (string word in wordsSplit)
        {
            _words.Add(new Word(word, true));
        }
    }

    public string GetScripture()
    {
        string words = "";
        foreach (Word word in _words)
        {
            words = words + $"{word.GetWord()} ";
        }
        return $"{_reference}\n\n{words}";
    }

    public string BlankOutWords()
    {
        //
        return "";
        //
    }
}