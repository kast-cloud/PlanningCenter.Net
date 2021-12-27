using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models
{
    public abstract class ResponseBase<TData, TMeta>
    {
        [JsonProperty("links")]
        public SelfLink Links { get; set; }

        [JsonProperty("data")]
        public List<TData> Data { get; set; }

        [JsonProperty("included")]
        public List<Included> Included { get; set; }

        [JsonProperty("meta")]
        public TMeta Meta { get; set; }
    }
}
