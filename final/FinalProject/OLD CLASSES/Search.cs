public class Search
{
    private int _searchDepth;
    public Search()
    {
        
    }

    protected void SetSearchDepth(int depth)
    {
        _searchDepth = depth;
    }

    protected int GetSearchDepth()
    {
        return _searchDepth;
    }
}