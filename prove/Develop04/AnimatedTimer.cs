public class AnimatedTimer : Timer
{
    private List<string> _animationSteps = new List<string>{};
    public AnimatedTimer(int seconds = 5, string message = "", string animationStepsCombinedWithCommas = "|,/,-,\\") : base(seconds, message)
    {
        SetAnimationSteps(animationStepsCombinedWithCommas);
        RunTimer();
    }

    private void SetAnimationSteps(string stepsCombinedWithCommas)
    {
        string[] splitSteps = stepsCombinedWithCommas.Split(",");
        int i = 0;
        while (i != splitSteps.Length)
        {
            _animationSteps.Add(splitSteps[i]);
            i++;
        }
    }

    private void RunTimer()
    {
        int i = 0;
        while (i != GetSeconds())
        {
            int index = 0;
            while (i != _animationSteps.Count)
            {
                Console.Clear();
                Console.WriteLine(GetMessage() + _animationSteps[index]);
                Thread.Sleep(1000 / _animationSteps.Count);
                index++;
            }
            i++;
        }
    }
}