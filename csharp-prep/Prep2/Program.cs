using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What score percentage did you get? ");
        int score = int.Parse(Console.ReadLine());
        string grade = "None";
        string sign = "None";
        
        if (score >= 90)
        {
            grade = "A";
        }
        
        else if (score >= 80)
        {
            grade = "B";
        }
        
        else if (score >= 70)
        {
            grade = "C";
        }
        
        else if (score >= 60)
        {
            grade = "D";
        }
        
        else
        {
            grade = "F";
        };
        
        if ((score % 10) >= 7 && score < 90)
        {
            sign = "+";
        }
        else if ((score % 10) <= 3 && score >= 60)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        };
        
        Console.WriteLine($"You got a {grade}{sign}.");
        
        if (score >= 70)
        {
            Console.Write("Well done, you've passed!");
        }

        else
        {
            Console.Write("You may not have passed, but I believe you can do better next time!");
        };
    }
}