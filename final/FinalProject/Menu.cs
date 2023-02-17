public class Menu {
    private List<string> options = new List<string>{
        "New Query",
        "Add Person",
        "Manage Position[s]",
        "Display Person",
        "Modify Person",
        "Display Directory",
        "Load from File",
        "Save to File",
        "Exit"
    };

    private List<string> attributes = new List<string>{
        "Name",
        "Gender",
        "Email",
        "Phone Number",
        "Adult / Youth",
        "Birthdate",
        "Done"
    };
    private List<Person> tempDirectory = new List<Person>();
    private QueryHandler directory = new QueryHandler();
    private FileHandler savedFile = new FileHandler();

    private string autoLoad = "false";
    private string autoLoadFileName = "";
    private bool directorySaved = false;
    public Menu () {
        string[] config = System.IO.File.ReadAllLines("config.txt");
        autoLoad = config[0].Split("=")[1];
        if (autoLoad == "true") {
            autoLoadFileName = config[1].Split("=")[1];
            tempDirectory = savedFile.LoadFromFile(autoLoadFileName, new List<Person>());
            directory.UpdateDirectory(tempDirectory);
            Console.WriteLine($"File auto-loaded from {autoLoadFileName}");
        }
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
        Console.WriteLine();
        switch (userChoice) {
            case "1":
                GetNewQuery();
                break;
            case "2":
                CreateNewPerson();
                break;
            case "3":
                ManagePositions();
                break;
            case "4":
                DisplayPerson();
                break;
            case "5":
                ModifyPerson();
                break;
            case "6":
                DisplayDirectory();
                break;
            case "7":
                LoadFile();
                break;
            case "8":
                SaveFile();
                break;
            case "9":
                if (directorySaved == false) {
                    Console.Write("WARNING!!! Your directory has not been saved. Would you like to save before quitting? (Y/N)\n>");
                    string saveOrQuit = Console.ReadLine();
                    if (saveOrQuit == "y" || saveOrQuit == "yes") {
                        SaveFile();
                    }
                }
                Console.WriteLine("Goodbye.");
                break;
            default:
                Console.WriteLine($"Sorry, {userChoice} is not a valid option. Please try again.");
                break;
        }
        if (userChoice != "9") {
            DisplayOptions();
        }
    }

    public void GetNewQuery () {
        directory.DisplayQueryOptions();
        bool validQuery = false;
        string queryChoice = "";
        while (validQuery == false) {
            Console.Write("What Query would you like to do?\n>");
            queryChoice = Console.ReadLine();
            switch (queryChoice) {
                case "1":
                    Console.Write("What name would you like to search for?\n>");
                    string queryName = Console.ReadLine();
                    directory.NewQuery("name", queryName);
                    validQuery = true;
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
                    validQuery = true;
                    break;
                case "3":
                    Console.Write("What age are you looking for?\n");
                    int queryAge;
                    string intCheck = Console.ReadLine();
                    try {
                        queryAge = int.Parse(intCheck);
                        directory.NewQuery("age", $"{queryAge}");
                        validQuery = true;
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
                        validQuery = true;
                    }
                    catch {
                        Console.WriteLine($"Sorry, {yearCheck} is not a valid year.");
                    }
                    break;
                case "5":
                    Console.Write("What position would you like to query for?\n");
                    string queryPosition = Console.ReadLine();
                    directory.NewQuery("position", queryPosition);
                    validQuery = true;
                    break;
                default:
                    Console.WriteLine($"Sorry, but {queryChoice} is not a valid option. Please enter a number from the list above.");
                    break;
            }
        }
    }
    public void CreateNewPerson () {
        Console.Write("Please enter the following information:\nName\n>");
        string newName = Console.ReadLine();
        string newGender = GetGender();
        Console.Write("Email\n");
        string newEmail = Console.ReadLine();
        double newPhone = GetPhone();
        bool newIsAdult = GetIsAdult();
        DateTime newBirthDate = new DateTime();
        bool validAnswer = false;
        if (newIsAdult == false) {
            string dateTest = "";
            while (validAnswer == false) {
                Console.Write("Please enter the person's birthdate in the following format: MM/DD/YYYY\n>");
                dateTest = Console.ReadLine();
                try {
                    newBirthDate = ToDate(dateTest);
                    validAnswer = true;
                }
                catch {
                    Console.WriteLine($"Sorry, {dateTest} is not a valid date.");
                }
            }
            validAnswer = false;
        }
        Console.WriteLine();

        List<Position> newPositions = new List<Position>();
        Person currentPerson = new Person();
        if ($"{newBirthDate}" != "1/1/0001 12:00:00 AM") {
            currentPerson = new Person(newName, newGender, newPhone, newEmail, newIsAdult, newPositions, newBirthDate);
        }
        else {
            currentPerson = new Person(newName, newGender, newPhone, newEmail, newIsAdult, newPositions);
        }
        string userConfirm = "";
        while (userConfirm != "y" && userConfirm != "yes") {
            currentPerson.DisplayInformation();
            Console.Write("Is this information correct? (Y/N)\n>");
            userConfirm = Console.ReadLine().ToLower();
            if (userConfirm != "y" && userConfirm != "yes") {
                string attributeToChange = "";
                while (userConfirm != "continue") {
                    DisplayAttributes();
                    Console.Write("Which attribute would you like to change?\n>");
                    attributeToChange = Console.ReadLine();
                    string changedAttribute = "";
                    switch (attributeToChange) {
                        case "1":
                            Console.Write("Please enter a new name\n>");
                            newName = Console.ReadLine();
                            changedAttribute = newName;
                            break;
                        case "2":
                            newGender = GetGender();
                            changedAttribute = newGender;
                            break;
                        case "3":
                            Console.Write("Please enter a new email\n>");
                            newEmail = Console.ReadLine();
                            changedAttribute = newEmail;
                            break;
                        case "4":
                            newPhone = GetPhone();
                            changedAttribute = $"{newPhone}";
                            break;
                        case "5":
                            newIsAdult = GetIsAdult();
                            changedAttribute = $"{newIsAdult}";
                            break;
                        case "6":
                            while (validAnswer == false) {
                                Console.Write("Please enter a new date (MM/DD/YYYY)\n>");
                                string dateTest = Console.ReadLine();
                                try {
                                    newBirthDate = ToDate(dateTest);
                                    validAnswer = true;
                                }
                                catch {
                                    Console.WriteLine($"Sorry, {dateTest} is not a valid date.");
                                }
                            }
                            validAnswer = false;
                            break;
                        case "7":
                            userConfirm = "continue";
                            break;
                        default:
                            Console.WriteLine($"Sorry, {attributeToChange} isn't a valid option. Plase re-type your numbered option.");
                            break;
                    }

                    newPositions = new List<Position>();
                    if ($"{newBirthDate}" != "1/1/0001 12:00:00 AM") {
                        currentPerson = new Person(newName, newGender, newPhone, newEmail, newIsAdult, newPositions, newBirthDate);   
                    }
                    else {
                        currentPerson = new Person(newName, newGender, newPhone, newEmail, newIsAdult, newPositions);
                    }
                }
            }
        }

        tempDirectory.Add(currentPerson);
        directory.UpdateDirectory(tempDirectory);

        Console.WriteLine($"{currentPerson.GetAttribute("name")} has been added.\n");
    }

    public void ManagePositions () {
        bool validAnswer = false;
        string personTest = "";
        Person person = new Person();
        while (validAnswer == false) {
            Console.Write("Who would you like to manage positions for? (Or type \"quit\" to cancel)\n>");
            personTest = Console.ReadLine();
            person = directory.GetPerson(personTest);
            if (person.GetAttribute("name") != "Invalid" || personTest == "quit") {
                validAnswer = true;
            }
            else{
                Console.WriteLine($"Sorry, it appears that \"{personTest}\" is not in the current directory. Please make sure to type the person's full name.");
            }
        }
        validAnswer = false;
        if (personTest != "quit") {
            string menuChoice = "";
            while (menuChoice != "4") {
                Console.WriteLine(person.GetAttribute("name"));
                List<Position> positions = person.GetPositions();
                person.DisplayPositions();
                Console.WriteLine("1. Add Position\n2. Remove Position\n3. Modify Position\n4. Done");
                Console.Write("What would you like to do?\n>");
                menuChoice = Console.ReadLine().ToLower();
                switch (menuChoice) {
                    case "1":
                        Console.WriteLine("1. Attendee Position\n2. Youth Leader Position\n3. Adult Volunteer\n4. Villain");
                        Console.Write("What type of position would you like to add?\n>");
                        string newType = Console.ReadLine();
                        switch (newType) {
                            case "1":
                                string newName = "";
                                if (person.GetAttribute("gender") == "Male") {
                                    newName = "Knight";
                                }
                                else {
                                    newName = "Handmaiden";
                                }
                                Console.Write($"How old were they when they attended as a {newName}?\n>");
                                validAnswer = false;
                                string newAge = "";
                                while (validAnswer == false) {
                                    newAge = Console.ReadLine();
                                    if (IsInt(newAge)) {
                                        validAnswer = true;
                                    }
                                    else {
                                        Console.WriteLine($"Sorry, {newAge} is not a valid age.");
                                    }
                                }
                                validAnswer = false;
                                int newYear = 0;
                                while (validAnswer == false) {
                                    Console.Write("What year did they attend?\n>");
                                    string yearTest = Console.ReadLine();
                                    if (IsInt(yearTest)) {
                                        newYear = int.Parse(yearTest);
                                        validAnswer = true;
                                    }
                                    else {
                                        Console.WriteLine($"Sorry, {yearTest} is not a valid year.");
                                    }
                                }
                                validAnswer = false;
                                string kingdomCamp = "";
                                if (person.GetAttribute("gender") == "Male") {
                                    kingdomCamp = "camp";
                                }
                                else {
                                    kingdomCamp = "kingdom";
                                }
                                Console.Write($"What color {kingdomCamp} were they in?\n>");
                                string newColor = Console.ReadLine();
                                AttendeePosition newAttendee = new AttendeePosition(newName, newAge, newYear, newColor);
                                positions.Add(newAttendee);
                                Console.WriteLine($"{newName} position added to {person.GetAttribute("name")}.");
                                break;
                            case "2":
                                Console.Write("Position Name\n>");
                                newName = Console.ReadLine();
                                validAnswer = false;
                                newAge = "";
                                while (validAnswer == false) {
                                    Console.Write("Age when Position was held\n>");
                                    newAge = Console.ReadLine();
                                    if (IsInt(newAge) == true) {
                                        validAnswer = true;
                                    }
                                    else {
                                        Console.WriteLine($"Sorry, {newAge} is not a valid age.");
                                    }
                                }
                                validAnswer = false;
                                newYear = 0;
                                while (validAnswer == false) {
                                    Console.Write("Year\n>");
                                    string yearTest = Console.ReadLine();
                                    try {
                                        newYear = int.Parse(yearTest);
                                        validAnswer = true;
                                    }
                                    catch {
                                        Console.WriteLine($"Sorry, but {yearTest} is not a valid year.");
                                    }
                                }
                                validAnswer = false;
                                Console.Write("Color\n>");
                                newColor = Console.ReadLine();
                                bool newIsInVanguard = false;
                                if (newName.Contains("guard") || newName.Contains("valk") || newName.Contains("command")) {
                                    newIsInVanguard = true;
                                }
                                YouthLeaderPosition newYouthLeader = new YouthLeaderPosition(newName, newAge, newYear, newColor, newIsInVanguard);
                                positions.Add(newYouthLeader);
                                Console.WriteLine($"{newColor} {newName} has been added to {person.GetAttribute("name")}.");
                                break;
                            case "3":
                                Console.Write("What is the name of the volunteer position?\n>");
                                newName = Console.ReadLine();
                                validAnswer = false;
                                newYear = 0;
                                while (validAnswer == false) {
                                    Console.Write("What year did they volunteer?\n>");
                                    string yearTest = Console.ReadLine();
                                    try {
                                        newYear = int.Parse(yearTest);
                                        validAnswer = true;
                                    }
                                    catch {
                                        Console.WriteLine($"Sorry, but \"{yearTest}\" is not a valid year.");
                                    }
                                }
                                newColor = "";
                                Console.Write("What color was this position associated with? (Leave blank for None)\n>");
                                newColor = Console.ReadLine();
                                if (newColor == "") {
                                    newColor = "None";
                                }
                                AdultVolunteerPosition newAdultVolunteer = new AdultVolunteerPosition(newName, newYear, newColor);
                                positions.Add(newAdultVolunteer);
                                Console.WriteLine($"{newName} has been added to {person.GetAttribute("name")}.");
                                break;
                            case "4":
                                validAnswer = false;
                                newYear = 0;
                                while (validAnswer == false) {
                                    Console.Write("What year did they participate as a villain?\n>");
                                    string yearTest = Console.ReadLine();
                                    try {
                                        newYear = int.Parse(yearTest);
                                        validAnswer = true;
                                    }
                                    catch {
                                        Console.WriteLine($"Sorry, but \"{yearTest}\" is not a valid year.");
                                    }
                                }
                                bool newIsYouth = false;
                                validAnswer = false;
                                string newVillainAge = "Adult";
                                while (validAnswer == false) {
                                    Console.Write("Were they a youth villain? (Leave blank for \"No\")\n>");
                                    string isYouthInput = Console.ReadLine().ToLower();
                                    try {
                                        if (isYouthInput == "" || isYouthInput == "n" || isYouthInput == "no") {
                                            newIsYouth = false;
                                        }
                                        else if (isYouthInput == "y" || isYouthInput == "yes") {
                                            newIsYouth = true;
                                            newVillainAge = "Youth";
                                        }
                                        else {
                                            newIsYouth = bool.Parse(isYouthInput);
                                        }
                                        validAnswer = true;
                                    }
                                    catch {
                                        Console.WriteLine($"Sorry, \"{newIsYouth}\" is not a valid answer.");
                                    }
                                }
                                if (newIsYouth == false) {
                                    VillainPosition newVillain = new VillainPosition(newYear);
                                    positions.Add(newVillain);
                                }
                                else {
                                    VillainPosition newVillain = new VillainPosition(newYear, true, newVillainAge);
                                    positions.Add(newVillain);
                                }
                                Console.WriteLine($"Villain position has been added to {person.GetAttribute("name")}.");
                                break;
                        }
                        break;
                    case "2":
                        int i = 0;
                        foreach (Position position in positions) {
                            i++;
                            Console.WriteLine($"{i}. {position.GetAttribute("name")} ({position.GetAttribute("color")} {position.GetAttribute("year")})");
                        }
                        Console.Write("Which position would you like to remove?\n>");
                        string positionToRemove = Console.ReadLine();
                        bool positionExists = false;
                        Position removeMe = new Position();
                        foreach (Position position in positions) {
                            try {
                                if (position.GetAttribute("name") == positions[int.Parse(positionToRemove) - 1].GetAttribute("name")) {
                                    removeMe = position;
                                    positionExists = true;
                                }
                            }
                            catch {
                                Console.WriteLine($"Sorry, {positionToRemove} is not a valid option.");
                            }
                        }
                        if (positionExists == true) {
                            person.RemovePosition(removeMe);
                        }
                        else {
                            Console.WriteLine($"Sorry, {positionToRemove} is not a valid option.\n");
                        }
                        break;
                    case "3":
                        i = 0;
                        foreach (Position position in positions) {
                            i++;
                            Console.WriteLine($"{i}. {position.GetAttribute("name")} ({position.GetAttribute("color")} {position.GetAttribute("year")})");
                        }
                        Console.Write("Which position would you like to change?\n>");
                        string positionToChange = Console.ReadLine();
                        positionExists = false;
                        Position currentPosition = new Position();
                        foreach (Position position in positions) {
                            if (position.GetAttribute("name").ToLower() == positionToChange) {
                                positionExists = true;
                                currentPosition = position;
                            }
                            try {
                                if (position.GetAttribute("name").ToLower() == positions[int.Parse(positionToChange) - 1].GetAttribute("name").ToLower()) {
                                    positionExists = true;
                                    currentPosition = position;
                                }
                            }
                            catch {
                                
                            }
                        }
                        if (positionExists == true) {
                            currentPosition.DisplayAttributes();
                            Console.Write("What attribute would you like to change?\n>");
                            string attributeToChange = Console.ReadLine();
                            switch (attributeToChange) {
                                case "1":
                                    Console.Write("What is the new position name?\n>");
                                    string newName = Console.ReadLine();
                                    currentPosition.ChangeAttribute("name", newName);
                                    if (currentPosition.GetType() == typeof(YouthLeaderPosition)) {
                                        if (newName.Contains("guard") || newName.Contains("valk") || newName.Contains("comm")) {
                                            currentPosition.ChangeAttribute("isInVanguard", "true");
                                        }
                                        else {
                                            currentPosition.ChangeAttribute("isInVanguard", "false");
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.Write("What is their age for this position?\n>");
                                    string newAge = Console.ReadLine();
                                    if (IsInt(newAge)) {
                                        currentPosition.ChangeAttribute("age", newAge);
                                    }
                                    else {
                                        Console.WriteLine($"Sorry, {newAge} is not a valid age.");
                                    }
                                    break;
                                case "3":
                                    Console.Write("What year did they hold this position?\n>");
                                    string yearTest = Console.ReadLine();
                                    if (IsInt(yearTest)) {
                                        currentPosition.ChangeAttribute("year", yearTest);
                                    }
                                    else {
                                        Console.WriteLine($"Sorry, {yearTest} is not a valid year.");
                                    }
                                    break;
                                case "4":
                                    Console.Write("What color were they in for this position?\n>");
                                    string newColor = Console.ReadLine();
                                    currentPosition.ChangeAttribute("color", newColor);
                                    break;
                                case "5":
                                    if (currentPosition.GetType() == typeof(VillainPosition)) {
                                        if (bool.Parse(currentPosition.GetAttribute("isYouth"))) {
                                            currentPosition.ChangeAttribute("isYouth", "false");
                                        }
                                        else {
                                            currentPosition.ChangeAttribute("isYouth", "true");
                                        }
                                        Console.Write("Was this person a youth villain?");
                                        string isYouthTest = Console.ReadLine().ToLower();
                                        bool newIsYouth = false;
                                        if (isYouthTest == "y" || isYouthTest == "yes") {
                                            currentPosition.ChangeAttribute("isYouth", "true");
                                        }
                                        else if (isYouthTest == "" || isYouthTest == "n" || isYouthTest == "no") {
                                            currentPosition.ChangeAttribute("isYouth", "false");
                                        }
                                        else {
                                            try {
                                                newIsYouth = bool.Parse(isYouthTest);
                                                currentPosition.ChangeAttribute("isYouth", $"{newIsYouth}");
                                            }
                                            catch {
                                                Console.WriteLine($"Sorry, {isYouthTest} is not a valid option.");
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else {
                            Console.WriteLine($"Sorry, {positionToChange} is not a position held by {person.GetAttribute("name")}.");
                        }
                        break;
                    default:
                        Console.WriteLine($"Sorry, {menuChoice} is not a valid option. Please try again.");
                        break;
                }
            }
        }
    }
    public void DisplayPerson () {
        Console.Write("Who would you like to display?\n>");
        string name = Console.ReadLine();
        bool infoDisplayed = false;
        Console.WriteLine();
        foreach (Person person in tempDirectory) {
            if (name.ToLower() == person.GetAttribute("name").ToLower()) {
                person.DisplayInformation();
                infoDisplayed = true;
            }
        }
        if (infoDisplayed == true) {
            Console.WriteLine($"Information for {name} displayed.");
        }
        else {
            Console.WriteLine($"Sorry, it looks like \"{name}\" is not in the current directory.");
        }
    }

    public void ModifyPerson () {
        Console.Write("Please enter the name of the person you would like to change.\n>");
        string personToChange = Console.ReadLine();
        bool personExists = false;
        bool userConfirm = false;
        Person tempPerson = new Person();
        int tempIndex = FindPersonIndex(personToChange);
        foreach (Person person in tempDirectory) {
            if (person.GetAttribute("name").ToLower() == personToChange.ToLower()) {
                tempPerson = person;
                personExists = true;
            }
        }
        if (personExists == true) {
            while (userConfirm == false) {
                string birthdateFill = "";
                if (IsInt(tempPerson.GetCurrentAge())) {
                    birthdateFill = "\n6. Birthdate";
                }
                Console.WriteLine();
                tempPerson.DisplayInformation();
                Console.WriteLine($"1. Name\n2. Gender\n3. Email\n4. Phone Number\n5. Adult / Youth{birthdateFill}");
                Console.Write("Which attribute would you like to change? (Leave blank if finished)\n>");
                string attributeToChange = Console.ReadLine();
                switch (attributeToChange) {
                    case "1":
                        Console.Write("Name\n>");
                        tempPerson.ChangeAttribute("name", Console.ReadLine());
                        break;
                    case "2":
                        tempPerson.ChangeAttribute("gender", GetGender());
                        break;
                    case "3":
                        Console.Write("Email\n>");
                        tempPerson.ChangeAttribute("email", Console.ReadLine());
                        break;
                    case "4":
                        tempPerson.ChangeAttribute("phone", $"{GetPhone()}");
                        break;
                    case "5":
                        bool isAdult = bool.Parse(tempPerson.GetAttribute("isAdult"));
                        if (isAdult == true) {
                            isAdult = false;
                        }
                        else {
                            isAdult = true;
                        }
                        tempPerson.ChangeAttribute("isAdult", $"{isAdult}");
                        break;
                    case "6":
                        bool validAnswer = false;
                        string dateTest = "";
                        DateTime newDate = new DateTime();
                        while (validAnswer == false) {
                            Console.Write("Please enter a new date (MM/DD/YYYY)\n>");
                            dateTest = Console.ReadLine();
                            try {
                                newDate = ToDate(dateTest);
                                validAnswer = true;
                            }
                            catch {
                                Console.WriteLine($"Sorry, {dateTest} is not a valid date.");
                            }
                        }
                        tempPerson.ChangeAttribute("birthdate", "", newDate);
                        break;
                }
                tempPerson.DisplayInformation();
                Console.Write("Does this information look correct? (Y/N)\n>");
                string correctInfo = Console.ReadLine().ToLower();
                if (correctInfo == "y" || correctInfo == "yes" || correctInfo == "true") {
                    userConfirm = true;
                }
                else {
                    userConfirm = false;
                }
            }
            tempDirectory.RemoveAt(tempIndex);
            tempDirectory.Add(tempPerson);
            Console.WriteLine($"{tempPerson.GetAttribute("name")} has been successfully modified.");
        }
        else {
            Console.WriteLine($"Sorry, it looks like \"{personToChange}\" does not exist in this directory.");
        }
    }

    public void DisplayDirectory () {
        foreach (Person person in tempDirectory) {
            person.DisplayInformation();
        }
    }
    public void LoadFile () {
        Console.Write("What file would you like to load from?\n>");
        string filename = Console.ReadLine();
        try {
            tempDirectory = savedFile.LoadFromFile(filename, tempDirectory);
            directory.UpdateDirectory(tempDirectory);
            Console.WriteLine($"\nDirectory successfully loaded from \"{filename}\"");
            if (autoLoadFileName != filename) {
                Console.Write("Would you like to auto-load this file next time you load this program? (Y/N)\n>");
                string setAutoLoad = Console.ReadLine().ToLower();
                if (setAutoLoad == "y" || setAutoLoad == "yes") {
                    using (StreamWriter configFile = new StreamWriter("config.txt")) {
                        configFile.WriteLine("autoload=true");
                        configFile.WriteLine($"filename={filename}");
                    }
                    Console.WriteLine($"File {filename} set to autoload.");
                }
            }
        }

        catch {
            Console.WriteLine($"Sorry, there was an error trying to read from file \"{filename}\".");
        }
    }
    public void SaveFile () {
        Console.Write("What filename would you like to save this directory to?\n>");
        string filename = Console.ReadLine();
        if (File.Exists(filename)) {
            string saveChoice = "";
            while (saveChoice != "1" && saveChoice != "2") {
                Console.Write($"The file {filename} already exists. Would you like to Merge them, or overwrite?\n1. Merge\n2. Overwrite\n>");
                saveChoice = Console.ReadLine();
                if (saveChoice == "1") {
                    savedFile.MergeFile(filename, tempDirectory);
                    Console.WriteLine($"Directory merged with \"{filename}\"");
                    directorySaved = true;
                }
                else if (saveChoice == "2") {
                    savedFile.SaveToFile(filename, tempDirectory);
                    Console.WriteLine($"Directory exported to \"{filename}\"");
                    directorySaved = true;
                }
                else {
                    Console.Write($"Sorry, {saveChoice} is not a valid option. Please try again.");
                }
            }

        }
        else {
            savedFile.SaveToFile(filename, tempDirectory);
            Console.WriteLine($"Directory exported to \"{filename}\"");
            directorySaved = true;
        }
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
    public void DisplayAttributes () {
        int i = 0;
        foreach (string attribute in attributes) {
            i++;
            Console.WriteLine($"{i}. {attribute}");
        }
    }
    public string GetGender () {
        string gender = "";
        while (gender != "male" && gender != "female") {
            Console.Write("Gender\n>");
            gender = Console.ReadLine();
            gender = ToGender(gender);
            if (gender != "male" && gender != "female") {
                Console.WriteLine($"Sorry, {gender} is not a valid gender.");
            }
        }
        return gender;
    }
    public double GetPhone() {
        double phone = 0;
        string tempPhone= "";
        while ($"{tempPhone}".Count() != 10) {
            Console.Write("Phone Number (No spaces or dashes)\n>");
            tempPhone = Console.ReadLine();
            if (IsDouble(tempPhone)) {
                phone = double.Parse(tempPhone);
            }
            else {
                Console.WriteLine($"Sorry, {tempPhone} is not a valid phone number. Please ensure there are no spaces or dashes.");
            } 
            if ($"{tempPhone}".Count() != 10) {
                Console.WriteLine("The number you typed is not 10 digits long. Please re-enter.");
            }
        }
        return phone;
    }
    public bool GetIsAdult() {
        bool isAdult = false;
        string checkBool;
        bool boolConfirmed = false;
        while (boolConfirmed == false) {
            Console.Write("Is this person an adult? (Leave empty for \"no\")\n>");
            checkBool = Console.ReadLine().ToLower();
            try {
                if (checkBool == "y" || checkBool == "yes") {
                    isAdult = true;
                }
                else if (checkBool == "n" || checkBool == "no" || checkBool == "") {
                    isAdult = false;
                }
                else {
                    isAdult = bool.Parse(checkBool);
                }
                boolConfirmed = true;
            }
            catch {
                Console.WriteLine($"Sorry, {checkBool} is not a vaild answer. Please try agin.");
            }
        }
        return isAdult;
    }
    public bool IsDouble (string number) {
        try {
            double newNumber = double.Parse(number);
            return true;
        }
        catch {
            return false;
        }
    }
    private int FindPersonIndex (string person) {
        int i = -1;
        foreach (Person currentPerson in tempDirectory) {
            i++;
            if (currentPerson.GetAttribute("name").ToLower() == person.ToLower()) {
                return i;
            }
        }
        return i;
    }
    private bool IsInt (string number) {
        try {
            int tempInt = int.Parse(number);
            return true;
        }
        catch {
            return false;
        }
    }
    private DateTime ToDate (string date) {
        string[] dateParts = date.Split("/");
        DateTime newDate = new DateTime(int.Parse(dateParts[2]), int.Parse(dateParts[0]), int.Parse(dateParts[1]));
        return newDate;
    }
}