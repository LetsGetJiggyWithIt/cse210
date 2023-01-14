public class JournalPrompts{
    public List<string> _Prompts = new List<string>();
    public List<int> _UsedPrompts = new List<int>();
    public int _PromptAmount = 0;
    public string RandomPrompt () {
        Random RandomNumber = new Random();
        int ChosenPrompt = RandomNumber.Next(0, (_Prompts.Count));
        while (_UsedPrompts.Contains(ChosenPrompt)) {
            ChosenPrompt = RandomNumber.Next(0, (_Prompts.Count));
        }
        if (_PromptAmount < 8) {
            _PromptAmount += 1;
        }
        else {
            _UsedPrompts.RemoveAt(0);
        }
        _UsedPrompts.Add(ChosenPrompt);
        return _Prompts[ChosenPrompt];
    }
    public void AddPrompt (string prompt) {
        _Prompts.Add(prompt);
    }
}