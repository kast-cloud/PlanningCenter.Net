using System;

namespace PlanningCenter.Net.Models.Groups.Group
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string GroupTypeId { get; set; }
        public string LocationId { get; set; }
        public string MeetingSchedule { get; set; }
        public LocationTypePreference LocationTypePreference { get; set; }
        public string VirtualLocationUrl { get; set; }
        public bool Archived { get; set; }
    }

    public enum LocationTypePreference
    {
        Physical,
        Virtual,
    }
}
