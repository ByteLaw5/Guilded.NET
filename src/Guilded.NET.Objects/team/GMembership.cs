using Newtonsoft.Json;

namespace Guilded.NET.Objects.Teams {
    public class GMembership: GBaseObject<GMembership> {
        /// <summary>
        /// Type of the membership.
        /// </summary>
        /// <value>Membership type</value>
        [JsonProperty("type")]
        public GMembershipType Type {
            get; set;
        }
        /// <summary>
        /// ID of the membership user.
        /// </summary>
        /// <value>User ID</value>
        [JsonProperty("userId")]
        public GId UserID {
            get; set;
        }
    }
}