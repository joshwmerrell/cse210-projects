public class Volume : Scripture
{
    private List<Book> _books = new List<Book>{};
    public Volume(List<string> volumeCsvLines) : base()
    {
        int i = 0;
        foreach (string line in volumeCsvLines)
        {
            if (i == 0)
            {
                SetNumber(int.Parse(line.Split(",")[0]));
                SetName(line.Split(",")[6].Split('"')[1]);
            }
            i++;
        }
    }

    override protected void SetWordsOfGod()
    {
        
    }
}