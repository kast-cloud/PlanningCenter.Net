using Newtonsoft.Json;

namespace PlanningCenter.Net.Models.Types
{
    public class PhoneNumberAttribute
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}