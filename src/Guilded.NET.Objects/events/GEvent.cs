using Newtonsoft.Json;

namespace Guilded.NET.Objects.Events {
    /// <summary>
    /// Guilded abstract event.
    /// </summary>
    public abstract class GEvent<T>: GBaseObject<T> where T: GEvent<T> {
        /// <summary>
        /// Event type given by Guilded Websocket.
        /// </summary>
        /// <value></value>
        [JsonProperty("type")]
        public string EventType {
            get;
        }
    }
}