public class Entry
{
    public string _dateAndTime = DateTime.Now.ToShortTimeString() + " - " + DateTime.Now.ToLongDateString();
    public string _entryPrompt;
    public string _entry;

    public string GetEntry()
    {
        Prompt entryPrompts = new Prompt();
        entryPrompts._prompts = new List<string>{"Who was the most interesting person I interacted with today?","What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};
        _entryPrompt = entryPrompts.GetRandomPrompt();
        Console.WriteLine($"\n\nPrompt: {_entryPrompt}");
        Console.Write("Entry: ");
        _entry = Console.ReadLine();
        return $"{_dateAndTime}\nPrompt: {_entryPrompt}\nEntry: {_entry}";
    }
}