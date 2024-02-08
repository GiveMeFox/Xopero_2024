using Octokit;
using Spectre.Console;

var githubToken = GetGitHubToken();
var githubClient = new GitHubClient(new ProductHeaderValue("GitHubCLI")) {
    Credentials = new Credentials(githubToken)
};

AnsiConsole.Clear();

var user = await githubClient.User.Current();

while (true) {
    var menu = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title($"Welcome to GithubManager {user.Login}!")
            .AddChoices("Add", "Delete", "Exit")
    );

    switch (menu) {
        case "Add":
            AddRepository(githubClient);
            break;
        case "Delete":
            await SelectRepositoriesToDelete(githubClient);
            break;
        case "Exit":
            goto end;
    }
}

end:
return;

static void AddRepository(IGitHubClient githubClient) {
    var repositoryName = AnsiConsole.Ask<string>("Enter repository name: ");
    var repositoryDescription = AnsiConsole.Ask<string>("Enter repository description: ");
    var repository = new NewRepository(repositoryName) {
        Description = repositoryDescription
    };
    var newRepository = githubClient.Repository.Create(repository).Result;
    AnsiConsole.WriteLine($"Repository {newRepository.FullName} created successfully");
}

static string GetGitHubToken() {
    Console.Write("Enter GitHub Token: ");
    return Console.ReadLine();
}

static async Task SelectRepositoriesToDelete(IGitHubClient githubClient) {
    var user = await githubClient.User.Current();
    var repositories = await githubClient.Repository.GetAllForUser(user.Login);
    var repositoryDictionary = repositories.ToDictionary(repo => $"{repo.Owner.Login}/{repo.Name}");
    var repositoriesList = repositoryDictionary.Keys.ToList();
    
    List<string> selectedRepositories;

    while (true) {
        selectedRepositories = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("[gray]Select repositories to delete[/]")
                .NotRequired()
                .PageSize(10)
                .MoreChoicesText("[gray](Move up and down to reveal more repositories)[/]")
                .InstructionsText(
                    "[gray](Press [blue]<space>[/] to select a repository, [blue]<enter>[/] to confirm, [blue]<tab>[/] to go back)[/]")
                .AddChoices(repositoriesList)
        );

        if (selectedRepositories.Count == 0) {
            return;
        }
        
        break;
    }

    foreach (var repoKey in selectedRepositories) {
        if (!repositoryDictionary.TryGetValue(repoKey, out var repository)) continue;
        AnsiConsole.WriteLine(repository.FullName);
    }
    
    var confirmation = AnsiConsole.Confirm("Are you sure you want to delete the selected repositories?");
    if (confirmation) {
        foreach (var repoKey in selectedRepositories) {
            if (!repositoryDictionary.TryGetValue(repoKey, out var repository)) continue;
            AnsiConsole.WriteLine($"Deleting repository: {repository.FullName}");
            await githubClient.Repository.Delete(repository.Id);
        }
    }
    else {
        AnsiConsole.WriteLine("Deletion cancelled");
    }
}
