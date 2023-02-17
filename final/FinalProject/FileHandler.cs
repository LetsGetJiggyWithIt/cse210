using System.IO;
public class FileHandler {
    private string fileName;
    public FileHandler (string _fileName = "") {
        fileName = _fileName;
    }

    public void SaveToFile (string _fileName, List<Person> directory) {
        using (StreamWriter outputFile = new StreamWriter(_fileName)) {
            foreach (Person person in directory) {
                string output = person.Export();
                outputFile.WriteLine(output);
            }
        }
    }

    public void MergeFile(string _fileName, List<Person> directory) {
        string[] tempFile = System.IO.File.ReadAllLines(_fileName);
        List<string> fileLines = new List<string>();
        foreach (string line in tempFile) {
            fileLines.Add(line);
        }
        foreach (Person person in directory) {
            if (PersonExists(person, _fileName) == false) {
                fileLines.Add(person.Export());
            }
            else {
                fileLines[GetPersonIndex(person.GetAttribute("name"), _fileName)] = person.Export();
            }
        }
        using (StreamWriter outputFile = new StreamWriter(_fileName)) {
            foreach (string line in fileLines) {
                outputFile.WriteLine(line);
            }
        }
    }

    private bool PersonExists (Person person, string _fileName) {
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string line in lines) {
            if (line.Contains(person.GetAttribute("name"))) {
                return true;
            }
        }
        return false;
    }

    private int GetPersonIndex(string name, string _fileName) {
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        int i = 0;
        foreach (string line in lines) {
            if (line.Contains(name)) {
                return i;
            }
            i++;
        }
        return 0;
    }

    private DateTime ToDate (string text) {
        string[] parts = text.Split("/");
        DateTime date = new DateTime(int.Parse(parts[0]),int.Parse(parts[1]),int.Parse(parts[2]));
        return date;
    }

    public List<Person> LoadFromFile (string _fileName, List<Person> currentList) {
        List<Person> loadedList = currentList;
        List<Position> loadedPositions = new List<Position>();
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string line in lines) {
            loadedPositions = new List<Position>();
            string[] parts = line.Split(",");
            DateTime birthdate = new DateTime();
            if (parts.Count() >= 6) {
                string[] positionList = (parts[5].Substring(1,(parts[5].Count() - 2))).Split("%");
                foreach (string position in positionList) {
                    string[] attributes = position.Split("^");
                    switch (attributes[0]) {
                        case "AttendeePosition":
                            string attendeeName = "";
                            if (parts[1] == "Male") {
                                attendeeName = "Knight";
                            }
                            else {
                                attendeeName = "Handmaiden";
                            }
                            AttendeePosition attendee = new AttendeePosition(attendeeName,attributes[1],int.Parse(attributes[2]),attributes[3]);
                            loadedPositions.Add(attendee);
                            break;
                        case "YouthLeaderPosition":
                            YouthLeaderPosition youthLeader = new YouthLeaderPosition(attributes[1],attributes[2],int.Parse(attributes[3]),attributes[4],bool.Parse(attributes[5]));
                            loadedPositions.Add(youthLeader);
                            break;
                        case "AdultVolunteerPosition":
                            AdultVolunteerPosition adultVolunteer = new AdultVolunteerPosition(attributes[1],int.Parse(attributes[3]),attributes[4],attributes[2]);
                            loadedPositions.Add(adultVolunteer);
                            break;
                        case "VillainPosition":
                            VillainPosition villain;
                            if (attributes.Count() == 1) {
                                villain = new VillainPosition(int.Parse(attributes[3]));
                            }
                            else {
                                villain = new VillainPosition(int.Parse(attributes[3]),bool.Parse(attributes[5]),attributes[2],attributes[1],attributes[4]);
                            }
                            loadedPositions.Add(villain);
                            break;
                        default:
                            break;
                    }
                }
                if (parts.Count() == 7) {
                    birthdate = ToDate(parts[6]);
                }
            }
            Person currentImport;
            if (birthdate != new DateTime()) {
                currentImport = new Person(parts[0],parts[1],double.Parse(parts[2]),parts[3],bool.Parse(parts[4]),loadedPositions,birthdate);
            }
            else {
                currentImport = new Person(parts[0],parts[1],double.Parse(parts[2]),parts[3],bool.Parse(parts[4]),loadedPositions);
            }
            foreach (Person person in loadedList) {
                if (person.GetAttribute("name") == currentImport.GetAttribute("name")) {
                    loadedList.Remove(person);
                }
            }
            loadedList.Add(currentImport);
        }
        return loadedList;
    }
}