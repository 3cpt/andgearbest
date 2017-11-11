using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AndGearbest
{
    public class RequestBase
    {
        private const string apiEndpoint = "https://affiliate.gearbest.com/api/";
        private readonly HttpClient httpClient;

        public string ApiKey { get; set; }

        public string SecretKey { get; set; }

        protected RequestBase(string apiKey, string secretKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey));
            if (string.IsNullOrWhiteSpace(secretKey))
                throw new ArgumentNullException(nameof(secretKey));

            this.ApiKey = apiKey;
            this.SecretKey = secretKey;

            httpClient = new HttpClient();
        }

        protected async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request)
        {
            var response = await httpClient.PostAsync(request.RequestUri, request.Content);
            if (!response.IsSuccessStatusCode)
            {
                HandleRequestFailure(response.StatusCode);
            }
            return response;
        }

        protected void HandleRequestFailure(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.ServiceUnavailable:
                    throw new HttpRequestException("503, Service unavailable");
                case HttpStatusCode.InternalServerError:
                    throw new HttpRequestException("500, Internal server error");
                case HttpStatusCode.Unauthorized:
                    throw new HttpRequestException("401, Unauthorized");
                case HttpStatusCode.BadRequest:
                    throw new HttpRequestException("400, Bad request");
                case HttpStatusCode.NotFound:
                    throw new HttpRequestException("404, Resource not found");
                case HttpStatusCode.Forbidden:
                    throw new HttpRequestException("403, Forbidden");
                case (HttpStatusCode)429:
                    throw new HttpRequestException("429, Rate Limit Exceeded");
                default:
                    throw new HttpRequestException("Unexpeced failure");
            }
        }
    }
}