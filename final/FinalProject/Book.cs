public class Book : Scripture
{
    // private List<Chapter> _chapters = new List<Chapter>{};

    public Book(int number, List<string> bookCsvLines) : base()
    {
        SetNumber(number);
        SetName(bookCsvLines[0].Split(",")[5]);
        SetScriptures(bookCsvLines);
    }

    protected override void SetName(string name)
    {
        if (name.Split('"').Length < 2)
        {
            _name = name;
        }
        else
        {
            _name = name.Split('"')[1];
        }
    }

    override protected void SetScriptures(List<string> csvLines)
    {
        
    }
}