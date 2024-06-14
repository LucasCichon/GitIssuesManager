namespace Git.Common
{
    public static class GitService
    {
        public enum GitServiceType
        {
            GitHub,
            Bitbucket,
            GitLab
        }
        public static List<string> GetAllGitServiceNames() => Enum.GetValues(typeof(GitServiceType)).Cast<GitServiceType>().Select(t => t.ToString()).ToList();

        public static List<GitServiceType> GetAllGitServices() => Enum.GetValues(typeof(GitServiceType)).Cast<GitServiceType>().ToList();
    }


}
