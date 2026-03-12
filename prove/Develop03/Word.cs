using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

public class Word
{
    private string _word;
    private bool _isBlank;

    public Word(string word)
    {
        _word = word;
        _isBlank = false;
    }

    public string GetWord()
    {
        string word = _word;
        if (_isBlank)
        {
            char[] characters = word.ToCharArray();
            word = "";
            foreach (char c in characters)
            {
                if (char.IsLetter(c))
                {
                    word = word + "_";
                }
                else
                {
                    word = word + c;
                }
            }
        }
        return word;
    }

    public void MakeBlank()
    {
        _isBlank = true;
    }

    public bool IsVisible()
    {
        bool isVisible = true;
        if (_isBlank)
        {
            isVisible = false;
        }
        return isVisible;
    }
}