using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.Groups.Tag
{
    public class TagsResponse : ResponseBase<TagResponseData, TagsResponseMeta> { }

    public class TagAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }

    public class TagGroupResponseData : DataResponseBase { }

    public class TagGroupResponse
    {
        [JsonProperty("data")]
        public TagGroupResponseData Data { get; set; }
    }

    public class Relationships
    {
        [JsonProperty("tag_group")]
        public TagGroupResponse TagGroup { get; set; }
    }

    public class TagResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public TagAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class TagsResponseMeta : MetaResponseBase
    {
        [JsonProperty("can_order_by")]
        public List<string> CanOrderBy { get; set; }

        [JsonProperty("can_query_by")]
        public List<string> CanQueryBy { get; set; }
    }
}
