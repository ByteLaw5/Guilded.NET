using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Guilded.NET {
    [Serializable]
    public class GuildedException : Exception {
        /// <summary>
        /// Code of Guilded error.
        /// </summary>
        /// <value>Error code</value>
        [JsonProperty("code")]
        public string Code {
            get; set;
        }
        /// <summary>
        /// Message of the Guilded error.
        /// </summary>
        /// <value>Error message</value>
        [JsonProperty("message")]
        public string ErrorMessage {
            get; set;
        }
        public GuildedException(): base("Guilded exception was thrown.") { }
        public GuildedException(Exception inner): base("Guilded exception was thrown.", inner) {}
        protected GuildedException(
            SerializationInfo info,
            StreamingContext context): base(info, context) { }
    }
}