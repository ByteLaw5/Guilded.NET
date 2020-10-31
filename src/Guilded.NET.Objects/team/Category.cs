using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// A Guilded channel category.
    /// </summary>
    public class Category: BaseObject<Category>, ITeamChannel {
        /// <summary>
        /// Priority of this category.
        /// </summary>
        /// <value>Priority</value>
        [JsonProperty("priority")]
        public uint? Priority {
            get; set;
        }
        /// <summary>
        /// ID of this category.
        /// </summary>
        /// <value>Category ID</value>
        [JsonProperty("id")]
        public uint Id {
            get; set;
        }
        /// <summary>
        /// Name of this category.
        /// </summary>
        /// <value>Name</value>
        [JsonProperty("name")]
        public string Name {
            get; set;
        }
        /// <summary>
        /// Permissions of the roles in this category.
        /// </summary>
        /// <value>Role Permissions</value>
        [JsonProperty("rolesById")]
        public Dictionary<uint, ChannelPermission> RolePermissions {
            get; set;
        }
        /// <summary>
        /// Permissions of the users in this category.
        /// </summary>
        /// <value>User Permissions</value>
        [JsonProperty("userPermissions")]
        public Dictionary<uint, UserPermission> UserPermissions {
            get; set;
        }
        /// <summary>
        /// ID of team this category is in.
        /// </summary>
        /// <value>Team ID</value>
        [JsonProperty("teamId")]
        public GId TeamId {
            get; set;
        }
        /// <summary>
        /// ID of the category this category is in.
        /// </summary>
        /// <value>Null</value>
        [JsonProperty("channelCategoryId")]
        public uint? ChannelCategoryId {
            get; set;
        }
        /// <summary>
        /// ID of the group this category is in.
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
        /// When the channel was updated.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt {
            get; set;
        }
        /// <summary>
        /// Turns channel to string.
        /// </summary>
        /// <returns>Channel as a string</returns>
        public override string ToString() => $"Category({Id})";
        /// <summary>
        /// Whether or not objects are equal.
        /// </summary>
        /// <param name="obj">Equals to</param>
        /// <returns>If it's equal to other object</returns>
        public override bool Equals(object obj) {
            if(obj is Category ca) return ca.TeamId == TeamId && ca.Id == Id;
            else return false;
        }
        /// <summary>
        /// Whether or not category are equal.
        /// </summary>
        /// <param name="ca0">First channel to be compared</param>
        /// <param name="ca1">Second channel to be compared</param>
        /// <returns>If it's equal to other object</returns>
        public static bool operator ==(Category ca0, Category ca1) => ca0.TeamId == ca1.TeamId && ca0.Id == ca1.Id;
        /// <summary>
        /// Whether or not category are not equal.
        /// </summary>
        /// <param name="ca0">First channel to be compared</param>
        /// <param name="ca1">Second channel to be compared</param>
        /// <returns>If it's not equal to other object</returns>
        public static bool operator !=(Category ca0, Category ca1) => !(ca0 == ca1);
        /// <summary>
        /// Gets category hashcode.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode() => (TeamId.GetHashCode() + Id.GetHashCode() + 2500) / 2;
    }
}