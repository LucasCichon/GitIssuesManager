using Git.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Git.Clients.HttpClients
{
    public class GitHubHttpClient
    {
        private readonly Identity _identity;
        private const string mediaType = "application/vnd.github+json";


        public GitHubHttpClient(Identity identity)
        {
            _identity = identity;
        }
        public async Task<T> GetAsync<T>(Uri uri)
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

                    HttpResponseMessage response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseBody);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpStatusCode> PostAsync(Uri uri, object data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _identity.BearerToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, mediaType);

                    HttpResponseMessage response = await client.PostAsync(uri, content);
                    return response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpStatusCode> PatchAsync(Uri uri, object data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _identity.BearerToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, mediaType);

                    HttpResponseMessage response = await client.PatchAsync(uri, content);
                    return response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
