public class ChecklistGoal : Goal{
    private int RequiredAmountCompleted;
    private int BonusPoints;
    private int TimesCompleted;
    public ChecklistGoal (int PointValue, string Name, string Description, int _RequiredAmountCompleted, int _BonusPoints, int _TimesCompleted = 0, bool IsComplete = false, int PointsEarned = 0) : base(PointValue, Name, Description, IsComplete, PointsEarned) {
        RequiredAmountCompleted = _RequiredAmountCompleted;
        BonusPoints = _BonusPoints;
        TimesCompleted = _TimesCompleted;
    }

    public override void RecordEvent()
    {
        TimesCompleted++;
        if (TimesCompleted == RequiredAmountCompleted & Completed() != true) {
            AddPoints(BonusPoints);
            SetIsComplete(true);
            Console.WriteLine($"Amazing Job! You have earned {GetPoints()} points and {BonusPoints} Bonus Points!");
        }
        else {
            AddPoints();
            Console.WriteLine($"Great job! You have earned {GetPoints()} Points.");
        }
    }

    public override string DisplayGoal()
    {
        string BracketFiller;
        if (Completed() == true) {
            BracketFiller = "X";
        }
        else {
            BracketFiller = " ";
        }
        return $"[{BracketFiller}] {GetName()} ({GetDescription()}) Completed: ({TimesCompleted}/{RequiredAmountCompleted})";
    }

    public override string GoalToString() {
        return $"{GetType()},{PointValue},{Name},{Description},{RequiredAmountCompleted},{BonusPoints},{TimesCompleted},{IsComplete},{PointsEarned}";
    }
}