namespace AndGearbest.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public class RequestBase
    {
        private const string apiEndpoint = "affiliate.gearbest.com/api";
        private readonly HttpClient httpClient;

        public string ApiKey { get; }

        public string SecretKey { get; }

        public string Lkid { get; } = "19955328";

        internal RequestBase(string apiKey, string secretKey, string lkid)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            if (string.IsNullOrWhiteSpace(secretKey))
            {
                throw new ArgumentNullException(nameof(secretKey));
            }

            this.ApiKey = apiKey;
            this.SecretKey = secretKey;
            if (lkid != null)
            {
                this.Lkid = lkid;
            }

            httpClient = new HttpClient();
        }

        internal HttpRequestMessage PrepareRequest(string resource, HttpMethod httpMethod, Dictionary<string, string> arguments)
        {
            var scheme = "https";
            var url = $"{scheme}://{apiEndpoint}{resource}?api_key={ApiKey}{BuildArgumentsString(arguments)}";

            return new HttpRequestMessage(httpMethod, url);
        }

        protected string BuildArgumentsString(Dictionary<string, string> arguments)
        {
            arguments.Add("lkid", this.Lkid);

            var concatSecret = ConcatUrlQueryParamsWithSecret(arguments);

            arguments.Add("sign", CreateMD5Key(concatSecret));

            var res = arguments
                .Where(arg => arg.Key != string.Empty)
                .Aggregate(string.Empty, (current, arg) => current + ("&" + arg.Key + "=" + arg.Value));

            return res;
        }

        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            Task<string> result = null;
            using (response)
            {
                using (var content = response.Content)
                {
                    result = content.ReadAsStringAsync();
                }
            }
            return await result;
        }

        internal async Task<string> GetAsync(HttpRequestMessage request)
        {
            var response = await httpClient.GetAsync(request.RequestUri);
            if (!response.IsSuccessStatusCode)
            {
                HandleRequestFailure(response.StatusCode);
            }
            return await GetResponseContentAsync(response);
        }

        internal async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request)
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
                default:
                    throw new HttpRequestException("Unexpeced failure");
            }
        }

        private string ConcatUrlQueryParamsWithSecret(Dictionary<string, string> queryParams)
        {
            var result = $"{this.SecretKey}api_key{this.ApiKey}";

            var listOfSortedKeys = queryParams.Keys.ToList();

            listOfSortedKeys.Sort();

            foreach (var key in listOfSortedKeys)
            {
                result = result + key;
                result = result + queryParams[key];
            }

            return result + this.SecretKey;
        }

        private static string CreateMD5Key(string input)
        {
            var result = string.Empty;

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                result = BitConverter.ToString(hashBytes);
            }

            return result.Replace("-", "").ToUpper();
        }
    }
}