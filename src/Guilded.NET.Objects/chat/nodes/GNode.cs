using Newtonsoft.Json;
using System.Collections.Generic;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents message node.
    /// </summary>
    public class GNode: GBaseObject<GNode>, IMessageObject, IHasData<object> {
        /// <summary>
        /// Object of the node.
        /// </summary>
        /// <value>Node object</value>
        [JsonProperty("object", Required = Required.Always)]
        public GMsgObject Object {
            get; set;
        }
        /// <summary>
        /// Type of the node.
        /// </summary>
        /// <value>Node type</value>
        [JsonProperty("type", Required = Required.Always)]
        public GNodeType Type {
            get; set;
        }
        /// <summary>
        /// Data of the node.
        /// </summary>
        /// <value>Node data</value>
        [JsonProperty("data")]
        public IDictionary<string, object> Data {
            get; set;
        } = new Dictionary<string, object>();
    }
}