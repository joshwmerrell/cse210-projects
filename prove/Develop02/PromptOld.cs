public class PromptOld
{
    public List<string> _prompts;

    public void DisplayPrompts()
    {
        int i = 1;
        foreach (string prompt in _prompts)
        {
            Console.WriteLine($"{i}. {prompt}");
            i++;
        }
    }

    public string GetRandomPrompt()
    {
        int index = new Random().Next(_prompts.Count);
        return _prompts[index];
    }
}