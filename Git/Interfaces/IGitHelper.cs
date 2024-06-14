using Git.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Git.Interfaces
{
    public interface IGitHelper
    {
        int GetNumberOfMaxConcurrentRequests(RequestMethod method);
        int GetNumberOfSeparateActions(RequestMethod method, int totalRequestsCount);
    }
}
