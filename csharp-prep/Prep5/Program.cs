using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome() {
            Console.WriteLine("Welcome to the program!");
        };
        static string PromptUserName() {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        };
        static int PromptUserNumber() {
            Console.Write("Please enter your favorite number: ");
            return int.Parse(Console.ReadLine());
        };
        static float SquareNumber(int Number) {
            Console.Write("Please enter an integer: ");
            return (float)Math.Pow(Number, 2);
        };
        static void DisplayResult(string Name, float Square) {
            Console.WriteLine($"{Name}, the square of your number is {Square}.");
        };
        DisplayWelcome();
        string Name = PromptUserName();
        int FavNumber = PromptUserNumber();
        float Square = SquareNumber(FavNumber);
        DisplayResult(Name, Square);
    }
}