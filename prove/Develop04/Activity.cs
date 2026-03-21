public class Activity
{
    private string _name;
    private string _startingMessage;
    private string _completionMessage;

    protected Activity(string name, string startingMessage, string completionMessage)
    {
        _name = name;
        _startingMessage = startingMessage;
        _completionMessage = completionMessage;
    }

    protected void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the " + _name + ".");
        Console.WriteLine();
        Console.WriteLine(_startingMessage);
        Console.WriteLine();
    }

    protected void End()
    {
        new AnimatedTimer(5, _completionMessage);
    }
}