using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();

        int GetRandomInt()
        {
            Random random = new Random();
            return random.Next(1, 11);
        }

        int i = 1;
        while (i != 21)
        {
            fraction.SetTop(GetRandomInt());
            fraction.SetBottom(GetRandomInt());
            string spaceNoSpace = " ";
            if (i >= 10)
            {
                spaceNoSpace = "";
            }
            Console.WriteLine($"{spaceNoSpace}Fraction {i}: {fraction.GetFractionString()} or {fraction.GetDecimalValue()}");
            i++;
        }
    }
}