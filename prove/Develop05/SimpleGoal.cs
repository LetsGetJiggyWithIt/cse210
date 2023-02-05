public class SimpleGoal : Goal{
    public SimpleGoal (int PointValue, string Name, string Description, bool IsComplete = false, int PointsEarned = 0) : base(PointValue, Name, Description, IsComplete, PointsEarned) {
    }

    public override void RecordEvent() {
        if (Completed() == false) {
            AddPoints();
            SetIsComplete(true);
            Console.WriteLine($"Well Done! You earned {GetPoints()} points.");
        }
        else {
            Console.WriteLine("This Simple Goal is already completed.");
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
        return $"[{BracketFiller}] {GetName()} ({GetDescription()})";
    }

    public override string GoalToString()
    {
        return $"{GetType()},{PointValue},{Name},{Description},{IsComplete},{PointsEarned}";
    }
}