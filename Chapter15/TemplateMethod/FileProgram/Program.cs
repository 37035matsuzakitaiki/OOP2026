using System.Text.RegularExpressions;
using System.Threading.Channels;
using TextFileProcessor;

string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section04\Program.cs";
TextProcessor.Run<LineCounterProcessor>(path);

public class LineCounterProcessor : TextProcessor {
    private int _count = 0;
    string? Word = string.Empty;

    protected override void Initialize(string fname) {
        Console.Write("検索ワード:");
        Word = Console.ReadLine() ?? "";
        _count = 0;
    }

    protected override void Execute(string line) {
        _count += Regex.Matches(line, Regex.Escape(Word)).Count;
    }
    protected override void Terminate() =>
        Console.WriteLine("{0} 個", _count);

}