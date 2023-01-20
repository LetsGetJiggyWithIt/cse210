public class Reference {
    private string Book = "";
    private int Chapter = 0;
    private List<int> Verses = new List<int>();
    public Reference (string _Book, int _Chapter, int _Verse){
        Book = _Book;
        Chapter = _Chapter;
        Verses.Add(_Verse);
    }
    public Reference (string _Book, int _Chapter, int _VerseStart, int _VerseEnd){
        Book = _Book;
        Chapter = _Chapter;
        Verses.Add(_VerseStart);
        Verses.Add(_VerseEnd);
    }
    public string GetBook() {
        return Book;
    }
    public int GetChapter() {
        return Chapter;
    }
    public string GetVerses() {
        if (Verses.Count() == 1){
            return $"{Verses[0]}";
        }
        else {
            return $"{Verses[0]}-{Verses[1]}";
        }
    }
}