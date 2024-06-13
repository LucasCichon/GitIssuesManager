using Git.Clients.HttpClients;
using Git.Common;
using Git.Error;
using Git.Interfaces;
using Git.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Git.Clients
{
    public class GitHubCLient : IGitClient
    {
        private readonly Identity _identity;
        private readonly GitHubHttpClient _httpClient;

        public GitHubCLient(Identity identity)
        {
            _identity = identity;
            _httpClient = new GitHubHttpClient(_identity);
        }

        public async Task<Either<IError, HttpStatusCode>> CreateNewIssue(NewIssue issue, string repositoryName)
        {
            return await _httpClient.PostAsync(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/LucasCichon/{repositoryName}/issues"), issue);
        }

        public Task CloseIssue(long id)
        {
            throw new NotImplementedException();
        }


        public async Task<Either<IError, GitIssues>> GetIssues(string repositoryName)
        {
            var result = await _httpClient.GetAsync<Issue[]>(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/{_identity.User}/{repositoryName}/issues"));
            return result.IsRight 
                ? Either<IError, GitIssues>.CreateRight(new GitIssues() { items = result.Right }) 
                : Either<IError, GitIssues>.CreateLeft(result.Left);
        }


        public async Task<Either<IError, HttpStatusCode>> ModifyIssue(EditIssue issue, string repositoryName)
        {
            return await _httpClient.PatchAsync(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/{_identity.User}/{repositoryName}/issues/{issue.number}"), issue);
        }

        public async Task<Either<IError, Repositories>> GetRepositories()
        {
            var result = await _httpClient.GetAsync<Repository[]>(new Uri(ServiceConstants.GitHubApiBaseAddress + "user/repos"));
            return result.IsRight 
                ? Either<IError, Repositories>.CreateRight(new Repositories() { items = result.Right }) 
                : Either<IError, Repositories>.CreateLeft(result.Left);
        }
    }
}
