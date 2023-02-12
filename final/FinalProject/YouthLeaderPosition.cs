public class YouthLeaderPosition : Position {
    private bool isInVanguard;
    public YouthLeaderPosition (string name, int age, int year, string color, bool _isInVanguard) : base(name, age, year, color) {
        isInVanguard = _isInVanguard;
    }

    public bool IsInVanguard () {
        return isInVanguard;
    }
}