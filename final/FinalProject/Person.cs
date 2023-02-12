public class Person {
    private string name;
    private string gender;
    private double phoneNumber;
    private string email;
    private bool isAdult;
    private List<Position> positions;
    private DateTime birthdate;

    public Person (string _name, string _gender, double _phoneNumber, string _email, List<Position> _positions, bool _isAdult, DateTime _birthdate = new DateTime()) {
        name = _name;
        gender = _gender;
        phoneNumber = _phoneNumber;
        email = _email;
        isAdult = _isAdult;
        positions = _positions;
        birthdate = _birthdate;
    }

    public void DisplayInformation () {
        string age = "";
        if (GetCurrentAge() < 20) {
            age = $"\nAge: {GetCurrentAge()}\nBirthdate: {birthdate}";
        }
        Console.WriteLine($"Name: {name}\nGender: {gender}{age}\nPhone: {phoneNumber}\nEmail: {email}\nPositions: [Placeholder]\n");
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

    public void ChangeAttribute (string attribute, string value) {

    }

    public int GetCurrentAge () {
        DateTime currentTime = DateTime.Now;
        int age = currentTime.Year - birthdate.Year;
        if (currentTime.Month < birthdate.Month) {
            age--;
        }
        return age;
    }
}