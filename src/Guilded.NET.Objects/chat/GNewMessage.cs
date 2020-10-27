using Newtonsoft.Json;
using System;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Message posted in chat.
    /// </summary>
    public class GNewMessage: GBaseObject<GMessage>, IGMessage {
        /// <summary>
        /// ID of the message.
        /// </summary>
        /// <value>Message ID</value>
        [JsonProperty("messageId", Required = Required.Always)]
        public Guid Id {
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
        /// I don't even know what this is.
        /// </summary>
        /// <value>Something</value>
        [JsonProperty("confirmed")]
        public bool Confirmed {
            get; set;
        } = false;
    }
}