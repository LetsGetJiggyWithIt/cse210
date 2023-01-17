public class Fraction {
    private int top = 0;
    private int bottom = 0;
    public Fraction () {
        top = 1;
        bottom = 1;
    }
    public Fraction (int _top) {
        top = _top;
        bottom = 1;
    }
    public Fraction (int _top, int _bottom) {
        top = _top;
        bottom = _bottom;
    }
    public void SetValues (int _top) {
        top = _top;
    }
    public void SetValues (int _top, int _bottom) {
        top = _top;
        bottom = _bottom;
    }
    public int GetTop () {
        return top;
    }
    public int GetBottom () {
        return bottom;
    }
    public string GetFractionString () {
        return $"{top}/{bottom}";
    }
    public double GetDecimalValue () {
        return (double)top/bottom;
    }
    public void DisplayFraction () {
        Console.WriteLine($"{top}/{bottom}");
    }
}