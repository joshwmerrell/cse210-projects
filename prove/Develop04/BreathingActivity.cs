public class BreathingActivity : Activity
{
    private int _activityDuration = 0;
    private int _breatheInDuration = 3;
    private int _breatheOutDuration = 4;

    public BreathingActivity(string name = "Breathing Activity", string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing", string completionMessage = "Congradulations, you have completed the Activity!") : base(name, description, completionMessage)
    {
        Start();
        Main();
        End();
    }

    private void Main()
    {
        GetActivityDuration();
        Console.Clear();
        PauseToGetReady();
        Breathe();
    }

    private void GetActivityDuration()
    {
        while (_activityDuration < (_breatheInDuration + _breatheOutDuration))
        {
            Console.Write($"How long in seconds would you like for your session? (Enter whole number; Minimum {(_breatheInDuration + _breatheOutDuration)}) ");
            _activityDuration = int.Parse(Console.ReadLine()); 
        }
    }

    private void PauseToGetReady()
    {
        new AnimatedTimer(5, "GetReady...");
    }
    
    private void Breathe()
    {
        int extraActivityDuration = _activityDuration % (_breatheInDuration + _breatheOutDuration);
        int amountOfIterations = (_activityDuration - extraActivityDuration) / (_breatheInDuration + _breatheOutDuration);
        while (extraActivityDuration != 0)
        {
            if (extraActivityDuration != 0)
            {
               _breatheOutDuration += 1;
               extraActivityDuration -= 1; 
            }
            if (extraActivityDuration != 0)
            {
               _breatheInDuration += 1;
               extraActivityDuration -= 1;
            }
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
        new CountdownTimer(_breatheInDuration, "Breathe in...");
    }

    private void BreatheOut()
    {
        new CountdownTimer(_breatheOutDuration, "Breathe out...");
    }
}