using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.Groups.Location
{
    public class GroupLocationResponse
    {
        [JsonProperty("data")]
        public GroupLocationResponseData Data { get; set; }

        [JsonProperty("included")]
        public List<object> Included { get; set; }

        [JsonProperty("meta")]
        public GroupLocationResponseMeta Meta { get; set; }
    }

    public class GroupLocationAttributes
    {
        [JsonProperty("display_preference")]
        public string DisplayPreference { get; set; }

        [JsonProperty("full_formatted_address")]
        public string FullFormattedAddress { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("radius")]
        public int Radius { get; set; }

        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }

    public class GroupLocationResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public GroupLocationAttributes Attributes { get; set; }

        [JsonProperty("links")]
        public GroupLocationLinks Links { get; set; }
    }

    public class GroupLocationLinks { }

    public class GroupLocationResponseMeta
    {
        [JsonProperty("parent")]
        public Parent Parent { get; set; }
    }
}
