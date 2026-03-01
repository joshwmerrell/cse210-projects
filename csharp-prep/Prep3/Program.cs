using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep3 World!");
        
        int magicNumber = new Random().Next(0,100);
        int guess;
        Console.WriteLine("\nI picked a number between 0 and 100.");
        Console.WriteLine("What is the magic number?\n");
        // Console.WriteLine($"The magic number is {magicNumber}.\n");
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess == magicNumber)
            {
                Console.WriteLine("You guessed it!\n");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
        } while (guess != magicNumber);
          
    }
}