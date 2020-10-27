using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Message posted in chat.
    /// </summary>
    public class GMessage: GBaseObject<GMessage>, IGMessage {
        /// <summary>
        /// ID of the message.
        /// </summary>
        /// <value>Message ID</value>
        [JsonProperty("id", Required = Required.Always)]
        public Guid Id {
            get; set;
        }
        /// <summary>
        /// ID of the author.
        /// </summary>
        /// <value>Message ID</value>
        [JsonProperty("createdBy")]
        public GId AuthorId {
            get; set;
        }
        /// <summary>
        /// Type of the message.
        /// </summary>
        /// <value>Message type</value>
        [JsonProperty("type")]
        public string Type {
            get; set;
        }
        /// <summary>
        /// Date of when the message was posted.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt {
            get; set;
        }
        /// <summary>
        /// Content of the message.
        /// </summary>
        /// <value>Message content</value>
        [JsonProperty("content", Required = Required.Always)]
        public GMessageContent Content {
            get; set;
        }
        /// <summary>
        /// Gets message content nodes.
        /// </summary>
        /// <value>List of Nodes</value>
        [JsonIgnore]
        public IList<GNode> Nodes {
            get => Content.Nodes;
        }
        /// <summary>
        /// Generates a new message.
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <returns>GNewMessage</returns>
        public static GNewMessage Generate(IList<GNode> nodes) =>
            new GNewMessage {
                // Generate random ID and give it to the message
                Id = Guid.NewGuid(),
                // Create content for the message
                Content = new GMessageContent {
                    // Create document for message content and then assign given nodes
                    Document = new GMessageDocument {
                        Data = new Dictionary<string, object>(),
                        Nodes = nodes
                    }
                }
            };
    }
}