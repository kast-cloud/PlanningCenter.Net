namespace PlanningCenter.Net.Models.Groups
{
    public abstract class GroupTypeBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
