using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlanningCenter.Net.Models.People
{

    public class PersonResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public PersonAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public PersonRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class PersonAttributes
    {

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class PersonRelationships
    {
        [JsonProperty("emails")]
        public Relationship Emails { get; set; }

        [JsonProperty("phone_numbers")]
        public Relationship PhoneNumbers { get; set; }
    }
}