public class Journal {
    public List<JournalEntry> _Journal = new List<JournalEntry>();
    public void Display () {
        foreach (JournalEntry entry in _Journal) {
            Console.WriteLine($"{entry._Prompt} {entry._Response} {entry._Date}");
        }
    }

    public void CreateEntry (string Prompt, string Response) {
        JournalEntry CurrentEntry = new JournalEntry();
        DateTime Date = DateTime.Now;
        CurrentEntry._Prompt = Prompt;
        CurrentEntry._Response = Response;
        CurrentEntry._Date = $"{Date}";
        _Journal.Add(CurrentEntry);
    }

    public void Export (string FileName) {
        List<string> Entries = new List<string>();
        foreach(JournalEntry entry in _Journal) {
            Entries.Add($"{entry._Prompt}^{entry._Response}^{entry._Date}");
        }
        File.WriteAllLines(FileName, Entries.ToArray());
    }

    public void Import (string FileName) {
        string[] LoadFile = File.ReadAllLines(FileName);
        foreach (string line in LoadFile) {
            string[] sections = line.Split("^");
            JournalEntry CurrentEntry = new JournalEntry();
            CurrentEntry._Prompt = sections[0];
            CurrentEntry._Response = sections[1];
            CurrentEntry._Date = sections[2];
            _Journal.Add(CurrentEntry);
        }
    }

    public void ClearJournal () {
        _Journal.Clear();
    }
}