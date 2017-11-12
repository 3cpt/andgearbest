namespace AndGearbest.Models
{
    using Newtonsoft.Json;

    public class ProductCreative
    {
        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }

        [JsonProperty("promotion_url")]
        public string PromotionUrl { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("sale_price")]
        public decimal Price { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}