namespace AndGearbest.Models
{
    using Newtonsoft.Json;

    public class ResponseData<TType>
    {
        [JsonProperty("error_no")]
        public int ErrorNo { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        [JsonProperty("data")]
        public ResponseDetail<TType> Data { get; set; }
    }
}