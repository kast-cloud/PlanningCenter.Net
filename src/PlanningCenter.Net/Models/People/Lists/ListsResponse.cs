using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.People.Lists
{
    public class ListsResponse : ResponseBase<ListsResponseData, ListsResponseMeta> { }

    public class ListAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name_or_description")]
        public string NameOrDescription { get; set; }

        [JsonProperty("total_people")]
        public int TotalPeople { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }


    public class ListsResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public ListAttributes Attributes { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class ListsResponseMeta : MetaResponseBase
    {
        [JsonProperty("can_order_by")]
        public List<string> CanOrderBy { get; set; }

        [JsonProperty("can_query_by")]
        public List<string> CanQueryBy { get; set; }

        [JsonProperty("can_include")]
        public List<string> CanInclude { get; set; }
    }

}