public class Journal
{
    public string _entries;
    public string _entry;

    public void AddEntry(string prompt)
    {
        string theCurrentTime = DateTime.Now.ToShortDateString();
        string entry = $"{theCurrentTime}\nPrompt: {prompt}\nEntry: {_entry}\n\n";
        if (_entries == "")
        {
            _entries = entry;
        }
        else
        {
            _entries = _entries + entry;
        }
    }
}