namespace AndGearbest.Models
{
    using Newtonsoft.Json;

    public class Banner
    {
        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}