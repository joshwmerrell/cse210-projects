public class MathAssignment : Assignment
{
    private string _textSection;
    private string _problems;

    public MathAssignment(string topic = "Math", string studentName = "Unknown", string problems = "?-?", string textSection = "?.?") : base(topic, studentName)
    {
        _textSection = textSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return "Section " + _textSection + " Problems " + _problems;
    }
}