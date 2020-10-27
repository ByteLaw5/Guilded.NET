using System;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Represents permission in a channel.
    /// </summary>
    public class GChannelPermission: GBaseObject<GChannelPermission>, IPermission {
        /// <summary>
        /// Id of the team this permission's channel is in.
        /// </summary>
        /// <value>Team ID</value>
        [JsonProperty("teamId")]
        public GId TeamId {
            get; set;
        }
        /// <summary>
        /// Id of the channel this permission is in.
        /// </summary>
        /// <value>Channel ID</value>
        [JsonProperty("channelId")]
        public Guid ChannelId {
            get; set;
        }
        [JsonProperty("teamRoleId")]
        public ulong TeamRoleId {
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