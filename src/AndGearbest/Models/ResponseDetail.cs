namespace AndGearbest.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ResponseDetail<TType>
    {
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("items")]
        public IEnumerable<TType> Items { get; set; }
    }
}