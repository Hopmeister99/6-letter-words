// See https://aka.ms/new-console-template for more information
List<string> words = new List<string>();
FileStream fileStream = new FileStream("input.txt", FileMode.Open);
using (StreamReader reader = new StreamReader(fileStream))
{
    string line = reader.ReadLine();
    while(line != null) {
        words.Add(line);
        line = reader.ReadLine();
    }
}

WordProcesser processer = new WordProcesser(words);

processer.FindCombiningWords();
