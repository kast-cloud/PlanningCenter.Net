namespace PlanningCenter.Net.Models.Groups.Membership
{
    public class GroupMember
    {
        public string GroupId { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class RoleNames
    {
        public const string Leader = "leader";
        public const string Member = "member";
    }
}
