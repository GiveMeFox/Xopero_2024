namespace gmf;

public class GridStyle {
    private List<List<GridRow>> Rows { get; } = new();

    public GridStyle(params GridRow[] rows) {
        Rows.Add(rows.ToList());
    }

    public void ApplyStyle(List<Button> buttons, float containerWidth, float spacing) {
        float currentY = 0;
        var btnIndex = 0;

        foreach (var rowList in Rows)
        foreach (var row in rowList) {
            var totalFixedWidth = row.Columns.Where(col => !col.IsDynamic).Sum(col => col.Width);
            var dynamicColumns = row.Columns.Count(col => col.IsDynamic);
            var dynamicWidth = (containerWidth - totalFixedWidth - (row.Columns.Count - 1) * spacing) / dynamicColumns;
            float currentX = 0;

            for (var i = 0; i < Math.Min(buttons.Count, row.Columns.Count); i++) {
                var button = buttons[btnIndex];
                btnIndex++;
                var column = row.Columns[i];

                button.SetSize(column.IsDynamic ? dynamicWidth : column.Width, button.Height);
                button.SetPosition(currentX, currentY);

                currentX += column.IsDynamic ? dynamicWidth : column.Width;

                if (i < row.Columns.Count - 1) {
                    currentX += spacing;
                }
            }

            currentY += row.Columns.Any(col => !col.IsDynamic) ? row.Columns.Where(col => !col.IsDynamic).Max(col => col.Width) + spacing : 0;
        }
    }
}

public class GridRow {
    public List<GridColumn> Columns { get; } = new();

    public GridRow(params GridColumn[] columns) {
        Columns.AddRange(columns);
    }
}

public class GridColumn {
    public float Width { get; set; }
    public bool IsDynamic { get; }

    public GridColumn(float width, bool isDynamic = false) {
        Width = width;
        IsDynamic = isDynamic;
    }
}