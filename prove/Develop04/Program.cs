using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt activityOptions = new Prompt(new List<string>{"Breathing Activity", "Reflection Activity", "Listening Activity", "Quit"});

        // Console.WriteLine("Activity Options");
        // activityOptions.ListAllPrompts();

        // bool continueProgram = true;
        // while (continueProgram)
        // {
        //     bool incorrectChoice = true; 
        //     while (incorrectChoice)
        //     {
        //         Console.Clear();
        //         Console.Write("Select a choice from the menu: ");
        //         string choice = Console.ReadLine();
        //         if (choice == "1")
        //         {
        //             incorrectChoice = false;
        //             new BreathingActivity();
        //         }
        //         else if (choice == "2")
        //         {
        //             incorrectChoice = false;
        //             new ReflectionActivity();
        //         }
        //         else if (choice == "3")
        //         {
        //             incorrectChoice = false;
        //             new ListeningActivity();
        //         }
        //         else if (choice == "4")
        //         {
        //             incorrectChoice = false;
        //             continueProgram = false;
        //         }
        //     }  
        // }

        // new BreathingActivity();
        // new ListeningActivity();
        // new ReflectionActivity();

        new CountdownTimer(5, "");
    }
}