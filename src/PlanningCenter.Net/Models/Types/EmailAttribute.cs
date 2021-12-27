using Newtonsoft.Json;

namespace PlanningCenter.Net.Models.Types
{
    public class EmailAttribute
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}