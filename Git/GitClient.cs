using Git.Extensions;
using Git.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
