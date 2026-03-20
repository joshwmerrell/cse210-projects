public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string topic = "Unknown", string studentName = "Unknown")
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return _studentName + " - " + _topic;
    }
}