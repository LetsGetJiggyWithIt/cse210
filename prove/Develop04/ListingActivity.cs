public class ListingActivity : Activity {
    private List<string> _QuestionList = new List<string>();
    private List<string> _UsedQuestions = new List<string>();
    private List<string> _GratitudeList = new List<string>();
    private string _CurrentQuestion;
    
    private Random _NumberGenerator = new Random();
    public ListingActivity (string QuestionsFileName = "", string ActivityName = "Listing Activity", string SummaryMessage = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", string EndingMessage = "Amazing!") : base(ActivityName, SummaryMessage, EndingMessage) {
        if (QuestionsFileName == "") {
            ImportQuestions("listing-questions.txt");
        }
        else {
            ImportQuestions(QuestionsFileName);
        }
    }
    public void StartActivity () {
        _GratitudeList.Clear();
        Console.Clear();
        DisplaySummary();
        SetActivityLength();
        PauseActivity(3, "Get Ready");
        GetQuestion();
        DisplayTimer(10, _CurrentQuestion);
        DateTime StartTime = DateTime.Now;
        DateTime EndTime = StartTime.AddSeconds(_ActivityLength);
        DateTime CurrentTime = DateTime.Now;
        while (CurrentTime < EndTime) {
            Console.Write("\n> ");
            _GratitudeList.Add(Console.ReadLine());
            CurrentTime = DateTime.Now;
        }
        Console.WriteLine($"\nYou've listed {_GratitudeList.Count()} items!");
        EndActivity();
    }

    public void AddQuestion (string Value) {
        _QuestionList.Add(Value);
    }

    private void GetQuestion () {
        if (_UsedQuestions.Count() != 0 & _UsedQuestions.Count() == _QuestionList.Count()) {
            _UsedQuestions.RemoveAt(0);
        }
        int _RandomNumber = _NumberGenerator.Next(0, _QuestionList.Count());
        _CurrentQuestion = _QuestionList[_RandomNumber];
        while (_UsedQuestions.Contains(_CurrentQuestion)) {
            _RandomNumber = _NumberGenerator.Next(0, _QuestionList.Count());
            _CurrentQuestion = _QuestionList[_RandomNumber];
        }
        _UsedQuestions.Add(_CurrentQuestion);
    }

    public void ImportQuestions (string FileName) {
        string[] LoadFile = File.ReadAllLines(FileName);
        foreach (string line in LoadFile) {
            _QuestionList.Add(line);
        }
    }
}