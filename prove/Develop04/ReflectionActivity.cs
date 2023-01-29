public class ReflectionActivity : Activity{
    private List<string> _PromptList = new List<string>();
    private List<string> _UsedPrompts = new List<string>();
    private List<string> _QuestionList = new List<string>();
    private List<string> _UsedQuestions = new List<string>();
    private string _CurrentPrompt;
    private string _CurrentQuestion;
    private Random _NumberGenerator = new Random();
    public ReflectionActivity (string PromptsFileName = "", string QuestionsFilename = "", string ActivityName = "Reflection Activity", string SummaryMessage = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", string EndingMessage = "Well done!") : base(ActivityName, SummaryMessage, EndingMessage) {
        if (PromptsFileName == "" & QuestionsFilename == "") {
            ImportPrompts("prompts.txt");
            ImportQuestions("reflection-questions.txt");        
        }
        if (PromptsFileName != "") {
            ImportPrompts(PromptsFileName);
        }
        if (QuestionsFilename != "") {
            ImportQuestions(QuestionsFilename);
        }
    }

    public void StartActivity () {
        int _TimePassed = 0;
        Console.Clear();
        DisplaySummary();
        SetActivityLength();
        PauseActivity(3, "Get Ready");
        GetPrompt();
        Console.WriteLine($"\n{_CurrentPrompt}");
        Console.WriteLine("Press Enter once you are ready to continue.");
        string wait = Console.ReadLine();
        int step = 10;
        while (_TimePassed < _ActivityLength) {
            while (_TimePassed + step > _ActivityLength) {
                step--;
            }
            GetQuestion();
            DisplayTimer(step, _CurrentQuestion);
            _TimePassed += step;
        }
        EndActivity();
    }

    public void AddListItem (string ListName, string Value) {
        if (ListName == "_PromptList" | ListName == "PromptList") {
            _PromptList.Add(Value);
        }
        else if (ListName == "_QuestionList" | ListName == "QuestionList") {
            _QuestionList.Add(Value);
        }
        else {
            Console.WriteLine($"Error: List name {ListName} is not supported.");
        }
    }

    private void GetPrompt () {
        if (_UsedPrompts.Count() != 0 & _UsedPrompts.Count() == _PromptList.Count()) {
            _UsedPrompts.RemoveAt(0);
        }
        int _RandomNumber = _NumberGenerator.Next(0, _PromptList.Count());
        _CurrentPrompt = _PromptList[_RandomNumber];
        while (_UsedPrompts.Contains(_CurrentPrompt)) {
            _RandomNumber = _NumberGenerator.Next(0, _PromptList.Count());
            _CurrentPrompt = _PromptList[_RandomNumber];
        }
        _UsedPrompts.Add(_CurrentPrompt);
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
    public void ImportPrompts (string FileName) {
        string[] LoadFile = File.ReadAllLines(FileName);
        foreach (string line in LoadFile) {
            _PromptList.Add(line);
        }
    }
}