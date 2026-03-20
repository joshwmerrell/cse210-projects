public class BreathingActivity : Activity
{
    private int _activityDuration;

    public BreathingActivity(string title = "Breathing Activity", string startingMessage = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing", string completionMessage = "Congradulations, you have completed the Activity!") : base(title, startingMessage, completionMessage)
    {
        Start();
        Main();
        End();
    }

    private void Main()
    {
        AskForDuration();
        Console.Clear();
        PauseToGetReady();
        Breathe();
    }

    private void AskForDuration()
    {
        Console.Write("How long in seconds would you like for your session? (Enter whole number; Minimum 15) ");
        _activityDuration = int.Parse(Console.ReadLine());
    }

    private void PauseToGetReady()
    {
        new AnimatedTimer(5, "GetReady...");
    }
    
    private void Breathe()
    {
        SetCompletionMessageDuration(_activityDuration % 10);
        int amountOfIterations = (_activityDuration - GetCompletionMessageDuration()) / 10;
        if (amountOfIterations < 5)
        {
            SetCompletionMessageDuration(GetCompletionMessageDuration() + 10);
            amountOfIterations = amountOfIterations - 1;
        }
        int i = 0;
        while (i != amountOfIterations)
        {
            BreatheIn();
            BreatheOut();
            i++;
        }
    }

    private void BreatheIn()
    {
        new CountdownTimer(4, "Breathe in...");
    }

    private void BreatheOut()
    {
        new CountdownTimer(6, "Breathe out...");
    }
}