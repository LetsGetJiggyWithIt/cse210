public class Resume {
    public string _name = "";
    public List<Job> _job = new List<Job>();

    public Resume () {

    }

    public void Display () {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");
        foreach (Job item in _job) {
            item.Display();
        };
    }
}