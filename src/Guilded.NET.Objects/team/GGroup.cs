using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Represents Guilded team group/subserver.
    /// </summary>
    public class GGroup: GBaseObject<GGroup> {
        /// <summary>
        /// ID of this group.
        /// </summary>
        /// <value>Group ID</value>
        [JsonProperty("id", Required = Required.Always)]
        public GId Id {
            get; set;
        }
        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <value>Name</value>
        [JsonProperty("name", Required = Required.Always)]
        public string Name {
            get; set;
        }
        /// <summary>
        /// A description of a team.
        /// </summary>
        /// <value>Nullable string</value>
        [JsonProperty("description", Required = Required.Always)]
        public string Description {
            get; set;
        }
        /// <summary>
        /// Priority of the group.
        /// </summary>
        /// <value>Priority</value>
        [JsonProperty("priority", Required = Required.Always)]
        public uint? Priority {
            get; set;
        }
        /// <summary>
        /// Icon of this group.
        /// </summary>
        /// <value>Nullable URL</value>
        [JsonProperty("avatar")]
        public Uri Avatar {
            get; set;
        }
        /// <summary>
        /// Banner of this group. Currently unused by Guilded. Potential feature?
        /// </summary>
        /// <value>Always null URL</value>
        [JsonProperty("banner")]
        public Uri Banner {
            get; set;
        }
        /// <summary>
        /// ID of the team this group is in.
        /// </summary>
        /// <value>Team ID</value>
        [JsonProperty("teamId", Required = Required.Always)]
        public GId TeamId {
            get; set;
        }
        /// <summary>
        /// ID of the game in this group.
        /// </summary>
        /// <value>Game ID</value>
        [JsonProperty("gameId")]
        public ulong? GameId {
            get; set;
        }
        /// <summary>
        /// User membership updates in this group.
        /// </summary>
        /// <value>List of Membership Updates</value>
        [JsonProperty("membershipUpdates")]
        public IList<GMembership> MembershipUpdates {
            get; set;
        }
        /// <summary>
        /// User membership updates in this group by user ID.
        /// </summary>
        /// <value>Uint, Membership type</value>
        [JsonProperty("membershipUpdatesByUserId")]
        public Dictionary<uint, GMembershipType> MembershipUpdatesByUserId {
            get; set;
        }
        /// <summary>
        /// Priority of this group current user has set to.
        /// </summary>
        /// <value>User custom priority</value>
        [JsonProperty("userPriority")]
        public uint? UserPriority {
            get; set;
        }
    }
}