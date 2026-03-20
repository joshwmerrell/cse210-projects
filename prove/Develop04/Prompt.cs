public class Prompt
{
    private List<string> _prompts = new List<string>{};

    public Prompt(List<string> prompts)
    {
        foreach (string prompt in prompts)
        {
            _prompts.Add(prompt);
        }
    }

    public void DisplayPrompt(int index)
    {
        Console.WriteLine(_prompts[index]);
    }

    public void DisplayRandomPrompt()
    {
        Console.WriteLine(_prompts[new Random().Next(0, _prompts.Count + 1)]);
    }

    public void ListAllPrompts()
    {
        int i = 1;
        foreach (string prompt in _prompts)
        {
            Console.WriteLine($"  {i}. {prompt}");
            i++;
        }
    }
}