using Git.Common;
using Git.Error;
using Git.Interfaces;
using Git.Models;
using System.Net;

namespace Git.Clients
{
    public class BitbucketClient : IGitClient
    {
        private readonly Identity _identity;

        public BitbucketClient(Identity identity)
        {
            _identity = identity;
        }

        public Task<Either<IError, HttpStatusCode>> CreateNewIssue(NewIssue issue, string repositoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Either<IError, GitIssues>> GetIssues(string repositoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Either<IError, Repositories>> GetRepositories()
        {
            throw new NotImplementedException();
        }

        public Task<Either<IError, HttpStatusCode>> ModifyIssue(EditIssue issue, string repositoryName)
        {
            throw new NotImplementedException();
        }
    }
}
