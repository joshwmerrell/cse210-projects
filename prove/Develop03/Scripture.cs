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
            _words.Add(new Word(word));
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

    public void BlankOutWords()
    {
        int i = 0;
        int amountOfWordsToBlank = GetRandomInt(3, 1);
        if (amountOfWordsToBlank >= AmountOfVisibleWords())
        {
            amountOfWordsToBlank = 1;
        }
        while (i != amountOfWordsToBlank)
        {
            Word word = _words[GetRandomInt(AmountOfWords() - 1)];
            if (word.IsVisible())
            {
                word.MakeBlank();
                i++;
            }
        }
    }

    public int AmountOfVisibleWords()
    {
        int i = 0;
        foreach (Word word in _words)
        {
            if (word.IsVisible())
            {
                i++;
            }
        }
        return i;
    }

    private int AmountOfWords()
    {
        return _words.Count;
    }

    private int GetRandomInt(int maxInt, int minInt = 0)
    {
        Random random = new Random();
        return random.Next(minInt, maxInt + 1);
    }
}