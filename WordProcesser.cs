public class WordProcesser {
    private List<string> sixLetterwords = new List<string>();
    private List<string> wordParts = new List<string>();

    public WordProcesser(List<string> words) {
        this.sixLetterwords = words.FindAll(w => w.Length == 6);
        this.wordParts = words.FindAll(w => w.Length < 6);
    }

    public void FindCombiningWords() {
        foreach (string wordPart in wordParts) {
            List<string> history = new List<string>();
            history.Add(wordPart);

            List<string> newParts = new List<string>(wordParts);
            newParts.Remove(wordPart);
            
            Combine(wordPart, history, newParts);
        }
    }

    private string Combine(string part, List<string> history, List<string> parts) {
        foreach (string wordPart in parts) {
            string newPart = part + wordPart;
            if (sixLetterwords.Find(w => w.StartsWith(newPart)) != null) {
                List<string> newHistory = new List<string>(history);
                newHistory.Add(wordPart);

                if (Check(newPart, newHistory)) return newPart;

                List<string> newParts = new List<string>(parts);
                newParts.Remove(wordPart);

                return Combine(newPart, newHistory, newParts);
            }
        }
        return part;
    }

    private bool Check(string word, List<string> history) {
        if (word.Length == 6) {
            string toPrint = string.Join("+", history);
            toPrint = toPrint + "=" + word;
            Console.WriteLine(toPrint);
            return true;
        }
        return false;
    }

}