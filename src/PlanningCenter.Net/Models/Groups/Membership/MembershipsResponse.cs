using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.Groups.Membership
{
    public class MembershipsResponse : ResponseBase<MembershipsResponseData, MembershipsResponseMeta> { }

    public class MembershipsResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public MembershipAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public MembershipRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class MembershipAttributes
    {
        [JsonProperty("account_center_identifier")]
        public int AccountCenterIdentifier { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("color_identifier")]
        public int ColorIdentifier { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class GroupMembership
    {
        [JsonProperty("data")]
        public GroupData Data { get; set; }
    }

    public class Person
    {
        [JsonProperty("data")]
        public PersonData Data { get; set; }
    }

    public class GroupData : DataResponseBase { }

    public class PersonData : DataResponseBase { }

    public class MembershipRelationships
    {
        [JsonProperty("group")]
        public GroupMembership Group { get; set; }

        [JsonProperty("person")]
        public Person Person { get; set; }
    }

    public class MembershipsResponseMeta : MetaResponseBase
    {
        [JsonProperty("can_order_by")]
        public List<string> CanOrderBy { get; set; }

        [JsonProperty("can_query_by")]
        public List<string> CanQueryBy { get; set; }
    }
}
