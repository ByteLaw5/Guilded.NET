using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace Guilded.NET.Objects {
    /// <summary>
    /// Guilded emote object.
    /// </summary>
    public class GEmote: GBaseObject<GEmote> {
        /// <summary>
        /// Who created the emote.
        /// </summary>
        /// <value>User ID</value>
        [JsonProperty("createdBy")]
        public GId Author {
            get; set;
        }
        /// <summary>
        /// ID of the team where emote is in.
        /// </summary>
        /// <value>Team ID</value>
        [JsonProperty("teamId", Required = Required.Always)]
        public GId TeamId {
            get; set;
        }
        /// <summary>
        /// ID of the emote.
        /// </summary>
        /// <value>Emote ID</value>
        [JsonProperty("id", Required = Required.Always)]
        public Guid Id {
            get; set;
        }
        /// <summary>
        /// Aliases of emote.
        /// </summary>
        /// <value>List of names</value>
        [JsonProperty("aliases")]
        public IList<string> Aliases {
            get; set;
        }
        /// <summary>
        /// URL to emote's PNG file.
        /// </summary>
        /// <value>.PNG URL</value>
        [JsonProperty("png")]
        public string PNGURL {
            get; set;
        }
        /// <summary>
        /// URL to emote's APNG file.
        /// </summary>
        /// <value>.APNG URL</value>
        [JsonProperty("apng")]
        public string APNGURL {
            get; set;
        }
        /// <summary>
        /// URL to emote's WebP file.
        /// </summary>
        /// <value>.WEBP URL</value>
        [JsonProperty("webp")]
        public string WebPURL {
            get; set;
        }
        /// <summary>
        /// Name of the emote.
        /// </summary>
        /// <value>Name</value>
        [JsonProperty("name")]
        public string Name {
            get; set;
        }
    }
}