using Git.Interfaces;
using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Clients
{
    public class BitbucketClient : IGitClient
    {
        private readonly Identity _identity;

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

        Task<bool> IGitClient.IsAuthenticated()
        {
            throw new NotImplementedException();
        }
    }
}
