using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models
{
    public abstract class RelationshipsResponseBase<TData>
    {
        [JsonProperty("links")]
        public SelfLink Links { get; set; }

        [JsonProperty("data")]
        public List<TData> Data { get; set; }
    }
    public class Relationship : RelationshipsResponseBase<RelationshipData> { }

    public class RelationshipData : DataResponseBase {}
}
