public class CountdownTimer : Timer
{
    public CountdownTimer(int seconds = 5, string message = "") : base(seconds, message)
    {
        int i = GetSeconds();
        while (i != 0)
        {
            Console.Clear();
            Console.WriteLine(GetMessage() + $" {i}");
            Thread.Sleep(1000);
            i--;
        }
    }
}