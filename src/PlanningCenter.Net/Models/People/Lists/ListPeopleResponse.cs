using Newtonsoft.Json;

namespace PlanningCenter.Net.Models.People.Lists
{
    public class ListPeopleResponse : ResponseBase<ListPeopleResponseData, ListsResponseMeta> {}
    

    public class ListPeopleResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public PersonAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public PersonRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }
}