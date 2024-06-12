using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Extensions
{
    public static class GitServiceExtension
    {
        public static GitServiceType GetService(this string service) =>
            service switch
            {
                ServiceConstants.GitHubName => GitServiceType.GitHub,
                ServiceConstants.GitLabName => GitServiceType.GitLab,
                ServiceConstants.BitbucketName => GitServiceType.Bitbucket,
                _ => throw new ArgumentOutOfRangeException(nameof(service), $"Not expected GitServiceName value: {service}")
            };

        public static string GetServiceName(this GitServiceType service) =>
            service switch
            {
                GitServiceType.GitHub => ServiceConstants.GitHubName,
                GitServiceType.GitLab => ServiceConstants.GitLabName,
                GitServiceType.Bitbucket => ServiceConstants.BitbucketName,
                _ => throw new ArgumentOutOfRangeException(nameof(service), $"Not expected GitService value: {service}")
            };
    }
}
