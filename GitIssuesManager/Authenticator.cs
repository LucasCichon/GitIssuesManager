using Git;
using Git.Common;

namespace GitIssuesManager
{
    public static class Authenticator
    {
        public static Identity GetCurrentIdentity(GitService.GitServiceType service)
        {
            var token = GetCurrentToken(service);
            var user = Properties.Settings.Default.User;
            return new Identity(token, user);
        }

        private static string GetCurrentToken(GitService.GitServiceType service) => service switch
        {
            GitService.GitServiceType.GitHub => Properties.Settings.Default.GitHubUserToken,
            GitService.GitServiceType.GitLab => Properties.Settings.Default.GitLabUserToken,
            GitService.GitServiceType.Bitbucket => Properties.Settings.Default.BitbucketUserToken,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
