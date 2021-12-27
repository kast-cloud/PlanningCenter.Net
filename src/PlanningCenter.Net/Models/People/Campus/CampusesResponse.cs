using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.People.Campus
{
    public class CampusesResponse : ResponseBase<CampusesResponseData, CampusesResponseMeta> { }

    public class CampusAttributes
    {
        [JsonProperty("avatar_url")]
        public object AvatarUrl { get; set; }

        [JsonProperty("church_center_enabled")]
        public bool ChurchCenterEnabled { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("contact_email_address")]
        public object ContactEmailAddress { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("date_format")]
        public object DateFormat { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("geolocation_set_manually")]
        public bool GeolocationSetManually { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone_number")]
        public object PhoneNumber { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("twenty_four_hour_time")]
        public object TwentyFourHourTime { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("website")]
        public object Website { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }
    }

    public class OrganizationData : DataResponseBase { }

    public class Organization
    {
        [JsonProperty("data")]
        public OrganizationData Data { get; set; }
    }

    public class CampusRelationships
    {
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
    }

    public class CampusesResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public CampusAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public CampusRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class CampusesResponseMeta : MetaResponseBase
    {
        [JsonProperty("can_order_by")]
        public List<string> CanOrderBy { get; set; }

        [JsonProperty("can_query_by")]
        public List<string> CanQueryBy { get; set; }

        [JsonProperty("can_include")]
        public List<string> CanInclude { get; set; }
    }
}
