using System;

class Program
{
    static void Main(string[] args)
    {
        /*Reference Reference1 = new Reference("D&C", 6, 36);
        Scripture Scripture1 = new Scripture(Reference1, "Look unto me in every thought. Doubt not, fear not.");
        */
        Scripture Scripture1 = new Scripture();
        Scripture1.Display(0);
        Console.Write("Press enter to continue or type \"quit\" to quit.");
        string UserInput = Console.ReadLine();
        while (UserInput != "quit" && UserInput != "QUIT" && Scripture1.GetShownWords() != 0) {
            Scripture1.Display(2);
            Console.WriteLine("Press enter to continue or type \"quit\" to quit.");
            UserInput = Console.ReadLine();
        }
    }
}