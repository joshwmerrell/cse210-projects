public class JournalOld
{
    public string _entries;
    public string _entry;

    public void AddEntry(string prompt)
    {
        string theCurrentTime = DateTime.Now.ToShortTimeString();
        string theCurrentDate = DateTime.Now.ToLongDateString();
        string entry = $"{theCurrentDate} - {theCurrentTime}\nPrompt: {prompt}\nEntry: {_entry}\n\n";
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