using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep2 World!");

        // A >= 90
        // B >= 80
        // C >= 70
        // D >= 60
        // F < 60

        Console.Write("\nWhat is your grade percentage? (Whole number only): ");
        string gradeString = Console.ReadLine();
        int gradeNumber = int.Parse(gradeString);
        
        string passingOrNotPassingMessage;

        if (gradeNumber >= 70)
        {
            passingOrNotPassingMessage = "Congradulations, you passed!";
        }
        else
        {
            passingOrNotPassingMessage = "I'm so sorry, but you didn't pass.";
        }

        string gradeLetter;
        string aOrAn = "a";

        if (gradeNumber >= 90)
        {
            gradeLetter = "A";
            aOrAn = "an";
        }
        else if (gradeNumber >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradeNumber >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradeNumber >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
            aOrAn = "an";
        }

        string plusOrMinus = "";
        int gradeSecondDigit = int.Parse(char.ToString(gradeString[1]));

        if (gradeSecondDigit >= 7 && gradeLetter != "A" && gradeLetter != "F")
        {
            plusOrMinus = "+";
        }
        else if (gradeSecondDigit <= 3 && gradeLetter != "F")
        {
            plusOrMinus = "-";
        }

        Console.WriteLine($"\n{passingOrNotPassingMessage} You recieved {aOrAn} {gradeLetter}{plusOrMinus}.\n");
    }
}