public class SearchBook : Search
{
    public SearchBook(string command, string inquiry) : base()
    {
        SetSearchDepth(2);
    }
}