using Git.Clients.HttpClients;
using Git.Interfaces;
using Git.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> CreateNewIssue(NewIssue issue, string repositoryName)
        {
            var result = await _httpClient.PostAsync(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/LucasCichon/{repositoryName}/issues"), issue);
            return result == System.Net.HttpStatusCode.Created;
        }


        
        public Task CloseIssue(long id)
        {
            throw new NotImplementedException();
        }


        public async Task<GitIssues> GetIssues(string repositoryName)
        {
            var result = await _httpClient.GetAsync<Issue[]>(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/{_identity.User}/{repositoryName}/issues"));
            return new GitIssues() { items = result };
        }


        public async Task<bool> ModifyIssue(EditIssue issue, string repositoryName)
        {
            var result = await _httpClient.PatchAsync(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/{_identity.User}/{repositoryName}/issues/{issue.number}"), issue);
            return result == System.Net.HttpStatusCode.OK;
        }

        public async Task<Repositories> GetRepositories()
        {
            var result = await _httpClient.GetAsync<Repository[]>(new Uri(ServiceConstants.GitHubApiBaseAddress + "user/repos"));
            return new Repositories() { items = result };
        }
    }
}
