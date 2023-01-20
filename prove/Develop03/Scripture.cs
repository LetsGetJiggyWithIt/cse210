public class Scripture {
    private Reference Ref;
    private List<Word> Words = new List<Word>();
    private Random RandomNumber = new Random();
    private int ShownWords = 0;

    public Scripture(){
        Import("scriptures.txt");
    }
    public Scripture(Reference _Ref, string _Verse){
        Ref = _Ref;
        Words = CreateWordList(_Verse);
        ShownWords = Words.Count();
    }

    public string GetReference () {
        return $"{Ref.GetBook()} {Ref.GetChapter()}:{Ref.GetVerses()}";
    }
    public void Display (int HideAmount) {
        Console.Clear();
        HideRandomWords(HideAmount);
        Console.WriteLine($"{GetReference()}\n");
        foreach (Word item in Words) {
            Console.Write($"{item.GetValue()} ");
        }
        Console.WriteLine("");
    }

    private List<Word> CreateWordList (string _Verse) {
        Word CurrentWord;
        List<Word> WordList = new List<Word>();
        foreach (string line in _Verse.Split(" ")) {
            CurrentWord = new Word(line);
            WordList.Add(CurrentWord);
        }
        return WordList;
    }

    private void HideRandomWords (int amount) {
        if (amount > ShownWords) {
            amount = ShownWords;
        }
        int i = 0;
        while (i < amount) {
            int CurrentRandom = RandomNumber.Next(0, Words.Count());
            if (Words[CurrentRandom].IsHidden() == false) {
                Words[CurrentRandom].Hide();
                i++;
                ShownWords--;
            }
        }
    }

    public int GetShownWords () {
        return ShownWords;
    }

    private void Import (string FileName) {
        string[] LoadFile = File.ReadAllLines(FileName);
        Random RandomScripture = new Random();
        string Line = LoadFile[RandomScripture.Next(0, LoadFile.Count())];
        string[] sections = Line.Split("^");
        if (sections.Count() == 4) {
            Ref = new Reference(sections[0], int.Parse(sections[1]), int.Parse(sections[2]));
            Words = CreateWordList(sections[3]);
        }
        else {
            Ref = new Reference(sections[0], int.Parse(sections[1]), int.Parse(sections[2]), int.Parse(sections[3]));
            Words = CreateWordList(sections[4]);
        }
        ShownWords = Words.Count();
    }
}