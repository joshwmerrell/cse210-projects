public class Word
{
    private List<string> _alphabet = new List<string>{"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    private List<int> _lettersPositions = new List<int>{};
    public Word(string wordAndPunctuation)
    {
        foreach (char charLetterOrPunctuation in wordAndPunctuation.ToCharArray())
        {
            string letterOrPunctuation = charLetterOrPunctuation.ToString();
            int i = 0;
            foreach (string alph in GetAlphabet())
            {
                if (letterOrPunctuation == alph)
                {
                    _lettersPositions.Add(i);
                    break;
                }
                i++;
            }
        }
    }

    public string Get()
    {
        string word = "";
        foreach (int i in GetLettersPositions())
        {
            word = word + GetAlphabet()[i];
        }
        return word;
    }

    private List<string> GetAlphabet()
    {
        return _alphabet;
    }

    private List<int> GetLettersPositions()
    {
        return _lettersPositions;
    }
}