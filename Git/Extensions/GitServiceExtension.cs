using Git.Common;

namespace Git.Extensions
{
    public static class GitServiceExtension
    {
        public static GitService.GitServiceType GetService(this string service) =>
            service switch
            {
                ServiceConstants.GitHubName => GitService.GitServiceType.GitHub,
                ServiceConstants.GitLabName => GitService.GitServiceType.GitLab,
                ServiceConstants.BitbucketName => GitService.GitServiceType.Bitbucket,
                _ => throw new ArgumentOutOfRangeException(nameof(service), $"Not expected GitServiceName value: {service}")
            };

        public static string GetServiceName(this GitService.GitServiceType service) =>
            service switch
            {
                GitService.GitServiceType.GitHub => ServiceConstants.GitHubName,
                GitService.GitServiceType.GitLab => ServiceConstants.GitLabName,
                GitService.GitServiceType.Bitbucket => ServiceConstants.BitbucketName,
                _ => throw new ArgumentOutOfRangeException(nameof(service), $"Not expected GitService value: {service}")
            };
    }
}
