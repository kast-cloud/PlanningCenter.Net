using PlanningCenter.Net.Models.Groups.Group;
using PlanningCenter.Net.Models.Groups.GroupType;
using PlanningCenter.Net.Models.Groups.Location;
using PlanningCenter.Net.Models.Groups.Membership;
using PlanningCenter.Net.Models.Groups.Tag;
using PlanningCenter.Net.Models.Groups.TagGroup;
using PlanningCenter.Net.Models.People.Campus;
using PlanningCenter.Net.Models.People.Lists;
using RestEase;
using System.Threading.Tasks;

namespace PlanningCenter.Net.Services
{
    public interface IPlanningCenterApiClient
    {
        [AllowAnyStatusCode]
        [Get("/groups/v2/group_types?offset={offset}&per_page={perPage}")]
        Task<GroupTypesResponse> GetGroupTypesAsync([Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/groups/v2/groups?offset={offset}&per_page={perPage}")]
        Task<GroupsResponse> GetActiveGroupsAsync([Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/groups/v2/groups?offset={offset}&per_page={perPage}&where[archive_status]=only")]
        Task<GroupsResponse> GetArchivedGroupsAsync([Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/groups/v2/groups?offset={offset}&per_page={perPage}&where[archive_status]=include")]
        Task<GroupsResponse> GetGroupsAsync([Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/groups/v2/groups/{groupId}/location")]
        Task<GroupLocationResponse> GetGroupLocationAsync([Path("groupId")] string groupId);

        [AllowAnyStatusCode]
        [Get("/groups/v2/tag_groups?offset={offset}&per_page={perPage}")]
        Task<TagGroupsResponse> GetTagGroupsAsync([Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/groups/v2/groups/{groupId}/tags?offset={offset}&per_page={perPage}")]
        Task<TagsResponse> GetGroupTagsAsync([Path("groupId")] string groupId, [Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [Get("/groups/v2/tag_groups/{tagGroupId}/tags?offset={offset}&per_page={perPage}")]
        Task<TagsResponse> GetTagsByTagGroupsAsync([Path("tagGroupId")] string tagGroupId, [Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/people/v2/campuses?offset={offset}&per_page={perPage}")]
        Task<CampusesResponse> GetCampusesAsync([Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/groups/v2/groups/{groupId}/memberships?where[role]={role}&offset={offset}&per_page={perPage}")]
        Task<MembershipsResponse> GetGroupMembersByRoleAsync([Path("groupId")] string groupId, [Path("role")] string role, [Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/people/v2/lists?offset={offset}&per_page={perPage}")]
        Task<ListsResponse> GetListsAsync([Path("offset")] int offset, [Path("perPage")] int perPage = 25);

        [AllowAnyStatusCode]
        [Get("/people/v2/lists/{listId}/people?include=emails,phone_numbers&offset={offset}&per_page={perPage}")]
        Task<ListPeopleResponse> GetListPeopleAsync([Path("listId")] string listId, [Path("offset")] int offset, [Path("perPage")] int perPage = 25);
    }
}
