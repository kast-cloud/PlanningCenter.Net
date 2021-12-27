using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlanningCenter.Net.Models.Groups.GroupType
{
    public class GroupTypesResponse : ResponseBase<GroupTypesResponseData, GroupTypesResponseMeta> { }

    public class DefaultGroupSettings
    {
        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        [JsonProperty("location_id")]
        public int? LocationId { get; set; }

        [JsonProperty("virtual_location_url")]
        public object VirtualLocationUrl { get; set; }

        [JsonProperty("location_type_preference")]
        public string LocationTypePreference { get; set; }

        [JsonProperty("enrollment_open_until")]
        public object EnrollmentOpenUntil { get; set; }

        [JsonProperty("enrollment_limit")]
        public object EnrollmentLimit { get; set; }

        [JsonProperty("member_limit_maximum_alert")]
        public object MemberLimitMaximumAlert { get; set; }

        [JsonProperty("request_event_attendance_from_leaders")]
        public bool RequestEventAttendanceFromLeaders { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("events_visibility")]
        public string EventsVisibility { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("leaders_can_search_people_database")]
        public bool LeadersCanSearchPeopleDatabase { get; set; }

        [JsonProperty("publicly_display_meeting_schedule")]
        public bool PubliclyDisplayMeetingSchedule { get; set; }

        [JsonProperty("default_event_automated_reminders_enabled")]
        public bool DefaultEventAutomatedRemindersEnabled { get; set; }

        [JsonProperty("default_event_automated_reminders_schedule_offset")]
        public object DefaultEventAutomatedRemindersScheduleOffset { get; set; }

        [JsonProperty("communication_enabled")]
        public bool CommunicationEnabled { get; set; }

        [JsonProperty("members_can_create_forum_topics")]
        public bool MembersCanCreateForumTopics { get; set; }

        [JsonProperty("attendance_reply_to_person_id")]
        public object AttendanceReplyToPersonId { get; set; }

        [JsonProperty("leader_email_visible_to_members")]
        public bool LeaderEmailVisibleToMembers { get; set; }

        [JsonProperty("member_email_visible_to_members")]
        public bool MemberEmailVisibleToMembers { get; set; }

        [JsonProperty("leader_phone_visible_to_members")]
        public bool LeaderPhoneVisibleToMembers { get; set; }

        [JsonProperty("member_phone_visible_to_members")]
        public bool MemberPhoneVisibleToMembers { get; set; }

        [JsonProperty("leader_avatar_visible_to_members")]
        public bool LeaderAvatarVisibleToMembers { get; set; }

        [JsonProperty("member_avatar_visible_to_members")]
        public bool MemberAvatarVisibleToMembers { get; set; }

        [JsonProperty("leader_name_visible_on_public_page")]
        public bool LeaderNameVisibleOnPublicPage { get; set; }

        [JsonProperty("leader_name_visible_to_members")]
        public bool LeaderNameVisibleToMembers { get; set; }

        [JsonProperty("member_name_visible_to_members")]
        public bool MemberNameVisibleToMembers { get; set; }
    }

    public class GroupTypeAttributes
    {
        [JsonProperty("church_center_map_visible")]
        public bool ChurchCenterMapVisible { get; set; }

        [JsonProperty("church_center_visible")]
        public bool ChurchCenterVisible { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("default_group_settings")]
        public DefaultGroupSettings DefaultGroupSettings { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }

    public class GroupTypesResponseData : DataResponseBase
    {
        [JsonProperty("attributes")]
        public GroupTypeAttributes Attributes { get; set; }

        [JsonProperty("links")]
        public SelfLink Links { get; set; }
    }

    public class GroupTypesResponseMeta : MetaResponseBase
    {
        [JsonProperty("can_order_by")]
        public List<string> CanOrderBy { get; set; }

        [JsonProperty("can_filter")]
        public List<string> CanFilter { get; set; }
    }
}
