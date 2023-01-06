using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int input = 0;
        int sum = 0;
        float average = 0;
        int largest = 0;

        List<int> numList = new List<int>();
        Console.WriteLine("Enter a list of numbers. Type 0 when finished.");

        do {
            Console.Write("Enter a number: ");
            input = int.Parse(Console.ReadLine());
            numList.Add(input);
        } while (input != 0);
        numList.Remove(0);
        foreach (int number in numList)
        {
            sum += number;
            if (number > largest)
            {
                largest = number;
            };
        };
        average = sum / numList.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}