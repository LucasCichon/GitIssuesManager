using Git.Interfaces;
using Git.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;

namespace Git
{
    public class GitHubAuthenticator : IAuthenticator
    {
        private static readonly HttpClient client = new HttpClient();
        
        private const string mediaType = "application/vnd.github+json";
        public async Task Authenticate()
        {
            // Replace with your GitHub personal access token
            string personalAccessToken = "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";

            // Set up HttpClient
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", personalAccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

            try
            {
                // Make a request to the GitHub API
                var user = await GetGitHubUserAsync();
                var issues = await GetGitHubIssuesAsync();
                //var newIssue = await CreateNewIsue();
                //Console.WriteLine($"Authenticated as: {user.login}");
                //Console.WriteLine($"Name: {user.name}");
                //Console.WriteLine($"Public Repos: {user.public_repos}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task<GitHubUser> GetGitHubUserAsync()
        {
            HttpResponseMessage response = await client.GetAsync(ServiceConstants.GitHubApiBaseAddress + "user");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<GitHubUser>(responseBody);
            return user;
        }

        static async Task<GitIssues> GetGitHubIssuesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(ServiceConstants.GitHubApiBaseAddress + "repos/LucasCichon/" + "ImportConsoleApp/" + "issues");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var issues = Newtonsoft.Json.JsonConvert.DeserializeObject<Issue[]>(responseBody);
                return new GitIssues() { items = issues };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }

}

