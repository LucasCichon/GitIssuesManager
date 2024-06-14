using Git.Clients;
using Git.Common;
using Git.Interfaces;

namespace Git
{
    internal static class GitClientFactory
    {
        public static IGitClient CreateClient(GitService.GitServiceType service, Identity identity) => service switch
        {
            GitService.GitServiceType.GitHub => new GitHubCLient(identity),
            GitService.GitServiceType.Bitbucket => new BitbucketClient(identity),
            GitService.GitServiceType.GitLab => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }
}
