using Git.Common;

namespace Git.Interfaces
{
    public interface IGitHelper
    {
        int GetNumberOfMaxConcurrentRequests(RequestMethod method);
        int GetNumberOfSeparateActions(RequestMethod method, int totalRequestsCount);
    }
}
