public class VillainPosition : Position{
    private bool isYouth;
    public VillainPosition (int year, bool _isYouth = false, string age = "Adult", string name = "Villain", string color = "Black") : base(name, age, year, color) {
        isYouth = _isYouth;
    }

    public bool IsYouth () {
        return isYouth;
    }

    public override string GetAttribute(string attribute)
    {
        if (attribute == "isYouth") {
            return $"{isYouth}";
        }
        else {
            return base.GetAttribute(attribute);
        }
    }
    public override void DisplayAttributes()
    {
        Console.WriteLine("1. Position Name\n2. Age\n3. Year\n4. Color\n5. Adult / Youth");
    }

    public override void ChangeAttribute(string attribute, string value)
    {
        base.ChangeAttribute(attribute, value);
        switch (attribute) {
            case "isYouth":
                isYouth = bool.Parse(value);
                break;
        }
    }

}