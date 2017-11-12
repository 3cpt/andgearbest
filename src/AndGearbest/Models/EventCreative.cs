namespace AndGearbest.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EventCreative
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("event_url")]
        public string EventUrl { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("images")]
        public IEnumerable<Banner> Banners { get; set; }
    }
}