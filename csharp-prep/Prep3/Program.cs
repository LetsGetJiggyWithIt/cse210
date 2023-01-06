using System;

class Program
{
    static void Main(string[] args)
    {   
        Random randomNumber = new Random();
        int magicNumber = 0;
        int guess = 0;
        int guessAmount = 0;
        string keepPlaying = "yes";

        do {
            magicNumber = randomNumber.Next(1, 101);
            Console.WriteLine($"What is the magic number? {magicNumber}");
            guessAmount = 0;
            do {
                
                Console.Write("What is your guess? ");
                guessAmount ++;
                guess = int.Parse(Console.ReadLine());
            
                if (guess == magicNumber)
                {
                    Console.WriteLine($"You guessed it! It took you {guessAmount} tries.");
                }

                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }

                else
                {
                    Console.WriteLine("Higher");
                };
            } while (guess != magicNumber);
            Console.Write("Would you like to play again? ");
            keepPlaying = Console.ReadLine().ToLower();
            if (keepPlaying == "y")
            {
                keepPlaying = "yes";
            };
        } while (keepPlaying == "yes");
    }
}