using Git.Interfaces;
using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Git.Clients
{
    public class GitHubCLient : IGitClient
    {
        private const string mediaType = "application/vnd.github+json";
        private readonly Identity _identity;

        public GitHubCLient(Identity identity)
        {
            _identity = identity;
        }

        public Task CreateNewIssue(NewIssue issue)
        {
            throw new NotImplementedException();
        }
        public Task CloseIssue(long id)
        {
            throw new NotImplementedException();
        }


        public async Task<GitIssues> GetIssues(string repositoryName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Set up HttpClient
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _identity.BearerToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

                    HttpResponseMessage response = await client.GetAsync(ServiceConstants.GitHubApiBaseAddress + $"repos/LucasCichon/{repositoryName}/" + "issues");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var issues = Newtonsoft.Json.JsonConvert.DeserializeObject <Issue[]>(responseBody);
                    return new GitIssues() { items = issues };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Task ModifyIssue(Issue issue)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAuthenticated()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _identity.BearerToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

                    var user = await GetGitHubUserAsync(client);
                    return user != null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<GitHubUser> GetGitHubUserAsync(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(ServiceConstants.GitHubApiBaseAddress + "user");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<GitHubUser>(responseBody);
            return user;
        }

        public async Task<Repositories> GetRepositories()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Set up HttpClient
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _identity.BearerToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

                    HttpResponseMessage response = await client.GetAsync(ServiceConstants.GitHubApiBaseAddress + "user/repos");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var issues = Newtonsoft.Json.JsonConvert.DeserializeObject<Repository[]>(responseBody);
                    return new Repositories() { items = issues };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
