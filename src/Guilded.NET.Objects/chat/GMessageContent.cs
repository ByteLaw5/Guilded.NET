using Newtonsoft.Json;
using System.Collections.Generic;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Content of the message.
    /// </summary>
    public class GMessageContent: GBaseObject<GMessageContent>, IMessageObject {
        /// <summary>
        /// Object of the content.
        /// </summary>
        /// <value>Content object</value>
        [JsonProperty("object", Required = Required.Always)]
        public GMsgObject Object {
            get; set;
        } = GMsgObject.Value;
        /// <summary>
        /// Document of the message content.
        /// </summary>
        /// <value>Message document</value>
        [JsonProperty("document", Required = Required.Always)]
        public GMessageDocument Document {
            get; set;
        }
        /// <summary>
        /// Gets message content nodes.
        /// </summary>
        /// <value>List of Nodes</value>
        [JsonIgnore]
        public IList<GNode> Nodes {
            get => Document.Nodes;
        }
        /// <summary>
        /// Turns a message content into a string.
        /// </summary>
        /// <returns>Content as a string</returns>
        public override string ToString() => string.Concat(Nodes);
    }
}