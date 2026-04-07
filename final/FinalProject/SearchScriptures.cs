using System.IO.Pipelines;

public class SearchScriptures
{
    
    private List<string> _commands = new List<string>{"volume", "book", "verse", "word"};
    private int _searchDepth;
    private List<Volume> _scriptures = new List<Volume>{};
    private string _result = "Please enter a command and a search inquiry.";

    public SearchScriptures(List<string> scripturesCsvLines, string inquiry)
    {
        SetScriptures(scripturesCsvLines);
        Console.WriteLine(Result(inquiry));
    }

    private void SetScriptures(List<string> lines)
    {
        List<string> volumeCsvLines = new List<string>{};
        string previousVolumeNumber = "0";
        int lineCount = 0;
        foreach (string line in lines)
        {
            lineCount++;
            string volumeNumber = line.Split(',')[0];
            if (previousVolumeNumber == "0")
            {
            }
            else if (lineCount == lines.Count)
            {
                volumeCsvLines.Add(line);
                _scriptures.Add(new Volume(volumeCsvLines));
            }
            else if (previousVolumeNumber != volumeNumber)
            {
                _scriptures.Add(new Volume(volumeCsvLines));
                volumeCsvLines.Clear();
            }
            volumeCsvLines.Add(line);
            previousVolumeNumber = volumeNumber;
        }

    }

    public string Result(string inquiry)
    {
        if (CommandAndSearchAreGiven(inquiry))
        {
            SetResult("Result found");
        }
        return GetResult(); 
    }

    private void SetResult(string result)
    {
        _result = result;
    }

    private string GetResult()
    {
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