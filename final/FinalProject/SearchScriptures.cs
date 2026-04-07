using System.IO.Pipelines;

public class SearchScriptures
{
    
    private List<string> _commands = new List<string>{"volume", "book", "chapter", "verse", "word"};
    private int _searchDepth;
    private List<Volume> _scriptures = new List<Volume>{};
    private string _result = "Please enter a command and a search inquiry.";

    public SearchScriptures(List<string> scripturesCsvLines, string inquiry)
    {
        if (CommandAndSearchAreGiven(inquiry))
        {
            SetScriptures(scripturesCsvLines);
            SetSearchDepth(GetCommand(inquiry));
            SetResult(GetSearchResult(GetSearchDepth(), GetSearchString(inquiry)));
        }
        Console.WriteLine(GetResult());
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

    private void SetSearchDepth(string commandGiven)
    {
        int i = 0;
        foreach (string command in GetCommands())
        {
            if (commandGiven == command)
            {
                _searchDepth = i;
                break;
            }
            i++;
        }
    }

    private string GetCommand(string inquiry)
    {
        return inquiry.Split("@ ")[0].ToLower();
    }

    private void SetResult(string result)
    {
        _result = result;
    }

    // 
    // 
    // 
    private string GetSearchResult(int searchDepth, string searchString)
    {
        string results = "Search Results:\n";
        foreach (Volume volume in GetScriptures())
        {
            string volumeSearchResult = volume.GetSearch(searchDepth, searchString);
            if (volumeSearchResult != "")
            {
                results = results + $"{volumeSearchResult}\n";
            }
        }
        if (results == "Search Results:\n")
        {
            results = "Nothing Found.";
        }
        return results;
    }
    // 
    // 
    //

    private int GetSearchDepth()
    {
        return _searchDepth;
    }

    private string GetSearchString(string inquiry)
    {
        return inquiry.Split("@ ")[1];
    }

    private string GetResult()
    {
        return _result;
    }

    private List<string> GetCommands()
    {
        return _commands;
    }

    private List<Volume> GetScriptures()
    {
        return _scriptures;
    }

    // private string GetSearchingFor(string inquiry)
    // {
    //     return inquiry.Split("@ ")[1].ToLower();
    // }
}