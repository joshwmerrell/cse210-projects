using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");

        Resume resume1 = new Resume();
        resume1._name = "Joshua Merrell";
        resume1._jobs = new List<Job>{};

        Job job1 = new Job();
        job1._company = "AvantGuard Monitoring";
        job1._jobTitle = "Team Operator";
        job1._startYear = 2025;
        job1._endYear = 2026;
        resume1._jobs.Add(job1);

        Job job2 = new Job();
        job2._company = "Employment Express Pros";
        job2._jobTitle = "General Laborer";
        job2._startYear = 2024;
        job2._endYear = 2025;
        resume1._jobs.Add(job2);
        
        resume1.Display();
    }
}