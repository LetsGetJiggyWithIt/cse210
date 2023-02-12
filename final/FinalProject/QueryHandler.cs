public class QueryHandler {
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
        switch (queryType) {
            case "name":
                string currentName = "";
                foreach(Person person in directory) {
                    currentName = person.GetAttribute("name");
                    if (currentName.ToLower().Contains(queryValue.ToLower()) == true) {
                        person.DisplayInformation();
                    }
                }
                break;
        }
    }

    public bool IsANumber (string number) {
        return true;
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