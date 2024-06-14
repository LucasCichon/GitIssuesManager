using Git.Clients;
using Git.Common;
using Git.Helpers;
using Git.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git
{
    internal static class GitHelperFactory
    {
        public static IGitHelper CreateHelper(GitService.GitServiceType service) => service switch
        {
            GitService.GitServiceType.GitHub => new GitHubHelper(),
            GitService.GitServiceType.Bitbucket => throw new NotImplementedException(),
            GitService.GitServiceType.GitLab => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }
}
