using Git.Extensions;
using Git.Interfaces;

namespace Git
{
    public static class GitHelper
    {
        public static IGitHelper CreateHelper(string serviceName)
        {
            return GitHelperFactory.CreateHelper(serviceName.GetService());
        }
    }
}
