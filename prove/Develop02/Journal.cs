public class Journal
{
    public string _entries;
    public string _entry;

    public void DisplayEntries()
    {
        Console.WriteLine($"\n\nYour Journal:\n\n{_entries}");
    }
    public void AddEntry()
    {
        Entry entry = new Entry();
        _entry = entry.GetEntry();
        if (_entries == "")
        {
            _entries = _entry;
        }
        else
        {
            _entries = _entries + "\n\n" + _entry;
        }
    }
}