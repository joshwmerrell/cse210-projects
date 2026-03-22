public class ListingActivity : Activity
{
    private int _responceAmount;
    private List<string> _questions = new List<string>{};

    public ListingActivity(string name = "Listing Activity", string description = "This activity will help you reflect on the good things in your life.", string completionMessage = "Congradulations, you have completed the Activity!", string questionsSeparatedByCommas = "Who are the people that you appreciate?, What are personal strengths of yours?, Who are the people that you have helped this week?, When have you felt the Holy Ghost this month?, Who are some of your personal heroes?") : base(name, description, completionMessage)
    {
        SetQuestionsList(questionsSeparatedByCommas);
        Start();
        Main();
        End();
    }

    private void SetQuestionsList(string questionsSeparatedByCommas)
    {
        foreach (string question in questionsSeparatedByCommas.Split(", "))
        {
            _questions.Add(question);
        }
    }

    private void Main()
    {
        GetResponceAmount();
        Console.Clear();
        PauseToGetReady();
        GiveQuestion();
        GetResponces();
    }

    private void GetResponceAmount()
    {
        Console.Write("How many responces do you want to give? ");
        _responceAmount = int.Parse(Console.ReadLine());
    }

    private void PauseToGetReady()
    {
        new AnimatedTimer(5, "GetReady...");
    }

    private void GiveQuestion()
    {
        new CountdownTimer(7, $"List your responces to the following prompt:\n --- {_questions[new Random().Next(0, _questions.Count)]} ---\nYou may begin in:");
    }

    private void GetResponces()
    {
        int i = 0;
        while (i != _responceAmount)
        {
            Console.Write("> ");
            Console.ReadLine();
            i++;
        }
    }
}