using System;
using System.Globalization;

public class QueryHandler {
    private TextInfo TI = new CultureInfo("en-us", false).TextInfo;
    private List<string> queryOptions = new List<string> {
        "Name",
        "Gender",
        "Age",
        "Year",
        "Position"
    };

    private List<Person> directory = new List<Person>();
    public QueryHandler () {

    }

    public void NewQuery (string queryType, string queryValue) {
        int matches = 0;
        Console.WriteLine();
        switch (queryType) {
            case "name":
                string currentName = "";
                foreach(Person person in directory) {
                    currentName = person.GetAttribute("name");
                    if (currentName.ToLower().Contains(queryValue.ToLower()) == true) {
                        Console.WriteLine(person.GetAttribute("name"));
                        matches++;
                    }
                }
                Console.WriteLine($"\n{matches} matches found for the name \"{TI.ToTitleCase(queryValue)}\"\n");
                break;
            case "gender":
                queryValue = TI.ToTitleCase(queryValue); 
                string currentGender = "";
                foreach(Person person in directory) {
                    currentGender = person.GetAttribute("gender");
                    if (currentGender == queryValue) {
                        Console.WriteLine($"{person.GetAttribute("name")}");
                        matches++;
                    }
                }
                Console.WriteLine($"\n{matches} matches found for gender \"{queryValue}\"\n");
                break;
            case "age":
                if (IsInt(queryValue)) {
                    foreach (Person person in directory) {
                        bool hasPosition = false;
                        foreach (Position position in person.GetPositions()) {
                            if (position.GetAttribute("age") == queryValue) {
                                matches++;
                                string ageFill = "";
                                if (person.GetCurrentAge() == queryValue) {
                                    ageFill = " (Current age)";
                                }
                                Console.WriteLine($"{person.GetAttribute("name")}{ageFill}");
                                position.DisplayInformation();
                                hasPosition = true;
                            }
                        }
                        if (person.GetCurrentAge() == queryValue) {
                            if (hasPosition != true) {
                                Console.WriteLine($"{person.GetAttribute("name")} (Current age)");
                                matches++;
                            }
                        }
                    }
                    Console.WriteLine($"\n{matches} Matches found for age {queryValue}");
                }
                else {
                    Console.WriteLine($"Sorry, it appears that {queryValue} is not a valid age.");
                }
                break;
            case "year":
                if (IsInt(queryValue)) {
                    foreach (Person person in directory) {
                        foreach (Position position in person.GetPositions()) {
                            if ($"{position.GetAttribute("year")}" == queryValue) {
                                matches++;
                                Console.WriteLine(person.GetAttribute("name"));
                                position.DisplayInformation();
                            }
                        }
                    }
                }
                else {
                    Console.WriteLine($"Sorry, it appears that {queryValue} is not a valid year.");
                }
                break;
            case "position":
                foreach (Person person in directory) {
                    foreach (Position position in person.GetPositions()) {
                        if (position.GetAttribute("name").ToLower().Contains(queryValue.ToLower())) {
                            matches++;
                            if (matches == 1) {
                                Console.WriteLine(person.GetAttribute("name"));
                                Console.WriteLine();
                            }
                            position.DisplayInformation();
                            Console.WriteLine();
                        }
                    }
                }
                break;
        }
    }

    public Person GetPerson(string name) {
        foreach (Person currentPerson in directory) {
            if (currentPerson.GetAttribute("name").ToLower() == name.ToLower()) {
                return currentPerson;
            }
        }
        return new Person();
    }

    public bool IsInt (string number) {
        try {
            int testInt = int.Parse(number);
            return true;
        }
        catch {
            return false;
        }
    }

    public void DisplayQueryOptions () {
        int i = 0;
        foreach (string option in queryOptions) {
            i++;
            Console.WriteLine($"{i}. {option}");
        }
    }

    public void UpdateDirectory(List<Person> newDirectory) {
        directory = newDirectory;
    }
}