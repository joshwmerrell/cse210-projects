public class ReflectionActivity : Activity
{
    private int _activityDuration;
    private List<string> _reflectivePrompts = new List<string>{};
    private List<string> _reflectiveQuestions = new List<string>{};

    public ReflectionActivity(string name = "Reflection Activity", string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", string completionMessage = "Congradulations, you have completed the Activity!", string reflectivePromptsSeparatedByCommas = "Think of a time when you stood up for someone else., Think of a time when you did something really difficult., Think of a time when you helped someone in need., Think of a time when you did something truly selfless.", string reflectiveQuestionsSeparatedByCommas = "Why was this experience meaningful for you?, Have you ever done anything like this before?, How did you get started?, How did you feel when it was complete?, What made this time different than other times when you were not as successful?, What is your favorite thing about this experience?, What could you learn from this experience that applies to other situations?, What did you learn about yourself through this experience?, How can you keep this experience in mind in the future?") : base(name, description, completionMessage)
    {
        SetReflectivePromptsList(reflectivePromptsSeparatedByCommas);
        SetReflectiveQuestionsList(reflectiveQuestionsSeparatedByCommas);
        Start();
        Main();
        End();
    }

    private void SetReflectivePromptsList(string promptsSeparatedByCommas)
    {
        foreach (string prompt in promptsSeparatedByCommas.Split(", "))
        {
            _reflectivePrompts.Add(prompt);
        }
    }

    private void SetReflectiveQuestionsList(string questionsSeparatedByCommas)
    {
        foreach (string question in questionsSeparatedByCommas.Split(", "))
        {
            _reflectiveQuestions.Add(question);
        }
    }

    private void Main()
    {
        GetActivityDuration();
        Console.Clear();
        PauseToGetReady();
        GiveThoughtfulPrompt();
        GiveReflectiveQuestions(2);
    }

    private void GetActivityDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _activityDuration = int.Parse(Console.ReadLine());
    }

    private void PauseToGetReady()
    {
        new AnimatedTimer(5, "GetReady...");
    }

    private void GiveThoughtfulPrompt()
    {
        Console.WriteLine("Consider the following:\n");
        Console.WriteLine($"--- {_reflectivePrompts[new Random().Next(0, _reflectivePrompts.Count)]} ---\n");
        Console.Write("Press enter when you are ready to continue...");
        Console.ReadLine();
    }

    private void GiveReflectiveQuestions(int numberOfQuestions)
    {
        List<int> questionsDurations = new List<int>{};
        List<int> questionsIndexes = new List<int>{};
        int extraSeconds = _activityDuration % numberOfQuestions;
        int secondsPerQuestion = (_activityDuration - extraSeconds) / numberOfQuestions;
        int i = 0;
        int previousIndex = _reflectiveQuestions.Count;
        while (i != numberOfQuestions)
        {
            questionsDurations.Add(secondsPerQuestion);
            int questionIndex = new Random().Next(0, _reflectiveQuestions.Count);
            while (questionIndex == previousIndex)
            {
                questionIndex = new Random().Next(0, _reflectiveQuestions.Count);
            }
            questionsIndexes.Add(questionIndex);
            previousIndex = questionIndex;
            i++;
        }
        int index = 0;
        while (index != questionsDurations.Count)
        {
            if (extraSeconds != 0)
            {
                questionsDurations[index] += 1;
                extraSeconds -= 1;
            }
            index++;
        }
        i = 0;
        foreach (int questionIndex in questionsIndexes)
        {
            new AnimatedTimer(questionsDurations[i], _reflectiveQuestions[questionIndex]);
            i++;
        }
    }
}