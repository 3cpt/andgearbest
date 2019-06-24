namespace AndGearbest.Models
{
    using System;
    using Newtonsoft.Json;

    public class Coupon
    {
        [JsonProperty("coupon_name")]
        public string CouponName { get; set; }

        [JsonProperty("coupon_type")]
        public string CouponType { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndTime { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("coupon_url")]
        public string CouponUrl { get; set; }

        [JsonProperty("promotion_url")]
        public string PromotionUrl { get; set; }

        [JsonProperty("sale_price")]
        public decimal SalePrice { get; set; }

        [JsonProperty("discounted_price")]
        public decimal DiscountedPrice { get; set; }

        [JsonProperty("discount_percent")]
        public decimal? DiscountPercent { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("limited_times")]
        public int LimitedTimes { get; set; }
    }
}