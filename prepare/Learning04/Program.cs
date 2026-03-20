using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Multiplication", "Joshua Merrell");
        Assignment assignment1Blank = new Assignment();
        MathAssignment assignment2 = new MathAssignment("Fractions", "Joshua Merrell", "8-19", "5.2");
        MathAssignment assignment2Blank = new MathAssignment();
        WritingAssignment assignment3 = new WritingAssignment("World History", "Joshua Merrell", "The Fallout of the Great War");
        WritingAssignment assignment3Blank = new WritingAssignment();
        DisplayAndBlankLine(assignment1.GetSummary());
        DisplayAndBlankLine(assignment1Blank.GetSummary());
        DisplayAndBlankLine(assignment2.GetSummary() + "\n" + assignment2.GetHomeworkList());
        DisplayAndBlankLine(assignment2Blank.GetSummary() + "\n" + assignment2Blank.GetHomeworkList());
        DisplayAndBlankLine(assignment3.GetSummary() + "\n" + assignment3.GetWritingInformation());
        DisplayAndBlankLine(assignment3Blank.GetSummary() + "\n" + assignment3Blank.GetWritingInformation());

        void DisplayAndBlankLine(string toBeDisplayed = "")
        {
            Console.WriteLine(toBeDisplayed + "\n");
        }
    }
}