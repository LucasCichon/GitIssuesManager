﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git
{
    public enum GitServiceType
    {
        GitHub,
        Bitbucket,
        GitLab
    }

    public static class GitService
    {
        public static List<string> GetAllGitServiceNames() => Enum.GetValues(typeof(GitServiceType)).Cast<GitServiceType>().Select(t => t.ToString()).ToList();

        public static List<GitServiceType> GetAllGitServices() => Enum.GetValues(typeof(GitServiceType)).Cast<GitServiceType>().ToList();
    }

    
}
