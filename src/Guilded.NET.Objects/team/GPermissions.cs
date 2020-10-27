using Newtonsoft.Json;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Represents role permissions.
    /// </summary>
    public class GPermissions: GBaseObject<GPermissions> {
        /// <summary>
        /// Represents chat/text channel permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("chat")]
        public ulong? Chat {
            get; set;
        } = null;
        /// <summary>
        /// Represents document channel permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("docs")]
        public ulong? Docs {
            get; set;
        } = null;
        /// <summary>
        /// Represents permissions for forms and polls.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("forms")]
        public ulong? Forms {
            get; set;
        } = null;
        /// <summary>
        /// List channel permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("lists")]
        public ulong? Lists {
            get; set;
        } = null;
        /// <summary>
        /// Media channel permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("media")]
        public ulong? Media {
            get; set;
        } = null;
        /// <summary>
        /// Forum channel permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("forums")]
        public ulong? Forums {
            get; set;
        } = null;
        /// <summary>
        /// General permissions for managing the server.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("general")]
        public ulong? General {
            get; set;
        } = null;
        /// <summary>
        /// Permissions related to streaming channel.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("streams")]
        public ulong? Streams {
            get; set;
        } = null;
        /// <summary>
        /// Calendar/event channel permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("calendar")]
        public ulong? Calendar {
            get; set;
        } = null;
        /// <summary>
        /// Scheduling channel permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("scheduling")]
        public ulong? Scheduling {
            get; set;
        } = null;
        /// <summary>
        /// Competitive permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("matchmaking")]
        public ulong? Matchmaking {
            get; set;
        } = null;
        /// <summary>
        /// Permissions for recruitment and applications.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("recruiment")]
        public ulong? Recruitment {
            get; set;
        } = null;
        /// <summary>
        /// Announcement channel and overview announcement permissions.
        /// </summary>
        /// <value>Permissions</value>
        [JsonProperty("announcements")]
        public ulong? Announcements {
            get; set;
        } = null;
        /// <summary>
        /// I don't even know what this is tbf.
        /// </summary>
        /// <value>Something I don't know</value>
        [JsonProperty("customization")]
        public ulong? Customization {
            get; set;
        } = null;
    }
}