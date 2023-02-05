public abstract class Goal {
    protected int PointValue;
    protected bool IsComplete;
    protected string Name;
    protected string Description;
    protected int PointsEarned;
    public Goal (int _PointValue, string _Name, string _Description, bool _IsComplete, int _PointsEarned) {
        PointValue = _PointValue;
        Name = _Name;
        Description = _Description;
        IsComplete = _IsComplete;
        PointsEarned = _PointsEarned;
    }

    public abstract void RecordEvent ();
    public abstract string DisplayGoal ();
    public abstract string GoalToString();

    public bool Completed () {
        return IsComplete;
    }

    public void SetIsComplete (bool Value) {
        IsComplete = Value;
    }

    public void AddPoints (int Points = 0) {
        if (Points != 0) {
            PointsEarned += Points;
        }
        PointsEarned += PointValue;
    }

    public int GetPoints () {
        return PointValue;
    }

    public int GetTotalPoints () {
        return PointsEarned;
    }

    public string GetName () {
        return Name;
    }

    public string GetDescription () {
        return Description;
    }
}