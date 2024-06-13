using Git;
using Git.Common;

namespace GitIssuesManager
{
    public static class Authenticator
    {
        public static Identity GetCurrentIdentity(GitServiceType service)
        {
            var token = GetCurrentToken(service);
            var user = Properties.Settings.Default.User;
            return new Identity(token, user);
        }

        private static string GetCurrentToken(GitServiceType service) => service switch
        {
            GitServiceType.GitHub => Properties.Settings.Default.GitHubUserToken,
            GitServiceType.GitLab => Properties.Settings.Default.GitLabUserToken,
            GitServiceType.Bitbucket => Properties.Settings.Default.BitbucketUserToken,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
