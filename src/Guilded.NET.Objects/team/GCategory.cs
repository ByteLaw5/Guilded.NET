using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// A Guilded channel category.
    /// </summary>
    public class GCategory: GBaseObject<GCategory>, ITeamChannel {
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
        public Dictionary<uint, GChannelPermission> RolePermissions {
            get; set;
        }
        /// <summary>
        /// Permissions of the users in this category.
        /// </summary>
        /// <value>User Permissions</value>
        [JsonProperty("userPermissions")]
        public Dictionary<uint, GUserPermission> UserPermissions {
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
    }
}