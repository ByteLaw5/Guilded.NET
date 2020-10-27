using System;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Interface for all messages.
    /// </summary>
    public interface IGMessage {
        /// <summary>
        /// ID of the message.
        /// </summary>
        /// <value>Message ID</value>
        Guid Id {
            get; set;
        }
        /// <summary>
        /// Content of the message.
        /// </summary>
        /// <value>Message content</value>
        GMessageContent Content {
            get; set;
        }
    }
}