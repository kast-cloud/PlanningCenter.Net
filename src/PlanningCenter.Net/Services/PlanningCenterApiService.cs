using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kast.Connectivity.PlanningCenter.Models;

using Newtonsoft.Json.Linq;

using PlanningCenter.Net.Models.Groups.Group;
using PlanningCenter.Net.Models.Groups.Location;
using PlanningCenter.Net.Models.Groups.Membership;
using PlanningCenter.Net.Models.Groups.Tag;
using PlanningCenter.Net.Models.Groups.TagGroup;
using PlanningCenter.Net.Models.People;
using PlanningCenter.Net.Models.People.Campus;
using PlanningCenter.Net.Models.People.Lists;
using PlanningCenter.Net.Models.Types;

namespace PlanningCenter.Net.Services
{
    public class PlanningCenterApiService : IPlanningCenterApiService
    {
        private const string UniqueGroupTypeId = "unique";

        private readonly IPlanningCenterApiClient _planningCenterApiClient;


        public PlanningCenterApiService(IPlanningCenterApiClient planningCenterApiClient) =>
            _planningCenterApiClient = planningCenterApiClient;


        public async Task<IEnumerable<Group>> GetGroupsAsync(int offset, IEnumerable<string> groupTypeIds = null, int pageSize = 25)
        {
            groupTypeIds ??= Enumerable.Empty<string>();

            var groupsResponse = await _planningCenterApiClient.GetGroupsAsync(offset);

            var groups = !groupTypeIds.Any()
                ? groupsResponse.Data?.Select(group => CreateGroupFromGroupsResponse(group))
                : groupsResponse.Data?
                    .Where(group => groupTypeIds.Contains(group.Relationships.GroupType.Data?.Id))
                    .Select(group => CreateGroupFromGroupsResponse(group));

            // Groups without group type has the 'unique' text as the group ID
            // and the the data doesn't have any value in the group_type JSON.
            if (groupTypeIds.Contains(UniqueGroupTypeId))
            {
                groups = groups.Concat(groupsResponse.Data?.Where(group => group.Relationships.GroupType.Data == null)
                    .Select(group => CreateGroupFromGroupsResponse(group, true)));
            }

            return groups;
        }

        public async Task<IEnumerable<GroupType>> GetGroupTypesAsync(int offset, int pageSize = 25) =>
            (await _planningCenterApiClient.GetGroupTypesAsync(offset, pageSize)).Data?.Select(groupType =>
                new GroupType { Id = groupType.Id, Name = groupType.Attributes.Name });

        public async Task<GroupLocation> GetGroupLocationAsync(string groupId)
        {
            var groupLocation = await _planningCenterApiClient.GetGroupLocationAsync(groupId);

            return new GroupLocation
            {
                Id = groupLocation.Data.Id,
                Name = groupLocation.Data.Attributes.Name,
                DisplayPreference = groupLocation.Data.Attributes.DisplayPreference,
                Address = groupLocation.Data.Attributes.FullFormattedAddress,
                Latitude = groupLocation.Data.Attributes.Latitude,
                Longitude = groupLocation.Data.Attributes.Longitude,
            };
        }

        public async Task<IEnumerable<TagGroup>> GetTagGroupsAsync(int offset, int pageSize = 25) =>
            (await _planningCenterApiClient.GetTagGroupsAsync(offset, pageSize)).Data?.Select(tagGroup =>
                new TagGroup
                {
                    Id = tagGroup.Id,
                    Name = tagGroup.Attributes.Name,
                });

        public async Task<IEnumerable<GroupTag>> GetGroupTagsAsync(string groupId, int offset, int pageSize = 25) =>
            (await _planningCenterApiClient.GetGroupTagsAsync(groupId, offset, pageSize)).Data?.Select(groupTag =>
                new GroupTag
                {
                    Id = groupTag.Id,
                    TagGroupId = groupTag.Relationships.TagGroup.Data.Id,
                    Name = groupTag.Attributes.Name,
                });

        public async Task<IEnumerable<GroupTag>> GetTagsByTagGroupsAsync(string tagGroupId, int offset, int pageSize = 25) =>
            (await _planningCenterApiClient.GetTagsByTagGroupsAsync(tagGroupId, offset, pageSize)).Data?.Select(groupTag =>
                new GroupTag
                {
                    Id = groupTag.Id,
                    TagGroupId = groupTag.Relationships.TagGroup.Data.Id,
                    Name = groupTag.Attributes.Name,
                });

        public async Task<IEnumerable<GroupMember>> GetGroupMembersByRoleAsync(string groupId, string roleName, int offset, int pageSize = 25) =>
            roleName == RoleNames.Leader || roleName == RoleNames.Member ?
                (await _planningCenterApiClient.GetGroupMembersByRoleAsync(groupId, roleName, offset, pageSize)).Data?.Select(member =>
                    new GroupMember
                    {
                        GroupId = member.Relationships.Group.Data.Id,
                        RoleName = member.Attributes.Role,
                        Email = member.Attributes.EmailAddress,
                        FirstName = member.Attributes.FirstName,
                        LastName = member.Attributes.LastName,
                    }) :
                Enumerable.Empty<GroupMember>();

