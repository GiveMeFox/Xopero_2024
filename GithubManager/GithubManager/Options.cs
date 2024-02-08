using CommandLine;

namespace GithubManager;

public class Options {
    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
    [Option('t', "token", Required = true, HelpText = "Set the access token.")]
    public string Token { get; set; }
    [Option('u', "username", Required = false, HelpText = "Set the username.")]
    public string Username { get; set; }
}