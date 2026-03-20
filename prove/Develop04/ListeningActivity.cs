public class ListeningActivity : Activity
{
    public ListeningActivity(string name = "Listening Activity", string startingMessage = "This activity will help you reflect on the good things in your life by having you list as many things you can in a certain area.", string completionMessage = "Congradulations, you have completed the Activity!") : base(name, startingMessage, completionMessage)
    {
        End();
    }
}