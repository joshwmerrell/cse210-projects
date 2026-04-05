abstract public class Scripture
{
    private int _number;
    private string _name;
    protected List<Scripture> _lightAndTruth;

    public Scripture()
    {
    }

    protected void SetNumber(int number)
    {
        _number = number;
    }

    protected void SetName(string name)
    {
        _name = name;
    }

    abstract protected void SetLightAndTruth();
}