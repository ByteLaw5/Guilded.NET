using System.Collections.Generic;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// List of channels in a team.
    /// </summary>
    public class Channels: BaseObject<Channels> {
        /// <summary>
        /// List of channel categories.
        /// </summary>
        /// <value>List of categories</value>
        [JsonProperty("categories")]
        public IList<Category> Categories {
            get; set;
        }
        /// <summary>
        /// List of temporal channels.
        /// </summary>
        /// <value>List of temporal channels</value>
        [JsonProperty("temporalChannels")]
        public IList<Channel> TemporalChannels {
            get; set;
        }
        /// <summary>
        /// List of channels in group or team.
        /// </summary>
        /// <value>List of channels</value>
        [JsonProperty("channels")]
        public IList<Channel> AllChannels {
            get; set;
        }
    }
}