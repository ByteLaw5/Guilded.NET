using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace Guilded.NET.Objects {
    /// <summary>
    /// Used emote information.
    /// </summary>
    public class EmoteUse: BaseObject<EmoteUse> {
        /// <summary>
        /// ID of the emote.
        /// </summary>
        /// <value>Emote ID</value>
        [JsonProperty("id", Required = Required.Always)]
        public Guid Id {
            get; set; 
        }
        /// <summary>
        /// Total amount of how much this emoji has been used.
        /// </summary>
        /// <value>Count</value>
        [JsonProperty("total", Required = Required.Always)]
        public uint Total {
            get; set;
        }
    }
}