using Git.Common;
using Git.Error;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

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
        public async Task<Either<IError, T>> GetAsync<T>(Uri uri)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (HttpClient client = CreateClient())
                {
                    response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(responseBody);

                    return response.StatusCode == HttpStatusCode.OK ? Either<IError, T>.Success(result) : Either<IError, T>.Error(new HttpError(response.StatusCode));
                }
            }
            catch (Exception ex)
            {
                return Either<IError, T>.Error(new HttpError(ex.Message, response.StatusCode));
            }
        }

        public async Task<Either<IError, HttpStatusCode>> PostAsync(Uri uri, object data)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                using (HttpClient client = CreateClient())
                {
                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, mediaType);

                    response = await client.PostAsync(uri, content);
                    var message = await response.Content.ReadAsStringAsync();

                    return response.IsSuccessStatusCode ? Either<IError, HttpStatusCode>.Success(response.StatusCode) : Either<IError, HttpStatusCode>.Error(new HttpError(message, response.StatusCode));
                }
            }
            catch (Exception ex)
            {
                return Either<IError, HttpStatusCode>.Error(new HttpError(ex.Message, response.StatusCode));
            }
        }

        public async Task<Either<IError, HttpStatusCode>> PatchAsync(Uri uri, object data)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (HttpClient client = CreateClient())
                {
                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, mediaType);

                     response = await client.PatchAsync(uri, content);
                    var message = await response.Content.ReadAsStringAsync();

                    return response.IsSuccessStatusCode ? Either<IError, HttpStatusCode>.Success(response.StatusCode) : Either<IError, HttpStatusCode>.Error(new HttpError(message, response.StatusCode));
                }
            }
            catch (Exception ex)
            {
                return Either<IError, HttpStatusCode>.Error(new HttpError(ex.Message, response.StatusCode));
            }
        }
        private HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetApp", "1.0"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _identity.BearerToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            return client;
        }
    }
}
