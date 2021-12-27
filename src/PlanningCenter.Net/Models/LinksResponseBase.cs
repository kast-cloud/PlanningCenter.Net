using Newtonsoft.Json;

namespace PlanningCenter.Net.Models
{
    public class SelfLink
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class RelatedLink
    {
        [JsonProperty("related")]
        public string Related { get; set; }
    }

    public class Included : DataResponseBase
    {
        [JsonProperty("attributes")]
        public object Attributes { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }
}
