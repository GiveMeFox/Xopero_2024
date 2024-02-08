namespace GithubManager;

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class GithubRepository {
    [JsonProperty("allow_forking")] public bool AllowForking { get; set; }

    [JsonProperty("stargazers_count")] public long StargazersCount { get; set; }

    [JsonProperty("is_template")] public bool IsTemplate { get; set; }

    [JsonProperty("pushed_at")] public DateTimeOffset PushedAt { get; set; }

    [JsonProperty("subscription_url")] public Uri SubscriptionUrl { get; set; }

    [JsonProperty("language")] public string Language { get; set; }

    [JsonProperty("branches_url")] public string BranchesUrl { get; set; }

    [JsonProperty("issue_comment_url")] public string IssueCommentUrl { get; set; }

    [JsonProperty("labels_url")] public string LabelsUrl { get; set; }

    [JsonProperty("subscribers_url")] public Uri SubscribersUrl { get; set; }

    [JsonProperty("permissions")] public Permissions Permissions { get; set; }

    [JsonProperty("releases_url")] public string ReleasesUrl { get; set; }

    [JsonProperty("svn_url")] public Uri SvnUrl { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("has_discussions")] public bool HasDiscussions { get; set; }

    [JsonProperty("forks")] public long Forks { get; set; }

    [JsonProperty("archive_url")] public string ArchiveUrl { get; set; }

    [JsonProperty("git_refs_url")] public string GitRefsUrl { get; set; }

    [JsonProperty("forks_url")] public Uri ForksUrl { get; set; }

    [JsonProperty("visibility")] public string Visibility { get; set; }

    [JsonProperty("statuses_url")] public string StatusesUrl { get; set; }

    [JsonProperty("ssh_url")] public string SshUrl { get; set; }

    [JsonProperty("full_name")] public string FullName { get; set; }

    [JsonProperty("size")] public long Size { get; set; }

    [JsonProperty("languages_url")] public Uri LanguagesUrl { get; set; }

    [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

    [JsonProperty("collaborators_url")] public string CollaboratorsUrl { get; set; }

    [JsonProperty("clone_url")] public Uri CloneUrl { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("pulls_url")] public string PullsUrl { get; set; }

    [JsonProperty("default_branch")] public string DefaultBranch { get; set; }

    [JsonProperty("hooks_url")] public Uri HooksUrl { get; set; }

    [JsonProperty("trees_url")] public string TreesUrl { get; set; }

    [JsonProperty("tags_url")] public Uri TagsUrl { get; set; }

    [JsonProperty("private")] public bool Private { get; set; }

    [JsonProperty("contributors_url")] public Uri ContributorsUrl { get; set; }

    [JsonProperty("has_downloads")] public bool HasDownloads { get; set; }

    [JsonProperty("notifications_url")] public string NotificationsUrl { get; set; }

    [JsonProperty("open_issues_count")] public long OpenIssuesCount { get; set; }

    [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("watchers")] public long Watchers { get; set; }

    [JsonProperty("keys_url")] public string KeysUrl { get; set; }

    [JsonProperty("deployments_url")] public Uri DeploymentsUrl { get; set; }

    [JsonProperty("has_projects")] public bool HasProjects { get; set; }

    [JsonProperty("archived")] public bool Archived { get; set; }

    [JsonProperty("has_wiki")] public bool HasWiki { get; set; }

    [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("comments_url")] public string CommentsUrl { get; set; }

    [JsonProperty("stargazers_url")] public Uri StargazersUrl { get; set; }

    [JsonProperty("disabled")] public bool Disabled { get; set; }

    [JsonProperty("git_url")] public string GitUrl { get; set; }

    [JsonProperty("has_pages")] public bool HasPages { get; set; }

    [JsonProperty("owner")] public Owner Owner { get; set; }

    [JsonProperty("commits_url")] public string CommitsUrl { get; set; }

    [JsonProperty("compare_url")] public string CompareUrl { get; set; }

    [JsonProperty("git_commits_url")] public string GitCommitsUrl { get; set; }

    [JsonProperty("topics")] public List<object> Topics { get; set; }

    [JsonProperty("blobs_url")] public string BlobsUrl { get; set; }

    [JsonProperty("git_tags_url")] public string GitTagsUrl { get; set; }

    [JsonProperty("merges_url")] public Uri MergesUrl { get; set; }

    [JsonProperty("downloads_url")] public Uri DownloadsUrl { get; set; }

    [JsonProperty("has_issues")] public bool HasIssues { get; set; }

    [JsonProperty("web_commit_signoff_required")]
    public bool WebCommitSignoffRequired { get; set; }

    [JsonProperty("url")] public Uri Url { get; set; }

    [JsonProperty("contents_url")] public string ContentsUrl { get; set; }

    [JsonProperty("milestones_url")] public string MilestonesUrl { get; set; }

    [JsonProperty("teams_url")] public Uri TeamsUrl { get; set; }

    [JsonProperty("fork")] public bool Fork { get; set; }

    [JsonProperty("issues_url")] public string IssuesUrl { get; set; }

    [JsonProperty("events_url")] public Uri EventsUrl { get; set; }

    [JsonProperty("issue_events_url")] public string IssueEventsUrl { get; set; }

    [JsonProperty("assignees_url")] public string AssigneesUrl { get; set; }

    [JsonProperty("open_issues")] public long OpenIssues { get; set; }

    [JsonProperty("watchers_count")] public long WatchersCount { get; set; }

    [JsonProperty("node_id")] public string NodeId { get; set; }

    [JsonProperty("forks_count")] public long ForksCount { get; set; }
}

public class Owner {
    [JsonProperty("gists_url")] public string GistsUrl { get; set; }

    [JsonProperty("repos_url")] public Uri ReposUrl { get; set; }

    [JsonProperty("following_url")] public string FollowingUrl { get; set; }

    [JsonProperty("starred_url")] public string StarredUrl { get; set; }

    [JsonProperty("login")] public string Login { get; set; }

    [JsonProperty("followers_url")] public Uri FollowersUrl { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("url")] public Uri Url { get; set; }

    [JsonProperty("subscriptions_url")] public Uri SubscriptionsUrl { get; set; }

    [JsonProperty("received_events_url")] public Uri ReceivedEventsUrl { get; set; }

    [JsonProperty("avatar_url")] public Uri AvatarUrl { get; set; }

    [JsonProperty("events_url")] public string EventsUrl { get; set; }

    [JsonProperty("html_url")] public Uri HtmlUrl { get; set; }

    [JsonProperty("site_admin")] public bool SiteAdmin { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("gravatar_id")] public string GravatarId { get; set; }

    [JsonProperty("node_id")] public string NodeId { get; set; }

    [JsonProperty("organizations_url")] public Uri OrganizationsUrl { get; set; }
}

public partial class Permissions {
    [JsonProperty("pull")] public bool Pull { get; set; }

    [JsonProperty("maintain")] public bool Maintain { get; set; }

    [JsonProperty("admin")] public bool Admin { get; set; }

    [JsonProperty("triage")] public bool Triage { get; set; }

    [JsonProperty("push")] public bool Push { get; set; }
}

public class Test {
    public static Test FromJson(string json) {
        return JsonConvert.DeserializeObject<Test>(json, Converter.Settings);
    }
}

public static class Serialize {
    public static string ToJson(this Test self) {
        return JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

internal static class Converter {
    public static readonly JsonSerializerSettings Settings = new() {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters = {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        }
    };
}