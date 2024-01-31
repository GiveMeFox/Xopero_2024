using difference;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

Console.Write("Enter the path of the first file:\n>");
var file1Path = Console.ReadLine();

Console.Write("Enter the path of the second file:\n>");
var file2Path = Console.ReadLine();

if (!File.Exists(file1Path) || !File.Exists(file2Path)) {
    Console.WriteLine("One or both of the specified files do not exist.");
    return;
}

var file1Content = File.ReadAllText(file1Path);
var file2Content = File.ReadAllText(file2Path);

var differ = new Differ();
var inlineBuilder = new InlineDiffBuilder(differ);
var diffResult = inlineBuilder.BuildDiffModel(file1Content, file2Content);
var maxIndex = diffResult.Lines.Count.ToString().Length;

foreach (var line in diffResult.Lines) {
    var prefix = $"{line.Position}".PadLeft(maxIndex) + line.Type switch {
        ChangeType.Inserted => " + ",
        ChangeType.Deleted => " - ",
        _ => "   "
    };
    
    PrintColoredLine(prefix + line.Text, GetConsoleColor(line.Type));
}

return;

// static List<DiffSegment> FindDifferences(string first, string second) {
//     var differences = new List<DiffSegment>();
//
//     var i = 0;
//
//     while (i < first.Length && i < second.Length)
//         if (first[i] != second[i]) {
//             var start = i;
//
//             while (i < first.Length && i < second.Length && first[i] != second[i]) i++;
//
//             differences.Add(new DiffSegment(start, i - 1));
//         }
//         else {
//             i++;
//         }
//
//     if (i < first.Length)
//         differences.Add(new DiffSegment(i, first.Length - 1));
//     else if (i < second.Length) differences.Add(new DiffSegment(i, second.Length - 1));
//
//     return differences;
// }

ConsoleColor GetConsoleColor(ChangeType type) {
    return type switch {
        ChangeType.Inserted => ConsoleColor.DarkGreen,
        ChangeType.Deleted => ConsoleColor.DarkRed,
        _ => ConsoleColor.Gray
    };
}

void PrintColoredLine(string text, ConsoleColor color) {
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = color;

    Console.WriteLine(text);

    Console.ResetColor();
}

internal class DiffSegment(int start, int end) {
    private int Start { get; } = start;
    private int End { get; } = end;

    public override string ToString() {
        return $"{Start}-{End}";
    }
}