        public async Task<IEnumerable<Campus>> GetCampusesAsync(int offset, int pageSize = 25) =>
            (await _planningCenterApiClient.GetCampusesAsync(offset, pageSize)).Data?.Select(campus =>
                new Campus
                {
                    Id = campus.Id,
                    Name = campus.Attributes.Name,
                    City = campus.Attributes.City,
                    Country = campus.Attributes.Country,
                    Latitude = double.Parse(campus.Attributes.Latitude),
                    Longitude = double.Parse(campus.Attributes.Longitude),
                    Postcode = campus.Attributes.Zip,
                    State = campus.Attributes.State,
                    Street = campus.Attributes.Street,
                    DateAdded = campus.Attributes.CreatedAt,
                    DateModified = campus.Attributes.UpdatedAt,
                });


        private Group CreateGroupFromGroupsResponse(GroupsResponseData group, bool uniqueGroup = false)
        {
            var groupTypeId = UniqueGroupTypeId;

            if (!uniqueGroup)
            {
                groupTypeId = group.Relationships.GroupType.Data == null
                    ? UniqueGroupTypeId : group.Relationships.GroupType.Data.Id;
            }

            return new Group
            {
                Id = group.Id,
                Name = group.Attributes.Name,
                CreatedAt = group.Attributes.CreatedAt,
                Archived = group.Attributes.Archived,
                Description = group.Attributes.Description,
                MeetingSchedule = group.Attributes.Schedule,
                LocationId = group.Relationships.Location.Data?.Id,
                GroupTypeId = groupTypeId,
                LocationTypePreference = group.Attributes.LocationTypePreference == "physical"
                    ? LocationTypePreference.Physical : LocationTypePreference.Virtual,
            };
        }

        public async Task<IEnumerable<List>> GetListsAsync(int offset, int pageSize = 25) =>
            (await _planningCenterApiClient.GetListsAsync(offset, pageSize)).Data?.Select(list =>
            new List
            {
                Id = list.Id,
                Name = list.Attributes.NameOrDescription,
                CreatedUtc = list.Attributes.CreatedAt,
                ModifiedUtc = list.Attributes.UpdatedAt,
                TotalPeople = list.Attributes.TotalPeople
            });

        public async Task<IEnumerable<PlanningCenter.Net.Models.People.Person>> GetListPeopleAsync(string listId, int offset, int pageSize = 25)
        {
            var response = await _planningCenterApiClient.GetListPeopleAsync(listId, offset, pageSize);

            if (response == null)
            {
                return null;
            }

            return (response.Data.Select(person =>
                new PlanningCenter.Net.Models.People.Person
                {
                    Id = person.Id,
                    FirstName = person.Attributes.FirstName,
                    LastName = person.Attributes.LastName,
                    Mobile = GetPrimaryPhone(response.Included, person.Relationships),
                    Email = GetPrimaryEmail(response.Included, person.Relationships),
                    CreatedUtc = person.Attributes.CreatedAt,
                    ModifiedUtc = person.Attributes.UpdatedAt
                }));
        }

        public async Task<IEnumerable<PlanningCenter.Net.Models.People.Person>> GetAllPeopleFromListAsync(string listId)
        {
            var people = new List<PlanningCenter.Net.Models.People.Person>();

            int offset = 0;
            var pageSize = 90;

            while(offset <= 10000   )
            {
                var response = await GetListPeopleAsync(listId, offset, pageSize);
                var numResponses = response.Count();
                if(numResponses > 0)
                {
                    people.AddRange(response);
                }
                if(numResponses == 0 || numResponses < pageSize) 
                {
                    break;
                }
                offset += 90;
            }

            return people;
        }

        private string GetPrimaryEmail(List<Models.Included> included, PersonRelationships relationships)
        {
            var emailData = relationships?.Emails?.Data.Select(d => d.Id);

            if(emailData == null || !included.Any())
            {
                return null;
            }

            var emailAttributes = included.Where(i => emailData.Contains(i.Id)).Select(i => (i.Attributes as JObject).ToObject<EmailAttribute>());

            return (emailAttributes.FirstOrDefault(e => e.Primary) ?? emailAttributes.FirstOrDefault())?.Address;
        }

        private string GetPrimaryPhone(List<Models.Included> included, PersonRelationships relationships)
        {
            var phoneData = relationships?.PhoneNumbers?.Data.Select(d => d.Id);

            if(phoneData == null || !included.Any())
            {
                return null;
            }

            var phoneAttributes = included.Where(i => phoneData.Contains(i.Id)).Select(i => (i.Attributes as JObject).ToObject<PhoneNumberAttribute>());

            return (phoneAttributes.FirstOrDefault(e => e.Primary && e.Location.ToLower() == "mobile") ?? phoneAttributes.FirstOrDefault(e => e.Location.ToLower() == "mobile"))?.Number;
        }
    }
}
