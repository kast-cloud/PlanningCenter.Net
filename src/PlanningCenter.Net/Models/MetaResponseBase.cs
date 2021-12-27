using Newtonsoft.Json;

namespace PlanningCenter.Net.Models
{
    public abstract class MetaResponseBase
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }
    }
}
