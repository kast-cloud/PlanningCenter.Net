using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.Groups.Group
{
    public class GroupsResponse : ResponseBase<GroupsResponseData, GroupsResponseMeta> { }

    public class GroupsResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public GroupAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public GroupRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class GroupAttributes
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("archived_at")]
        public object ArchivedAt { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("enrollment_open")]
        public bool EnrollmentOpen { get; set; }

        [JsonProperty("enrollment_strategy")]
        public string EnrollmentStrategy { get; set; }

        [JsonProperty("header_image")]
        public HeaderImage HeaderImage { get; set; }

        [JsonProperty("location_type_preference")]
        public string LocationTypePreference { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        [JsonProperty("virtual_location_url")]
        public string VirtualLocationUrl { get; set; }
    }

    public class GroupTypeResponse
    {
        [JsonProperty("data")]
        public GroupTypeResponseData Data { get; set; }

        [JsonProperty("links")]
        public RelatedLink Links { get; set; }
    }

    public class GroupTypeResponseData : DataResponseBase { }

    public class Location
    {
        [JsonProperty("data")]
        public LocationResponse Data { get; set; }
    }

    public class LocationResponse : DataResponseBase { }

    public class GroupRelationships
    {
        [JsonProperty("group_type")]
        public GroupTypeResponse GroupType { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Included : DataResponseBase
    {
        [JsonProperty("attributes")]
        public GroupAttributes Attributes { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class GroupsResponseMeta : MetaResponseBase
    {
        [JsonProperty("can_query_by")]
        public List<string> CanQueryBy { get; set; }

        [JsonProperty("can_include")]
        public List<string> CanInclude { get; set; }
    }

    public class HeaderImage
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }
    }
}
