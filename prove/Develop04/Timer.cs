using System.Net.Security;

public class Timer
{
    private int _seconds;
    private string _message;
    
    protected Timer(int seconds, string message)
    {
        _seconds = seconds;
        _message = message;
    }

    protected int GetSeconds()
    {
        return _seconds;
    }

    protected string GetMessage()
    {
        return _message;
    }
}