using System;
using System.Globalization;
public class Person {
    private string name;
    private string gender;
    private double phoneNumber;
    private string email;
    private bool isAdult;
    private List<Position> positions;
    private DateTime birthdate;
    private TextInfo TI = new CultureInfo("en-us", false).TextInfo;

    public Person () {
        name = "Invalid";
    }

    public Person (string _name, string _gender, double _phoneNumber, string _email, bool _isAdult, List<Position> _positions, DateTime _birthdate = new DateTime()) {
        name = TI.ToTitleCase(_name);
        gender = TI.ToTitleCase(_gender);
        phoneNumber = _phoneNumber;
        email = _email;
        isAdult = _isAdult;
        positions = _positions;
        birthdate = _birthdate;
    }

    public void DisplayInformation () {
        string age = "";
        string adultStatus = "";
        if (GetCurrentAge() != "Adult") {
            age = $"\nAge: {GetCurrentAge()}\nBirthdate: {birthdate.Month}/{birthdate.Day}/{birthdate.Year}";
        }
        if (isAdult == true) {
            adultStatus = "Yes";
        }
        else {
            adultStatus = "No";
        }

        Console.Write($"Name: {name}\nGender: {gender}{age}\nPhone: {ToPhoneNumber(phoneNumber)}\nEmail: {email}\nIs an adult: {adultStatus}\nPositions: ");
        if (positions.Count() == 0) {
            Console.Write("None\n\n");
        }
        else {
            Console.Write("[");
            foreach (Position position in positions) {
                Console.WriteLine();
                position.DisplayInformation();
            }
            Console.WriteLine("]\n");
        }
    }

    public void DisplayPositions () {
        foreach (Position position in positions) {
            position.DisplayInformation();
            Console.WriteLine();
        }
    }

    public virtual string GetAttribute (string attribute) {
        switch (attribute) {
            case "name":
                return name;
            case "gender":
                return gender;
            case "phonenumber":
                return $"{phoneNumber}";
            case "email":
                return email;
            case "isAdult":
                return $"{isAdult}";
        }
        return "invalid";
    }

    public void ChangeAttribute (string attribute, string value, DateTime dateValue = new DateTime()) {
        switch (attribute) {
            case "name":
                name = TI.ToTitleCase(value);
                break;
            case "gender":
                gender = TI.ToTitleCase(value);
                break;
            case "email":
                email = value;
                break;
            case "phone":
                phoneNumber = double.Parse(value);
                break;
            case "isAdult":
                isAdult = bool.Parse(value);
                break;
            case "birthdate":
                birthdate = dateValue;
                break;
        }
    }

    public string GetCurrentAge () {
        DateTime currentTime = DateTime.Now;
        int age = currentTime.Year - birthdate.Year;
        if (currentTime.Month < birthdate.Month) {
            age--;
        }
        string ageString = $"{age}";
        if (age >= 19) {
            ageString = "Adult";
            isAdult = true;
            birthdate = new DateTime();
        }
        return ageString;
    }

    public List<Position> GetPositions () {
        return positions;
    }

    private string ToPhoneNumber (double intNumber) {
        string number = $"{intNumber}";
        string finalNumber = "";
        int i = 0;
        foreach (char letter in number) {
            i++;
            if (i == 4 || i == 7) {
                finalNumber += "-";
            }
            finalNumber += letter;
        }
        return finalNumber;
    }

    public virtual string Export() {
        string exported, exportedPositions = "", birthdateExport = "";
        if ($"{birthdate}" != "1/1/0001 12:00:00 AM") {
            birthdateExport = $",{birthdate.Year}/{birthdate.Month}/{birthdate.Day}";
        }
        exported = $"{name},{gender},{phoneNumber},{email},{isAdult}";
        if (positions.Count > 0) {
            exported += ",[";
            foreach (Position position in positions) {
                string positionName = "";
                if (position.GetType() != typeof(AttendeePosition)) {
                    positionName = $"{position.GetAttribute("name")}^";
                }
                exportedPositions += $"%{position.GetType()}^{positionName}{position.GetAttribute("age")}^{position.GetAttribute("year")}^{position.GetAttribute("color")}";
                if (position.GetType() == typeof(YouthLeaderPosition)) {
                    exportedPositions += $"^{position.IsInVanguard()}";
                }
                if (position.GetType() == typeof(VillainPosition)) {
                    exportedPositions += $"^{position.GetAttribute("isYouth")}";
                }
            }
            exportedPositions = exportedPositions.Substring(1);
            exported += exportedPositions;
            exported += "]";
            exported += birthdateExport;
        }
        return exported;
    }
    public void RemovePosition (Position position) {
        positions.Remove(position);
    }
}