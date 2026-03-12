using System.Reflection.PortableExecutable;

public class Word
{
    private string _word;
    private bool _isBlank;

    public Word(string word, bool notBlank)
    {
        _word = word;
        if (notBlank == true)
        {
            _isBlank = false;
        }
        else if (notBlank == false)
        {
            _isBlank = true;
        }
    }

    public string GetWord()
    {
        string word = _word;
        if (_isBlank == true)
        {
            // Will be updated
            word = "___";
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
        if (_isBlank == true)
        {
            isVisible = false;
        }
        return isVisible;
    }

    private bool IsLetter(string letter)
    {
        return true;
    }
}