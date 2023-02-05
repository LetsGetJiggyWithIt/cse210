public class EternalGoal : Goal{
    private int TimesCompleted;
    public EternalGoal (int PointValue, string Name, string Description, bool IsComplete = false, int PointsEarned = 0, int _TimesCompleted = 0) : base(PointValue, Name, Description, IsComplete, PointsEarned) {
        TimesCompleted = _TimesCompleted;
    }

    public override void RecordEvent()
    {
        AddPoints();
        TimesCompleted++;
        Console.WriteLine($"Great Job! You've earned {GetPoints()} points.");
    }

    public int GetTimesCompleted () {
        return TimesCompleted;
    }

    public override string DisplayGoal()
    {
        string BracketFiller = $"{TimesCompleted}";
        return $"[{BracketFiller}] {GetName()} ({GetDescription()})";
    }

    public override string GoalToString() {
        return $"{GetType()},{PointValue},{Name},{Description},{IsComplete},{PointsEarned},{TimesCompleted}";
    }
}