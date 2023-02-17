using System;
using System.Globalization;

public class Position {
    private string currentAge;
    private int currentYear;
    private string positionName;
    private string color;
    private TextInfo TI = new CultureInfo("en-us", false).TextInfo;
    public Position () {

    }

    public Position (string _positionName, string _currentAge, int _currentYear, string _color = null) {
        color = TI.ToTitleCase(_color);
        try {
            if (int.Parse(_currentAge) > 6 && int.Parse(_currentAge) < 20) {
                currentAge = _currentAge;
            }
        }
        catch {
            currentAge = "Adult";
        }
        currentYear = _currentYear;
        positionName = TI.ToTitleCase(_positionName);
    }

    public virtual bool IsInVanguard() {
        return false;
    }

    public virtual void ChangeAttribute(string attribute, string value) {
        switch (attribute) {
            case "name":
                positionName = value;
                break;
            case "age":
                currentAge = value;
                break;
            case "year":
                currentYear = int.Parse(value);
                break;
            case "color":
                color = value;
                break;
        }
    }

    public virtual void DisplayInformation() {
        string ageInsert = "";
        string colorInsert = "";
        if (currentAge != null) {
            ageInsert = $"\tAge: {currentAge}\n";
        }
        if (color != null) {
            colorInsert = $"\tColor: {color}";
        }
        Console.Write($"\tTitle: {positionName}\n\tYear: {currentYear}\n{ageInsert}{colorInsert}\n");
    }

    public virtual void DisplayAttributes () {
        Console.WriteLine("1. Position Name\n2. Age\n3. Year\n4. Color\n");
    }

    public virtual string GetAttribute (string attribute) {
        switch (attribute) {
            case "name":
                return positionName;
            case "age":
                return currentAge;
            case "year":
                return $"{currentYear}";
            case "color":
                return color;
        }
        return null;
    }
}