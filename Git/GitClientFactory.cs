using Git.Clients;
using Git.Common;
using Git.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git
{
    internal static class GitClientFactory
    {
        public static IGitClient CreateClient(GitServiceType service, Identity identity) => service switch
        {
            GitServiceType.GitHub => new GitHubCLient(identity),
            GitServiceType.Bitbucket => new BitbucketClient(identity),
            GitServiceType.GitLab => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }
}
