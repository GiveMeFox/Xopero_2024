using System.Data;
using Microsoft.VisualBasic.FileIO;
using Terminal.Gui;

namespace csv_editor;

public class Window : Terminal.Gui.Window {
    public override bool OnKeyDown(KeyEvent keyEvent) {
        if (keyEvent.Key == Key.q) Environment.Exit(0);
        return base.OnKeyDown(keyEvent);
    }
    static List<string[]> ReadCsvFile(string filePath, char separator) {
        try {
            var data = new List<string[]>();

            using var parser = new TextFieldParser(filePath);
            parser.SetDelimiters([separator.ToString()]);

            while (!parser.EndOfData) {
                var fields = parser.ReadFields();
                if (fields != null) data.Add(fields);
            }

            return data;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error while reading the CSV file: {ex.Message}");
            return null;
        }
    }

    public List<string[]> data = ReadCsvFile(@"C:\Users\Xopero\RiderProjects\csv editor\csv editor\table.csv", ',');

    public Window() {
        var dt = new DataTable();
        
        for (var i = 0; i < data[0].Length; i++) {
            dt.Columns.Add(data[0][i], typeof(int));
        }

        for (var i = 0; i < data.Count; i++) dt.Rows.Add(i, i, i);

        var tableView = new TableView {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(1)
        };
        
        tableView.Table = dt;

        // tableView.Style.GetOrCreateColumnStyle(dt.Columns["ProcessName"])
        //     .RepresentationGetter = v => processes[(int)v].ProcessName;
        // tableView.Style.GetOrCreateColumnStyle(dt.Columns["VirtualMemorySize"])
        //     .RepresentationGetter = v => processes[(int)v].VirtualMemorySize64.ToString();
        // tableView.Style.GetOrCreateColumnStyle(dt.Columns["Responding"])
        //     .RepresentationGetter = v => processes[(int)v].Responding.ToString();

        Add(tableView);
    }

    public sealed override void Add(View view) {
        base.Add(view);
    }
}