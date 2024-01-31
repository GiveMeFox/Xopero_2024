using System.Data.SQLite;
using ConsoleTables;

const string connectionString = @"Data Source=C:\Users\Xopero\RiderProjects\DbEditor\DbEditor\articles.db;Version=3;";

CreateArticleTable(connectionString);

while (true) {
    Console.WriteLine("1. Wyświetl artykuły");
    Console.WriteLine("2. Dodaj artykuł");
    Console.WriteLine("3. Edytuj artykuł");
    Console.WriteLine("4. Usuń artykuł");
    Console.WriteLine("5. Wyjdź");

    Console.Write("Wybierz opcję: ");
    var choice = Console.ReadLine();

    switch (choice) {
        case "1":
            DisplayArticles(connectionString);
            break;
        case "2":
            AddArticle(connectionString);
            break;
        case "3":
            EditArticle(connectionString);
            break;
        case "4":
            DeleteArticle(connectionString);
            break;
        case "5":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            break;
    }
}

static void CreateArticleTable(string connectionString) {
    using var connection = new SQLiteConnection(connectionString);
    connection.Open();

    const string createTableQuery = "CREATE TABLE IF NOT EXISTS Articles (" +
                                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Name TEXT NOT NULL, " +
                                    "Category TEXT NOT NULL, " +
                                    "CreationDate DATETIME NOT NULL, " +
                                    "ModificationDate DATETIME NOT NULL, " +
                                    "Content TEXT NOT NULL)";

    using var command = new SQLiteCommand(createTableQuery, connection);
    command.ExecuteNonQuery();
}

static void DisplayTable(List<string[]> data) {
    if (data.Count == 0) {
        Console.WriteLine("No data to display.");
        return;
    }

    var table = new ConsoleTable(data[0]) {
        Options = {
            EnableCount = false
        }
    };

    for (var i = 1; i < data.Count; i++) table.AddRow(data[i]);

    table.Write();
}

static void DisplayArticles(string connectionString) {
    using var connection = new SQLiteConnection(connectionString);
    connection.Open();

    const string selectQuery = "SELECT * FROM Articles ORDER BY CreationDate DESC";

    using var command = new SQLiteCommand(selectQuery, connection);
    using var reader = command.ExecuteReader();
    
    var data = new List<string[]>();
    
    while (reader.Read()) {
        data.Add([
            reader["Id"].ToString(),
            reader["Name"].ToString(),
            reader["Category"].ToString(),
            reader["CreationDate"].ToString(),
            reader["ModificationDate"].ToString()
        ]);
    }

    DisplayTable(data);

    if (reader.Read()) {
        Console.WriteLine("ID\tName\tCategory\tCreation Date\t\tModification Date");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine(
            $"{reader["Id"]}\t{reader["Name"]}\t{reader["Category"]}" +
            $"\t{reader["CreationDate"]}\t{reader["ModificationDate"]}");
    }
    else {
        Console.WriteLine("Brak artykułów.");
    }

    while (reader.Read())
        Console.WriteLine(
            $"{reader["Id"]}\t{reader["Name"]}\t{reader["Category"]}" +
            $"\t{reader["CreationDate"]}\t{reader["ModificationDate"]}");
}

static void AddArticle(string connectionString) {
    Console.Write("Podaj nazwę artykułu: ");
    var name = Console.ReadLine();

    Console.Write("Podaj kategorię artykułu: ");
    var category = Console.ReadLine();

    var creationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    Console.Write("Podaj treść artykułu: ");
    var content = Console.ReadLine();

    using var connection = new SQLiteConnection(connectionString);
    connection.Open();

    const string insertQuery = "INSERT INTO Articles (Name, Category, CreationDate, ModificationDate, Content) " +
                               "VALUES (@Name, @Category, @CreationDate, @ModificationDate, @Content)";

    using var command = new SQLiteCommand(insertQuery, connection);
    command.Parameters.AddWithValue("@Name", name);
    command.Parameters.AddWithValue("@Category", category);
    command.Parameters.AddWithValue("@CreationDate", creationDate);
    command.Parameters.AddWithValue("@ModificationDate", creationDate);
    command.Parameters.AddWithValue("@Content", content);

    command.ExecuteNonQuery();

    Console.WriteLine("Artykuł dodany pomyślnie.");
}

