public class YouthLeaderPosition : Position {
    private bool isInVanguard;
    public YouthLeaderPosition (string name, string age, int year, string color, bool _isInVanguard) : base(name, age, year, color) {
        isInVanguard = _isInVanguard;
    }

    public override bool IsInVanguard () {
        return isInVanguard;
    }

    public override void DisplayInformation()
    {
        base.DisplayInformation();
        string vanguardFill = "";
        if (isInVanguard) {
            vanguardFill = "Yes";
        }
        else {
            vanguardFill = "No";
        }
        Console.WriteLine($"\tVanguard: {vanguardFill}");
    }

    public override void DisplayAttributes()
    {
        Console.WriteLine("1. Position Name\n2. Age\n3. Year\n4. Color");
    }

    public override void ChangeAttribute(string attribute, string value)
    {
        base.ChangeAttribute(attribute, value);
        switch (attribute) {
            case "isInVanguard":
                isInVanguard = bool.Parse(value);
                break;
        }
    }
}
