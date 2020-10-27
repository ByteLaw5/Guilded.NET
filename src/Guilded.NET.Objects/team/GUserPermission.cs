using System;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Represents user permissions in the channel.
    /// </summary>
    public class GUserPermission: GBaseObject<GUserPermission>, IPermission {
        /// <summary>
        /// ID of the user.
        /// </summary>
        /// <value>User ID</value>
        [JsonProperty("userId")]
        public GId UserId {
            get; set;
        }
        /// <summary>
        /// ID of the channel this permission is in.
        /// </summary>
        /// <value>Channel ID</value>
        [JsonProperty("channelId")]
        public Guid ChannelId {
            get; set;
        }
        /// <summary>
        /// The date when this permission was created.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt {
            get; set;
        }
        /// <summary>
        /// The date when this permission was updated.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt {
            get; set;
        }
        /// <summary>
        /// Denied permissions in this channel.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("denyPermissions")]
        public GPermissions DenyPermissions {
            get; set;
        }
        /// <summary>
        /// Allowed permissions in this channel.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("allowPermissions")]
        public GPermissions AllowPermissions {
            get; set;
        }
    }
}