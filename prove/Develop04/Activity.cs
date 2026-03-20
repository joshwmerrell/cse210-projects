public class Activity
{
    private string _name;
    private string _startingMessage;
    private string _completionMessage;
    private int _completionMessageDuration;
    // protected int MINIMUM_COMPLETION_MESSAGE_DURATION = 5;

    protected Activity(string name, string startingMessage, string completionMessage)
    {
        _name = name;
        _startingMessage = startingMessage;
        _completionMessage = completionMessage;
    }

    protected void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the" , _name + ".");
        Console.WriteLine();
        Console.WriteLine(_startingMessage);
        Console.WriteLine();
    }

    protected void End()
    {
        new AnimatedTimer(_completionMessageDuration, _completionMessage);
    }

    protected void SetCompletionMessageDuration(int seconds = 5)
    {
        _completionMessageDuration = seconds;
    }

    protected int GetCompletionMessageDuration()
    {
        return _completionMessageDuration;
    }
}