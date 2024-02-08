using CommandLine;
using GithubManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var arguments = Parser.Default.ParseArguments<Options>(args);
if (arguments.Errors.Any()) return;

var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user/repos");

request.Headers.Add("Authorization", $"Bearer {arguments.Value.Token}");
request.Headers.Add("User-Agent", "a/a");

var response = await client.SendAsync(request);

response.EnsureSuccessStatusCode();

var json = await response.Content.ReadAsStringAsync();

var jArray = JArray.Parse(json);

foreach (var token in jArray) {
    var repo = JsonConvert.DeserializeObject<GithubRepository>(token.ToString());
    if (!repo!.Owner.Login.Equals(arguments.Value.Username, StringComparison.CurrentCultureIgnoreCase)) continue;

    Console.WriteLine(repo.Name);
}