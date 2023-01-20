public class Word {
    private bool Hidden = false;
    private string Value;
    public Word (string _Value){
        Value = _Value;
    }
    public bool IsHidden() {
        return Hidden;
    }
    public void Hide () {
        Hidden = true;
    }
    public string GetValue () {
        if (Hidden == false) {
            return Value;
        }
        else {
            string Blank = "";
            for (int i = 0; i < Value.Count(); i++) {
                Blank += "_";
            }
            return Blank;
        }
    }
}