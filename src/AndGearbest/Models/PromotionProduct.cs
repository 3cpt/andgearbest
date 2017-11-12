namespace AndGearbest.Models
{
    using Newtonsoft.Json;

    public class PromotionProduct
    {
        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("thumbnail_image_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("orig_price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("sale_price")]
        public decimal SalePrice { get; set; }

        [JsonProperty("promotion_url")]
        public string PromotionUrl { get; set; }
    }
}