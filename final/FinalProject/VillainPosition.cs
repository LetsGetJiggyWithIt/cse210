public class VillainPosition : Position{
    private bool isYouth;
    public VillainPosition (string name = "Villain", int age = 0, int year = 0, string color = "Black", bool _isYouth = false) : base(name, age, year, color) {
        isYouth = _isYouth;
    }

    public bool IsYouth () {
        return isYouth;
    }
}