static void EditArticle(string connectionString) {
    Console.Write("Podaj ID artykułu do edycji: ");
    int articleId;

    while (!int.TryParse(Console.ReadLine(), out articleId)) {
        Console.WriteLine("Nieprawidłowy format ID. Spróbuj ponownie.");
        Console.Write("Podaj ID artykułu do edycji: ");
    }

    using var connection = new SQLiteConnection(connectionString);
    connection.Open();

    const string selectQuery = "SELECT * FROM Articles WHERE Id = @Id";

    using var selectCommand = new SQLiteCommand(selectQuery, connection);
    selectCommand.Parameters.AddWithValue("@Id", articleId);

    using var reader = selectCommand.ExecuteReader();

    if (reader.Read()) {
        Console.WriteLine($"Aktualne wartości artykułu (ID: {reader["Id"]}):");
        Console.WriteLine($"Name: {reader["Name"]}");
        Console.WriteLine($"Category: {reader["Category"]}");
        Console.WriteLine($"Content: {reader["Content"]}");
        Console.WriteLine("----------------------------------------------------------");

        Console.Write("Nowa nazwa artykułu (naciśnij Enter, aby pozostawić niezmienioną): ");
        var newName = Console.ReadLine();

        Console.Write("Nowa kategoria artykułu (naciśnij Enter, aby pozostawić niezmienioną): ");
        var newCategory = Console.ReadLine();

        Console.Write("Nowa treść artykułu (naciśnij Enter, aby pozostawić niezmienioną): ");
        var newContent = Console.ReadLine();

        var updateQuery = "UPDATE Articles SET ";

        if (!string.IsNullOrWhiteSpace(newName)) {
            updateQuery += "Name = @Name, ";
        }

        if (!string.IsNullOrWhiteSpace(newCategory)) {
            updateQuery += "Category = @Category, ";
        }

        if (!string.IsNullOrWhiteSpace(newContent)) {
            updateQuery += "Content = @Content, ";
        }

        updateQuery += "ModificationDate = @ModificationDate ";
        updateQuery += "WHERE Id = @Id";

        Console.WriteLine(updateQuery);

        using var updateCommand = new SQLiteCommand(updateQuery, connection);

        if (updateQuery.Contains("Name")) {
            updateCommand.Parameters.AddWithValue("@Name", newName);
        }

        if (updateQuery.Contains("Category")) {
            updateCommand.Parameters.AddWithValue("@Category", newCategory);
        }

        if (updateQuery.Contains("Content")) {
            updateCommand.Parameters.AddWithValue("@Category", newCategory);
        }

        updateCommand.Parameters.AddWithValue("@ModificationDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        updateCommand.Parameters.AddWithValue("@Id", articleId);

        updateCommand.ExecuteNonQuery();

        Console.WriteLine("Artykuł zaktualizowany pomyślnie.");
    }
    else {
        Console.WriteLine($"Artykuł o ID {articleId} nie istnieje.");
    }
}

static void DeleteArticle(string connectionString) {
    Console.Write("Podaj ID artykułu do usunięcia: ");
    int articleId;

    while (!int.TryParse(Console.ReadLine(), out articleId)) {
        Console.WriteLine("Nieprawidłowy format ID. Spróbuj ponownie.");
        Console.Write("Podaj ID artykułu do usunięcia: ");
    }

    using var connection = new SQLiteConnection(connectionString);
    connection.Open();

    const string deleteQuery = "DELETE FROM Articles WHERE Id = @Id";

    using var command = new SQLiteCommand(deleteQuery, connection);
    command.Parameters.AddWithValue("@Id", articleId);

    var rowsAffected = command.ExecuteNonQuery();

    Console.WriteLine(rowsAffected > 0
        ? $"Artykuł o ID {articleId} został pomyślnie usunięty."
        : $"Artykuł o ID {articleId} nie istnieje.");
}