using Microsoft.VisualBasic.FileIO;
using ConsoleTables;
using Terminal.Gui;
using Window = csv_editor.Window;

// Console.Write("Enter the CSV file path>");
//var filePath = Console.ReadLine();

// if (File.Exists(filePath)) {
//     Console.WriteLine("Select separator:");
//     Console.WriteLine("1. ,");
//     Console.WriteLine("2. ;");
//     Console.Write("3. SPACE\n>");
//
//     var selectedSeparator = GetSelectedSeparator();
//
//     Console.WriteLine();
     DisplayTable();
// }
// else {
//     Console.WriteLine("Invalid file path.");
// }

// return;

static char GetSelectedSeparator() {
    ConsoleKeyInfo keyInfo;
    do {
        keyInfo = Console.ReadKey();
    } while (keyInfo.Key != ConsoleKey.D1 && keyInfo.Key != ConsoleKey.D2 && keyInfo.Key != ConsoleKey.D3);

    return keyInfo.Key switch {
        ConsoleKey.D1 => ',',
        ConsoleKey.D2 => ';',
        ConsoleKey.D3 => '\t',
        _ => throw new InvalidOperationException("Invalid choice.")
    };
}
static void DisplayTable() {
    Application.Run<Window>();

    // var table = new ConsoleTable(data[0]);
    //
    // for (var i = 1; i < data.Count; i++) table.AddRow(data[i]);
    //
    // table.Write();
}