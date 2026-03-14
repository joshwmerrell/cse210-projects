using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

public class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public string GetWord()
    {
        string word = _word;
        if (_isHidden)
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

    public void MakeHidden()
    {
        _isHidden = true;
    }

    public bool IsVisible()
    {
        bool isVisible = true;
        if (_isHidden)
        {
            isVisible = false;
        }
        return isVisible;
    }
}