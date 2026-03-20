public class WritingAssignment : Assignment
{
    public string _title;

    public WritingAssignment(string topic = "Writing", string studentName = "Unknown", string title = "Assignment Title") : base(topic, studentName)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return _title;
    }
}