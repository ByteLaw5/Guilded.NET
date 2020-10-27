using System.Collections.Generic;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// List of channels in a team.
    /// </summary>
    public class GChannels: GBaseObject<GChannels> {
        /// <summary>
        /// List of channel categories.
        /// </summary>
        /// <value>List of categories</value>
        [JsonProperty("categories")]
        public IList<GCategory> Categories {
            get; set;
        }
        /// <summary>
        /// List of temporal channels.
        /// </summary>
        /// <value>List of temporal channels</value>
        [JsonProperty("temporalChannels")]
        public IList<GChannel> TemporalChannels {
            get; set;
        }
        /// <summary>
        /// List of channels in group or team.
        /// </summary>
        /// <value>List of channels</value>
        [JsonProperty("channels")]
        public IList<GChannel> Channels {
            get; set;
        }
    }
}