using System.Dynamic;

public class Word
{
    private List<string> _alphabet = new List<string>{"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    private List<int> _lettersPositions = new List<int>{};
    public Word(string word)
    {
        SetLettersPositions(word);
    }

    private void SetLettersPositions(string word)
    {
        foreach (string letter in word.Split())
        {
            SetLetterPosition(letter);
        }
    }

    private void SetLetterPosition(string letter)
    {
        int i = 0;
        foreach (string alph in _alphabet)
        {
            if (letter == alph)
            {
                SetNewPosition(i);
                break;
            }
            i++;
        }
    }

    private void SetNewPosition(int i)
    {
        _lettersPositions.Add(i);
    }

    public string Get()
    {
        string word = "";
        foreach (int i in GetLettersPositions())
        {
            word = word + GetLetter(i);
        }
        return word;
    }

    private List<int> GetLettersPositions()
    {
        return _lettersPositions;
    }

    private string GetLetter(int i)
    {
        return _alphabet[i];
    }

}