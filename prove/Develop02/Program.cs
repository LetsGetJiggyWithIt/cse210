using System;

class Program
{
    static void Main(string[] args)
    {   int UserChoice = 0;
        Console.WriteLine("Welcome to your Digital Journal! How can I help you today?\n");
        string CurrentPrompt = "";
        string PromptFile = @"JournalPromptFile.txt";
        string UserInput = "";
        bool UserSaved = false;
        JournalPrompts PromptList = new JournalPrompts();
        Journal CurrentJournal = new Journal();
        if (File.Exists(PromptFile)) {
            string[] read = File.ReadAllLines(PromptFile);
            foreach(string line in read){
                PromptList.AddPrompt(line);
            }
        }
        while (UserChoice != 5) {
            Console.Write("1.Create an Entry\n2.Display Entries\n3.Load from file\n4.Save to file\n5.Exit\n>");
            UserChoice = int.Parse(Console.ReadLine());
            switch (UserChoice) {
                case 1:
                    CurrentPrompt = $"{PromptList.RandomPrompt()}";
                    Console.Write($"{CurrentPrompt} ");
                    UserInput = Console.ReadLine();
                    CurrentJournal.CreateEntry(CurrentPrompt, UserInput);
                    Console.WriteLine("\nEntry successfully added!\n");
                    break;
                case 2:
                    CurrentJournal.Display();
                    break;
                case 3:
                    Console.Write("Enter the exact file path to the file you would like to load from: ");
                    string LoadFileName = Console.ReadLine();
                    if (File.Exists(LoadFileName)) {
                        CurrentJournal.ClearJournal();
                        CurrentJournal.Import(LoadFileName);
                        Console.WriteLine($"Journal successfully loaded from {LoadFileName}");
                    }
                    else {
                        Console.WriteLine($"File {LoadFileName} does not exist. Perhaps it was misspelled?");
                    }
                    break;
                case 4:
                    Console.Write("Enter the exact file path to the file you would like to save to: ");
                    string SaveFileName = Console.ReadLine();
                    if (File.Exists(SaveFileName)) {
                        Console.Write("This file already exists. Would you like to overwrite it? (y/n)");
                        string UserConfirm = Console.ReadLine().ToLower();
                        if (UserConfirm != "y" && UserConfirm != "yes"){
                            Console.WriteLine("User abort.");
                            break;
                        }
                    }
                    CurrentJournal.Export(SaveFileName);
                    UserSaved = true;
                    Console.WriteLine($"File saved successfully to {SaveFileName}");
                    break;
                case 5:
                    if (UserSaved == false) {
                        Console.WriteLine("Your changes have not been saved. Are you sure you would like to quit? (y/n)");
                        string QuitConfirm = Console.ReadLine().ToLower();
                        if (QuitConfirm != "y" && QuitConfirm != "yes") {
                            UserChoice = 0;
                            break;
                        }
                    }
                    Console.WriteLine("Goodbye!");
                    break;
            }
            if (UserChoice != 5) {
                Console.WriteLine("What else can I help you with?\n");
            }
        }
    }
}