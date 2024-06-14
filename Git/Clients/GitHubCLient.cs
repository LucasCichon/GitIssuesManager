using Git.Clients.HttpClients;
using Git.Common;
using Git.Error;
using Git.Interfaces;
using Git.Models;
using System.Net;

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
            return await _httpClient.PostAsync(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/{_identity.User}/{repositoryName}/issues"), issue);
        }

        public async Task<Either<IError, GitIssues>> GetIssues(string repositoryName)
        {
            int currentPage = 1;
            int pageSize = 100;
            var issues = new List<Issue>();
            var errorResult = Either<IError, GitIssues>.Success(new GitIssues());
            var shouldContinue = true;

            do
            {
                var currentResult = await _httpClient.GetAsync<Issue[]>(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/{_identity.User}/{repositoryName}/issues?per_page={pageSize}&page={currentPage}"));

                currentResult.Match(success => 
                {
                    shouldContinue = success.Length != 0;
                    issues.AddRange(success);
                },
                error => errorResult = Either<IError, GitIssues>.Error(error));

                currentPage++;

            } while (shouldContinue && issues.Count % pageSize == 0 && errorResult.IsRight);

            return errorResult.IsLeft ? errorResult : Either<IError, GitIssues>.Success(new GitIssues() { items = issues.ToArray() });
                
        }

        public async Task<Either<IError, HttpStatusCode>> ModifyIssue(EditIssue issue, string repositoryName)
        {
            return await _httpClient.PatchAsync(new Uri(ServiceConstants.GitHubApiBaseAddress + $"repos/{_identity.User}/{repositoryName}/issues/{issue.number}"), issue);
        }

        public async Task<Either<IError, Repositories>> GetRepositories()
        {
            var result = await _httpClient.GetAsync<Repository[]>(new Uri(ServiceConstants.GitHubApiBaseAddress + "user/repos"));
            return result.IsRight 
                ? Either<IError, Repositories>.Success(new Repositories() { items = result.Right }) 
                : Either<IError, Repositories>.Error(result.Left);
        }
    }
}
