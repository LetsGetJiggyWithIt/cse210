public class Menu {
    List<Goal> Goals;
    private FileHandler GoalFile = new FileHandler();

    public Menu () {
        Goals = GoalFile.CheckForAutoLoad();
    }
    public string DisplayMenu () {
        Console.WriteLine($"\nYou have {GetAllPoints()} points.");
        Console.Write("\nWhat would you like to do?\n\n1. Add Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Exit\n>");
        string MenuChoice = Console.ReadLine();
        return MenuChoice;
    }

    public int GetAllPoints () {
        int PointTotal = 0;
        foreach (Goal CurrentGoal in Goals) {
            PointTotal += CurrentGoal.GetTotalPoints();
        }
        return PointTotal;
    }

    public void AddGoal() {
        string GoalType, GoalName, GoalDescription;
        int GoalPoints, RequiredAmountCompleted = 0, BonusPoints = 0;
        Console.Write("\nWhat type of goal would you like to add? \n\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\n>");
        GoalType = Console.ReadLine();
        Console.Write("\nWhat is the name of your goal?\n>");
        GoalName = Console.ReadLine();
        Console.Write("\nWhat is the description of your goal?\n>");
        GoalDescription = Console.ReadLine();
        Console.Write("\nHow many points is this goal worth?\n>");
        GoalPoints = int.Parse(Console.ReadLine());
        if (GoalType == "3") {
            Console.Write("\nHow many times should this goal be compleed?\n>");
            RequiredAmountCompleted = int.Parse(Console.ReadLine());
            Console.Write("\nHow many bonus points?\n>");
            BonusPoints = int.Parse(Console.ReadLine());
        }

        if (GoalType == "1") {
            SimpleGoal CurrentGoal = new SimpleGoal(GoalPoints, GoalName, GoalDescription);
            Goals.Add(CurrentGoal);
        }
        else if (GoalType == "2") {
            EternalGoal CurrentGoal = new EternalGoal(GoalPoints, GoalName, GoalDescription);
            Goals.Add(CurrentGoal);
        }
        else {
            ChecklistGoal CurrentGoal = new ChecklistGoal(GoalPoints, GoalName, GoalDescription, RequiredAmountCompleted, BonusPoints);
            Goals.Add(CurrentGoal);
        }

        Console.WriteLine("\nGoal Added.\n");
    }

    public void ListGoals () {
        int i = 1;
        Console.WriteLine();
        foreach (Goal item in Goals) {
            Console.WriteLine($"{i}. {item.DisplayGoal()}");
            i++;
        }
        Console.WriteLine();
    }

    public void MenuRecordEvent () {
        Console.Write("\nWhich goal have you accomplished?\n");
        ListGoals();
        Console.Write("\n");
        int GoalChoice = int.Parse(Console.ReadLine());
        Console.WriteLine();
        if (GoalChoice > Goals.Count | GoalChoice < 1) {
            Console.WriteLine($"Sorry, {GoalChoice} is not a valid option.\n");
        }
        else {
            Goals[GoalChoice - 1].RecordEvent();
        }
    }

    public void SaveToFile () {
        Console.Write("\nWhat is the filename that you would like to save to?\n>");
        string FileName = Console.ReadLine();
        GoalFile.SaveToFile(FileName, Goals);
    }

    public void LoadFromFile () {
        Console.Write("\nWhat is the filename you would like to load from?\n>");
        string FileName = Console.ReadLine();
        Goals = GoalFile.LoadFromFile(FileName);
        Console.Write("\nWould you like to load from this file every time you launch this program? (y/n)\n>");
        string AutoLoad = Console.ReadLine();
        if (AutoLoad == "Y" | AutoLoad == "y") {
            GoalFile.EnableAutoLoad(FileName);
        }
    }
}