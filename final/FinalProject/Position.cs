public class Position {
    private int currentAge;
    private int currentYear;
    private string positionName;
    private string color;

    public Position (string _positionName, int _currentAge, int _currentYear, string _color = "None") {
        color = _color;
        currentAge = _currentAge;
        currentYear = _currentYear;
        positionName = _positionName;
    }

    public string GetName () {
        return positionName;
    }

    public int GetAge () {
        return currentAge;
    }

    public int GetYear () {
        return currentYear;
    }

    public string GetColor () {
        return color;
    }
}