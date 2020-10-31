using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Represents Guilded channel.
    /// </summary>
    public class Channel: BaseObject<Channel>, ITeamChannel {
        /// <summary>
        /// Priority of this channel.
        /// </summary>
        /// <value>Priority</value>
        [JsonProperty("priority")]
        public uint? Priority {
            get; set;
        }
        /// <summary>
        /// ID of this channel.
        /// </summary>
        /// <value>Channel ID</value>
        [JsonProperty("id")]
        public Guid Id {
            get; set;
        }
        /// <summary>
        /// Name of this channel.
        /// </summary>
        /// <value>Name</value>
        [JsonProperty("name")]
        public string Name {
            get; set;
        }
        /// <summary>
        /// Description of this channel.
        /// </summary>
        /// <value>Channel Description</value>
        [JsonProperty("description")]
        public string Description {
            get; set;
        }
        /// <summary>
        /// Permissions of the roles in this channel.
        /// </summary>
        /// <value>Role Permissions</value>
        [JsonProperty("rolesById")]
        public Dictionary<uint, ChannelPermission> RolePermissions {
            get; set;
        }
        /// <summary>
        /// Permissions of the users in this channel.
        /// </summary>
        /// <value>User Permissions</value>
        [JsonProperty("userPermissions")]
        public Dictionary<uint, UserPermission> UserPermissions {
            get; set;
        }
        /// <summary>
        /// Tournament permissions.
        /// </summary>
        /// <value>Permissions</value>
        //[JsonProperty("tournamentRolesById")]
        //public Dictionary<uint, Permissions> TournamentRolePermissions {
        //    get; set;
        //}
        /// <summary>
        /// ID of team this channel is in.
        /// </summary>
        /// <value>Team ID</value>
        [JsonProperty("teamId")]
        public GId TeamId {
            get; set;
        }
        /// <summary>
        /// ID of the category this channel is in.
        /// </summary>
        /// <value>Nullable Channel ID</value>
        [JsonProperty("channelCategoryId")]
        public uint? ChannelCategoryId {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("addedAt")]
        public DateTime AddedAt {
            get; set;
        }
        /// <summary>
        /// If role permissions are synced with the category.
        /// </summary>
        /// <value></value>
        [JsonProperty("isRoleSynced")]
        public bool? IsRoleSynced {
            get; set;
        }
        /// <summary>
        /// Whether or not this channel is public.
        /// </summary>
        /// <value>Boolean</value>
        [JsonProperty("isPublic")]
        public bool IsPublic {
            get; set;
        }
        /// <summary>
        /// ID of the group this channel is in.
        /// </summary>
        /// <value>Group ID</value>
        [JsonProperty("groupId")]
        public GId GroupId {
            get; set;
        }
        /// <summary>
        /// When the channel was created.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt {
            get; set;
        }
        /// <summary>
        /// Who created the channel.
        /// </summary>
        /// <value>User ID</value>
        [JsonProperty("createdBy")]
        public GId CreatedBy {
            get; set;
        }
        /// <summary>
        /// When the channel was updated.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt {
            get; set;
        }
        /// <summary>
        /// Type of the channel.
        /// </summary>
        /// <value>Content Type</value>
        [JsonProperty("contentType")]
        public ChannelType Type {
            get; set;
        }
        /// <summary>
        /// When the channel was archived.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("archivedAt")]
        public DateTime? ArchivedAt {
            get; set;
        }
        /// <summary>
        /// User who archived it.
        /// </summary>
        /// <value>User ID</value>
        [JsonProperty("archivedBy")]
        public GId ArchivedBy {
            get; set;
        }
        /// <summary>
        /// ID of the parent channel.
        /// </summary>
        /// <value>Channel ID</value>
        [JsonProperty("parentChannelId")]
        public Guid? ParentChannel {
            get; set;
        }
        /// <summary>
        /// Auto archive date.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("autoArchiveAt")]
        public DateTime? AutoArchiveAt {
            get; set;
        }
        /// <summary>
        /// Date when it was deleted.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("deletedAt")]
        public DateTime? DeletedAt {
            get; set;
        }
        /// <summary>
        /// Turns channel to string.
        /// </summary>
        /// <returns>Channel as a string</returns>
        public override string ToString() => $"Channel({Id})";
        /// <summary>
        /// Whether or not objects are equal.
        /// </summary>
        /// <param name="obj">Equals to</param>
        /// <returns>If it's equal to other object</returns>
        public override bool Equals(object obj) {
            if(obj is Channel ch) return ch.TeamId == TeamId && ch.Id == Id;
            else return false;
        }
        /// <summary>
        /// Whether or not channels are equal.
        /// </summary>
        /// <param name="ch0">First channel to be compared</param>
        /// <param name="ch1">Second channel to be compared</param>
        /// <returns>If it's equal to other object</returns>
        public static bool operator ==(Channel ch0, Channel ch1) => ch0.TeamId == ch1.TeamId && ch0.Id == ch1.Id;
        /// <summary>
        /// Whether or not channels are not equal.
        /// </summary>
        /// <param name="ch0">First channel to be compared</param>
        /// <param name="ch1">Second channel to be compared</param>
        /// <returns>If it's not equal to other object</returns>
        public static bool operator !=(Channel ch0, Channel ch1) => !(ch0 == ch1);
        /// <summary>
        /// Gets channel hashcode.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode() => (TeamId.GetHashCode() + Id.GetHashCode() + 2000) / 2;
    }
}