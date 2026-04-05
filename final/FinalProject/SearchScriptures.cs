using System.IO.Pipelines;

public class SearchScriptures
{
    
    private List<string> _commands = new List<string>{"volume", "book", "verse", "word"};
    private int _searchDepth;
    private List<Volume> _scriptures = new List<Volume>{};
    private string _result = "Please enter a command and a search inquiry.";

    public SearchScriptures(string inquiry)
    {
        // SetScriptures();
        Console.WriteLine(Result(inquiry));
    }

    // 
    // 
    private void SetScriptures()
    {
        List<string> lines = new List<string>{};
        string[] csvLines = System.IO.File.ReadAllLines("lds-scriptures.csv");
        int i = 0;
        foreach (string line in csvLines)
        {
            while (i != 0)
            {
                lines.Add(line);
            }
            i++;
        }
        // SetVolumes(lines);
    }
    // 
    //

    // private void SetVolumes(List<string> lines)
    // {
        
    // }

    public string Result(string inquiry)
    {
        if (CommandAndSearchAreGiven(inquiry))
        {
            _result = "Result found";
        }
        return _result; 
    }

    private bool CommandAndSearchAreGiven(string inquiry)
    {
        if (inquiry.Split("@ ").Length > 1 && IsACommand(GetCommand(inquiry)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsACommand(string commandGiven)
    {
        bool IsCommand = false;
        foreach (string command in GetCommands())
        {
            if (commandGiven == command)
            {
                IsCommand = true;
                break;
            }
        }
        return IsCommand;
    }

    private List<string> GetCommands()
    {
        return _commands;
    }

    private string GetCommand(string inquiry)
    {
        return inquiry.Split("@ ")[0].ToLower();
    }

    private string GetSearchingFor(string inquiry)
    {
        return inquiry.Split("@ ")[1].ToLower();
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