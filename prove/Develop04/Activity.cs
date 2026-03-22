public class Activity
{
    private string _name;
    private string _description;
    private string _completionMessage;

    protected Activity(string name, string description, string completionMessage)
    {
        _name = name;
        _description = description;
        _completionMessage = completionMessage;
    }

    protected string GetStartingMessage()
    {
        return $"Welcome to the {_name}.\n\n{_description}\n";
    }

    protected void Start()
    {
        Console.Clear();
        Console.WriteLine(GetStartingMessage());
    }

    protected void End()
    {
        new AnimatedTimer(5, _completionMessage);
    }
}