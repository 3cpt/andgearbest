namespace AndGearbest.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CompletedOrder
    {
        [JsonProperty("order_number")]
        public string OrderNumber { get; set; }

        [JsonProperty("new_customers")]
        public string NewCustomer { get; set; }

        [JsonProperty("transaction_time")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("order_time")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("order_amount")]
        public decimal Value { get; set; }

        [JsonProperty("all_commission")]
        public decimal Commission { get; set; }

        [JsonProperty("order_status")]
        public string Status { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("postback_id")]
        public string PostbackId { get; set; }

        [JsonProperty("products")]
        public IEnumerable<ProductRate> ProductRates { get; set; }
    }
}