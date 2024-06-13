using Git.Error;
using Git.Interfaces;
using Git.Models;
using System.Net;

namespace Git.Clients
{
    public class BitbucketClient : IGitClient
    {
        private readonly Identity _identity;

        public BitbucketClient()
        {
        }

        public BitbucketClient(Identity identity)
        {
            _identity = identity;
        }
        public Task CloseIssue(long id)
        {
            throw new NotImplementedException();
        }

        public Task CreateNewIssue(NewIssue issue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateNewIssue(NewIssue issue, string repositoryName)
        {
            throw new NotImplementedException();
        }

        public Task<GitIssues> GetIssues(string repositoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Repositories> GetRepositories()
        {
            throw new NotImplementedException();
        }

        public Task ModifyIssue(Issue issue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyIssue(EditIssue issue, string repositoryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyIssue(EditIssue issue, string repositoryName, string issueId)
        {
            throw new NotImplementedException();
        }

        Task<Either<IError, HttpStatusCode>> IGitClient.CreateNewIssue(NewIssue issue, string repositoryName)
        {
            throw new NotImplementedException();
        }

        Task<Either<IError, GitIssues>> IGitClient.GetIssues(string repositoryName)
        {
            throw new NotImplementedException();
        }

        Task<Either<IError, Repositories>> IGitClient.GetRepositories()
        {
            throw new NotImplementedException();
        }

        Task<Either<IError, HttpStatusCode>> IGitClient.ModifyIssue(EditIssue issue, string repositoryName)
        {
            throw new NotImplementedException();
        }
    }
}
