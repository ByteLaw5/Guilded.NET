using Newtonsoft.Json.Linq;

namespace Guilded.NET.Util {
    /// <summary>
    /// Websocket message given by 
    /// </summary>
    public class GObjectMessage: GSocketMessage {
        /// <summary>
        /// Given object by Guilded Websocket client.
        /// </summary>
        /// <value>JSON Object</value>
        public JObject Object {
            get; set;
        }
        /// <param name="number">Number of the Socket Message</param>
        /// <param name="obj">Object of the Socket Message</param>
        public GObjectMessage(uint number, JObject obj): base(number) =>
            Object = obj;
    }
}