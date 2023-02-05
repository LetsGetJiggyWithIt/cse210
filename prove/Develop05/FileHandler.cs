using System.IO;

public class FileHandler {
    public void SaveToFile(string FileName, List<Goal> Goals) {
        string UserConfirm = "y";
        if (File.Exists(FileName)) {
            Console.Write($"\nThe file {FileName} already exists. Would you like to overwrite it? (y/n) >");
            UserConfirm = Console.ReadLine();
        }
        if (UserConfirm == "Y" | UserConfirm == "y") {
            using (StreamWriter OutputFile = new StreamWriter(FileName)) {
                foreach (Goal CurrentLine in Goals) {
                    OutputFile.WriteLine(CurrentLine.GoalToString());
                }
            }
            Console.WriteLine($"Goals successfully saved to {FileName}");
        }
        else {
            Console.WriteLine("\nAbort.");
        }
    }

    public List<Goal> LoadFromFile (string FileName) {
        List<Goal> LoadedGoals = new List<Goal>();
        string[] Lines = System.IO.File.ReadAllLines(FileName);

        foreach (string Line in Lines)
        {
            string[] Parts = Line.Split(",");

            switch (Parts[0]) {
                case "SimpleGoal":
                    SimpleGoal CurrentSimpleGoal = new SimpleGoal(int.Parse(Parts[1]), Parts[2], Parts[3], bool.Parse(Parts[4]), int.Parse(Parts[5]));
                    LoadedGoals.Add(CurrentSimpleGoal);
                    break;
                case "EternalGoal":
                    EternalGoal CurrentEternalGoal = new EternalGoal(int.Parse(Parts[1]), Parts[2], Parts[3], bool.Parse(Parts[4]), int.Parse(Parts[5]), int.Parse(Parts[6]));
                    LoadedGoals.Add(CurrentEternalGoal);
                    break;
                case "ChecklistGoal":
                    ChecklistGoal CurrentChecklistGoal = new ChecklistGoal(int.Parse(Parts[1]), Parts[2], Parts[3], int.Parse(Parts[4]), int.Parse(Parts[5]), int.Parse(Parts[6]), bool.Parse(Parts[7]), int.Parse(Parts[8]));
                    LoadedGoals.Add(CurrentChecklistGoal);
                    break;
            }
        }
        return LoadedGoals;
    }

    public void EnableAutoLoad(string FileName) {
        using (StreamWriter ConfigFile = new StreamWriter("config.txt")) {
            ConfigFile.WriteLine("autoboot=true");
            ConfigFile.Write($"filepath={FileName}");
        }
    }

    public List<Goal> CheckForAutoLoad() {
        List<Goal> Loaded = new List<Goal>();
        if (File.Exists("config.txt")) {
            string[] Lines = System.IO.File.ReadAllLines("config.txt");
            string[] Enabled = Lines[0].Split("=");
            string[] FileName = Lines[1].Split("=");
            if (Enabled[1] == "true") {
                Console.WriteLine($"Auto loaded goals from {FileName[1]}");
                Loaded = LoadFromFile(FileName[1]);
            }
        }
        return Loaded;
    }
}