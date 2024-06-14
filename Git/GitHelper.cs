using Git.Extensions;
using Git.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
