public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>{};

    public Scripture(string reference = "John 11:35", string words = "Jesus wept.")
    {
        string[] wordsSplit = words.Split(" ");
        foreach (string word in wordsSplit)
        {
            _words.Add(new Word(word));
        }
        _reference = new Reference(reference);
    }

    public string GetScripture()
    {
        string words = "";
        foreach (Word word in _words)
        {
            words = words + $"{word.GetWord()} ";
        }
        return $"{_reference.GetReference()}\n\n{words}";
    }

    public void BlankOutWords()
    {
        int i = 0;
        int amountOfWordsToBlank = GetRandomInt(5, 1);
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