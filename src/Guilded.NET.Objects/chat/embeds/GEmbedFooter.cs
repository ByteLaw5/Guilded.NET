using System;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Footer of the embed.
    /// </summary>
    public class GEmbedFooter: GBaseObject<GEmbedFooter> {
        /// <summary>
        /// Footer icon URL.
        /// </summary>
        /// <value>URL</value>
        [JsonProperty("iconUrl")]
        public Uri IconUrl {
            get; set;
        }
        /// <summary>
        /// Description of the embed footer.
        /// </summary>
        /// <value>Description</value>
        [JsonProperty("text", Required = Required.Always)]
        public string Text {
            get; set;
        }
    }
}