public class Activity {
    private string _ActivityName;
    private string _SummaryMessage;
    protected int _ActivityLength = 0;
    protected int _TimePassed = 0;
    private string _EndingMessage;
    public Activity (string ActivityName, string SummaryMessage, string EndingMessage) {
        _ActivityName = ActivityName;
        _SummaryMessage = SummaryMessage;
        _EndingMessage = EndingMessage;
    }

    public void DisplaySummary () {
        Console.WriteLine(_ActivityName);
        Console.WriteLine();
        Console.WriteLine(_SummaryMessage);
    }

    public void DisplayTimer (int seconds, string lastMessage = "") {
        Console.CursorVisible = false;
        Console.WriteLine();
        for (int i = 0; i < seconds; i++) {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            if (lastMessage != "") {
                Console.Write(lastMessage);
            }
            Console.Write($" ({seconds - i})");
            Thread.Sleep(1000);
        }
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
        if (lastMessage != "") {
            Console.Write(lastMessage);
        }
        Console.CursorVisible = true;
    }

    public void PauseActivity (int seconds, string endMessage = "") {
        Console.CursorVisible = false;
        string animation = "...";
        int counter = 0;
        List<string> animationFrames = new List<string>();
        animationFrames.Add(".");
        animationFrames.Add("..");
        animationFrames.Add("...");
        animationFrames.Add(" ..");
        animationFrames.Add("  .");
        animationFrames.Add("  ");
        if (endMessage != "" && endMessage != "Get Ready") {
            endMessage += " ";
        }

        for (int i = 0; i < seconds; i++) {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            if (counter == animationFrames.Count()) {
                counter = 0;
            }
            animation = animationFrames[counter];
            counter++;
            Console.Write($"{endMessage}{animation}");
            Thread.Sleep(1000);
        }
        Console.CursorVisible = true;
    }

    public void SetActivityLength () {
        _ActivityLength = 0;
        while (_ActivityLength < 10) {
            Console.Write("How long would you like to do this activity? (In seconds) ");
            _ActivityLength = int.Parse(Console.ReadLine());
            if (_ActivityLength < 10) {
                Console.WriteLine("\nSorry, the minimum amount of seconds you can do this activity is 10 seconds.");
            }
        }
    }

    public void EndActivity () {
        Console.WriteLine($"\n\n{_EndingMessage}");
        PauseActivity(3);
        Console.WriteLine($"\nYou have comepleted {_ActivityLength} seconds of the {_ActivityName}.");
        PauseActivity(5);
    }
}