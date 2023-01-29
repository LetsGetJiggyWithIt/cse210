using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        string userChoice = "";
        BreathingActivity Breathe = new BreathingActivity ();
        ReflectionActivity Reflect = new ReflectionActivity ();
        ListingActivity List = new ListingActivity();

        while (userChoice != "4") {
            Console.WriteLine("\n\nWelcome to your Mindfullness program! Which activity would you like to try?");
            Console.Write("1. Breathing Activity\n2. Reflection Activity\n3. Listing Activity\n4. Quit\n> ");
            userChoice = Console.ReadLine();
            Console.WriteLine();
            if (userChoice == "1") {
                Breathe.StartActivity();
            }
            else if (userChoice == "2") {
                Reflect.StartActivity();
            }
            else if (userChoice == "3") {
                List.StartActivity();
            }
            else {
                Console.WriteLine("Goodbye.");
                userChoice = "4";
            }
        }
    }
}