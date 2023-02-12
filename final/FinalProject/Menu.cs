public class Menu {
    private List<string> options = new List<string>{
        "New Query",
        "Add Person",
        "Change Person",
        "Display Directory",
        "Load from File",
        "Save to File",
        "Exit"
    };
    private List<Person> peopleDirectory = new List<Person>();
    private QueryHandler directory = new QueryHandler();
    private FileHandler file = new FileHandler();

    public Menu () {

    }

    public void DisplayOptions () {
        int i = 0;
        Console.WriteLine("Welcome! What would you like to do?\n");
        foreach (string option in options) {
            i++;
            Console.WriteLine($"{i}. {option}");
        }
        GetUserChoice();
    }

    public void GetUserChoice () {
        string userChoice = Console.ReadLine();
        switch (userChoice) {
            case "1":
                GetNewQuery();
                break;
            case "2":
                CreateNewPerson();
                break;
            case "3":
                ModifyPerson();
                break;
            case "4":
                DisplayDirectory();
                break;
            case "5":
                LoadFile();
                break;
            case "6":
                SaveFile();
                break;
            case "7":
                Console.WriteLine("Goodbye.");
                break;
            default:
                Console.WriteLine($"Sorry, {userChoice} is not a valid option. Please try again.");
                break;
        }
        if (userChoice != "7") {
            DisplayOptions();
        }
    }

    public void GetNewQuery () {
        Console.WriteLine("What Query would you like to do?");
        directory.DisplayQueryOptions();
        string queryChoice = Console.ReadLine();
        switch (queryChoice) {
            case "1":
                Console.Write("What name would you like to search for?\n>");
                string queryName = Console.ReadLine();
                directory.NewQuery("name", queryName);
                Console.WriteLine("Name Queried.");
                break;
            case "2":
                Console.Write("What gender would you like to search for? (Male/Female)\n");
                string queryGender = Console.ReadLine();
                queryGender = ToGender(queryGender);
                if (queryGender != "male" && queryGender != "female") {
                    Console.WriteLine($"Sorry, {queryGender} is not a valid gender.");
                    break;
                }
                directory.NewQuery("gender", queryGender);
                Console.WriteLine("Gender Queried.");
                break;
            case "3":
                Console.Write("What age are you looking for?\n");
                int queryAge;
                string intCheck = Console.ReadLine();
                try {
                    queryAge = int.Parse(intCheck);
                    directory.NewQuery("age", $"{queryAge}");
                    Console.WriteLine("Age Queried.");
                }

                catch {
                    Console.WriteLine($"Sorry, {intCheck} is not a valid age.");
                }
                break;
            case "4":
                Console.Write("What year would you like to search for?\n");
                string yearCheck = Console.ReadLine();
                try {
                    int queryYear = int.Parse(yearCheck);
                    directory.NewQuery("year", $"{queryYear}");
                    Console.WriteLine("Year Queried.");
                }
                catch {
                    Console.WriteLine($"Sorry, {yearCheck} is not a valid year.");
                }
                break;
            case "5":
                Console.Write("What position would you like to query for?\n");
                string queryPosition = Console.ReadLine();
                directory.NewQuery("position", queryPosition);
                Console.WriteLine("Position Queried.");
                break;
        }
    }
    public void CreateNewPerson () {
        string newGender = "";
        Console.Write("Please enter the following information:\nName\n>");
        string newName = Console.ReadLine();
        while (newGender != "male" && newGender != "female") {
            Console.Write("Gender\n");
            newGender = Console.ReadLine();
            newGender = ToGender(newGender);
            if (newGender != "male" && newGender != "female") {
                Console.WriteLine($"Sorry, {newGender} is not a valid gender.");
            }
        }
        Console.Write("Email\n");
        string newEmail = Console.ReadLine();
        string checkInt;
        int newPhone = 0;
        while ($"{newPhone}".Count() != 10) {
            Console.Write("Phone Number (No spaces or dashes)\n");
            checkInt = Console.ReadLine();
            try {
                newPhone = int.Parse(checkInt);
            }   
            catch {
                Console.WriteLine($"Sorry, {checkInt} is not a valid phone number. Please ensure there are no spaces or dashes.");
            }     
            if ($"{newPhone}".Count() != 10) {
                Console.WriteLine("The number you typed is not 10 digits long. Please re-enter.");
            }
        }
        Console.Write("Is this person an adult? (Leave empty for \"no\")");
        string checkBool = "";
        bool newIsAdult = false;
        bool boolConfirmed = false;
        while (boolConfirmed == false) {
            checkBool = Console.ReadLine().ToLower();
            try {
                if (checkBool == "y" || checkBool == "yes") {
                    newIsAdult = true;
                }
                else if (checkBool == "n" || checkBool == "no") {
                    newIsAdult = false;
                }
                else {
                    newIsAdult = bool.Parse(checkBool);
                }
                boolConfirmed = true;
            }
            catch {
                Console.WriteLine($"Sorry, {checkBool} is not a vaild answer. Please try agin.");
            }
        }

        List<Position> newPositions = new List<Position>();
        Person currentPerson = new Person(newName, newGender, newPhone, newEmail, newPositions, newIsAdult);

        peopleDirectory.Add(currentPerson);
        directory.UpdateDirectory(peopleDirectory);
    }

    public void ModifyPerson () {

    }

    public void DisplayDirectory () {
        foreach (Person person in peopleDirectory) {
            Console.WriteLine($"/n");
            person.DisplayInformation();
            Console.WriteLine("\n");
        }
    }

    public void LoadFile () {

    }

    public void SaveFile () {

    }

    public string ToGender (string gender) {
        if (gender.ToLower() == "m" || gender.ToLower() == "male") {
            gender = "male";
        }
        else if (gender.ToLower() == "f" || gender.ToLower() == "female") {
            gender = "female";
        }
        return gender;
    }

}