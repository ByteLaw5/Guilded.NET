using Newtonsoft.Json;
using System;

namespace Guilded.NET.Objects.Events {
    using Chat;
    /// <summary>
    /// Event when message is posted in the chat.
    /// </summary>
    public class MessageCreatedEvent: Event<MessageCreatedEvent> {
        /// <summary>
        /// ID of the client.
        /// </summary>
        /// <value>ID</value>
        [JsonProperty("guildedClientId")]
        public string ClientId {
            get; set;
        }
        /// <summary>
        /// ID of the channel this message was posted in.
        /// </summary>
        /// <value>Channel ID</value>
        [JsonProperty("channelId")]
        public Guid ChannelId {
            get; set;
        }
        /// <summary>
        /// ID of the category this message was posted in.
        /// </summary>
        /// <value>Category ID</value>
        [JsonProperty("channelCategoryId")]
        public ulong? CategoryId {
            get; set;
        }
        /// <summary>
        /// Channel type.
        /// </summary>
        /// <value>Channel type</value>
        [JsonProperty("channelType")]
        public string ChannelType {
            get; set;
        }
        /// <summary>
        /// ID of the Team this message was posted in.
        /// </summary>
        /// <value>Team ID</value>
        [JsonProperty("teamId")]
        public GId TeamId {
            get; set;
        }
        /// <summary>
        /// Type of the content.
        /// </summary>
        /// <value>Content type</value>
        [JsonProperty("contentType")]
        public string ContentType {
            get; set;
        }
        /// <summary>
        /// The message which was posted.
        /// </summary>
        /// <value>Message</value>
        [JsonProperty("message")]
        public Message Message {
            get; set;
        }
    }
}