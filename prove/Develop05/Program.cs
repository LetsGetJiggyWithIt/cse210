using System;

class Program
{
    static void Main(string[] args)
    {
        Menu MainMenu = new Menu();
        string UserChoice = "";
        while (UserChoice != "6") {
            UserChoice = MainMenu.DisplayMenu();
            switch (UserChoice) {
                case "1":
                    MainMenu.AddGoal();
                    break;
                case "2":
                    MainMenu.ListGoals();
                    break;
                case "3":
                    MainMenu.SaveToFile();
                    break;
                case "4":
                    MainMenu.LoadFromFile();
                    break;
                case "5":
                    MainMenu.MenuRecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye.");
                    break;
            }
        }
    }
}