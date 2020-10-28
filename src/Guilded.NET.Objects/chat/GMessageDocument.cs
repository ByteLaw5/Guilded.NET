using Newtonsoft.Json;
using System.Collections.Generic;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Document of the message content.
    /// </summary>
    public class GMessageDocument: GBaseObject<GMessageDocument>, IMessageObject {
        /// <summary>
        /// List of nodes in message content document.
        /// </summary>
        /// <value>Document nodes</value>
        [JsonProperty("nodes", Required = Required.Always)]
        public IList<GNode> Nodes {
            get; set;
        }
        /// <summary>
        /// Object of the content.
        /// </summary>
        /// <value>Content object</value>
        [JsonProperty("object", Required = Required.Always)]
        public GMsgObject Object {
            get; set;
        } = GMsgObject.Document;
        /// <summary>
        /// Data of the document.
        /// </summary>
        /// <value>Document data</value>
        [JsonProperty("data")]
        public IDictionary<string, object> Data {
            get; set;
        }
        /// <summary>
        /// Turns a message content into a string.
        /// </summary>
        /// <returns>Content as a string</returns>
        public override string ToString() => string.Concat(Nodes);
    }
}