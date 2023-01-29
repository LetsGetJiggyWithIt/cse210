public class BreathingActivity : Activity{
    private string _CurrentPrompt = "Breathe In...";
    public BreathingActivity (string ActivityName = "Breathing Activity", string SummaryMessage = "This Activity will help you to relax and clear your mind by helping you breathe slowly in and out.", string EndingMessage = "Good Job!") : base(ActivityName, SummaryMessage, EndingMessage){

    }
    public void StartActivity () {
        DisplaySummary();
        SetActivityLength();
        Console.Clear();
        PauseActivity(3, "Get Ready");
        int step = 5;
        while (_TimePassed < _ActivityLength) {
            while (_TimePassed + step > _ActivityLength) {
                step--;
            }
            DisplayTimer(step, _CurrentPrompt);
            _TimePassed += step;
            ChangePrompt();
        }
        EndActivity();
    }
    private void ChangePrompt () {
        if (_CurrentPrompt == "Breathe Out...") {
            _CurrentPrompt = "Breathe In...";
        }
        else {
            _CurrentPrompt = "Breathe Out...";
        }
    }
}