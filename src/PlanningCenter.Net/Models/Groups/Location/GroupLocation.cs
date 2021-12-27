namespace PlanningCenter.Net.Models.Groups.Location
{
    public class GroupLocation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayPreference { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
