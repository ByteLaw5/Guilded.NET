using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Guilded.NET.Objects {
    using Teams;
    /// <summary>
    /// Information about this user.
    /// </summary>
    public class GMe: GBaseObject<GMe> {
        /// <summary>
        /// List of teams/guilds/server this user is currently in.
        /// </summary>
        /// <value>List of teams</value>
        [JsonProperty("teams")]
        public IList<GTeam> Teams {
            get; set;
        }
        /// <summary>
        /// The user itself.
        /// </summary>
        /// <value>User</value>
        [JsonProperty("user")]
        public GUser User {
            get; set;
        }
        /// <summary>
        /// I don't know what this is, honestly.
        /// </summary>
        /// <value>Message</value>
        [JsonProperty("updateMessage")]
        public string UpdateMessage {
            get; set;
        }
        /// <summary>
        /// Custom emotes which can be used in Guilded by this user.
        /// </summary>
        /// <value></value>
        [JsonProperty("customReactions")]
        public IList<GEmote> CustomEmotes {
            get; set;
        }
        /// <summary>
        /// How many times these emotes have been used.
        /// </summary>
        /// <value></value>
        [JsonProperty("reactionUsages")]
        public IList<GEmoteUse> EmoteUses {
            get; set;
        }
    }
}