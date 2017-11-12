namespace AndGearbest.Models
{
    using Newtonsoft.Json;

    public class ProductRate
    {
        [JsonProperty("product_title")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("commission_rate")]
        public string Rate { get; set; }
    }
}