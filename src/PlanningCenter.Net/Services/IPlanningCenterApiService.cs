using Kast.Connectivity.PlanningCenter.Models;
using PlanningCenter.Net.Models.Groups.Group;
using PlanningCenter.Net.Models.Groups.Location;
using PlanningCenter.Net.Models.Groups.Membership;
using PlanningCenter.Net.Models.Groups.Tag;
using PlanningCenter.Net.Models.Groups.TagGroup;
using PlanningCenter.Net.Models.People.Campus;
using PlanningCenter.Net.Models.People.Lists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningCenter.Net.Services
{
    /// <summary>
    /// Service that responsible to call the Planning Center APIs.
    /// </summary>
    public interface IPlanningCenterApiService
    {
        /// <summary>
        /// Get a list of all groups.
        /// </summary>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="groupTypeIds">Get the groups with the given types. Get all groups by default.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<Group>> GetGroupsAsync(int offset, IEnumerable<string> groupTypeIds = null, int pageSize = 25);

        /// <summary>
        /// Get a list of all groups types.
        /// </summary>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<GroupType>> GetGroupTypesAsync(int offset, int pageSize = 25);

        /// <summary>
        /// Get the location of the group by the ID of the group.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <returns>The location of the group.</returns>
        Task<GroupLocation> GetGroupLocationAsync(string groupId);

        /// <summary>
        /// Get a list of all tag groups.
        /// </summary>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<TagGroup>> GetTagGroupsAsync(int offset, int pageSize = 25);

        /// <summary>
        /// Get a list of all tags of the group by the ID of the group.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<GroupTag>> GetGroupTagsAsync(string groupId, int offset, int pageSize = 25);

        /// <summary>
        /// Get a list of all tags of the tag group by the ID of the tag group.
        /// </summary>
        /// <param name="tagGroupId">The ID of the tag group.</param>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<GroupTag>> GetTagsByTagGroupsAsync(string tagGroupId, int offset, int pageSize = 25);

        /// <summary>
        /// Get a list of all the group member by the name of the role and the ID of the group.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="roleName">The name of the role.</param>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<GroupMember>> GetGroupMembersByRoleAsync(string groupId, string roleName, int offset, int pageSize = 25);

        /// <summary>
        /// Get a list of all campuses.
        /// </summary>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<Campus>> GetCampusesAsync(int offset, int pageSize = 25);

        /// <summary>
        /// Get a list of all Lists.
        /// </summary>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<List>> GetListsAsync(int offset, int pageSize = 25);

        /// <summary>
        /// Get the people in a list.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        /// <param name="offset">Get results from given offset.</param>
        /// <param name="pageSize">How many records to return per page (min=1, max=100, default=25).</param>
        Task<IEnumerable<PlanningCenter.Net.Models.People.Person>> GetListPeopleAsync(string listId, int offset, int pageSize = 25);

        /// <summary>
        /// Get all people in a list.
        /// </summary>
        //// <param name="listId">The ID of the list.</param>
        Task<IEnumerable<Models.People.Person>> GetAllPeopleFromListAsync(string listId);
    }
}
