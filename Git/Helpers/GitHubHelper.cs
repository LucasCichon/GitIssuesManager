using Git.Common;
using Git.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Helpers
{
    public class GitHubHelper : IGitHelper
    {
        public int GetNumberOfMaxConcurrentRequests(RequestMethod method)
        {
            switch (method)
            {
                case RequestMethod.GET:
                    return 100;
                case RequestMethod.POST:
                case RequestMethod.PATCH:
                case RequestMethod.DELETE:
                case RequestMethod.PUT:
                    return 20;
                default:
                    return 20;
            };
        }

        public int GetNumberOfSeparateActions(RequestMethod method, int totalRequestsCount)
        {
            switch (method)
            {
                case RequestMethod.GET:
                    return (int)Math.Ceiling(totalRequestsCount / (double)100);
                case RequestMethod.POST:
                case RequestMethod.PATCH:
                case RequestMethod.DELETE:
                case RequestMethod.PUT:
                    return (int)Math.Ceiling(totalRequestsCount / (double)20);
                default:
                    return (int)Math.Ceiling(totalRequestsCount / (double)20);
            };
        }
    }
}
