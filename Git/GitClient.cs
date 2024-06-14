using Git.Extensions;
using Git.Interfaces;

namespace Git
{
    public static class GitClient
    {
        public static IGitClient CreateClient(string serviceName, Identity identity)
        {
            return GitClientFactory.CreateClient(serviceName.GetService(), identity);
        }
    }
}
