using Newtonsoft.Json;

namespace PlanningCenter.Net.Models
{
    public abstract class DataResponseBase
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
