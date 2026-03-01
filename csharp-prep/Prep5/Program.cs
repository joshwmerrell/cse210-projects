using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep5 World!");

        static void DisplayWelcome()
        {
           Console.WriteLine("Welcome to the Program!"); 
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            return int.Parse(Console.ReadLine());
        }

        static int PromptUserBirthYear()
        {
            Console.Write("Please enter the year you were born: ");
            return int.Parse(Console.ReadLine());
        }

        Console.WriteLine();
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userBirthYear = PromptUserBirthYear();
        int currentYear = DateTime.Now.Year;
        Console.WriteLine($"Brother {userName}, the square of your number is {Math.Pow(userNumber, 2)}.");
        Console.WriteLine($"Brother {userName}, you will turn {currentYear - userBirthYear} this year.\n");
        
    }
}