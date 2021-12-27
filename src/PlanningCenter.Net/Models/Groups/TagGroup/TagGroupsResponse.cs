using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.Groups.TagGroup
{
    public class TagGroupsResponse : ResponseBase<TagGroupsResponseData, TagGroupsResponseMeta> { }

    public class TagGroupAttributes
    {
        [JsonProperty("display_publicly")]
        public bool DisplayPublicly { get; set; }

        [JsonProperty("multiple_options_enabled")]
        public bool? MultipleOptionsEnabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }

    public class TagGroupsResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public TagGroupAttributes Attributes { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class TagGroupsResponseMeta : MetaResponseBase
    {
        [JsonProperty("can_order_by")]
        public List<string> CanOrderBy { get; set; }

        [JsonProperty("can_query_by")]
        public List<string> CanQueryBy { get; set; }

        [JsonProperty("can_filter")]
        public List<string> CanFilter { get; set; }
    }
}
