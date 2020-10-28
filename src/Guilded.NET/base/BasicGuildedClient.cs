using RestSharp;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using Websocket.Client;
using System.Text.RegularExpressions;

namespace Guilded.NET {
    using API;
    using Util;
    using Objects.Converters;
    public abstract class BasicGuildedClient: BaseGuildedClient {
        event EventHandler<GSocketMessage> guildedWebsocketMessage;
        /// <summary>
        /// Event when websocket receives a message.
        /// </summary>
        protected event EventHandler<GSocketMessage> GuildedWebsocketMessage {
            add => guildedWebsocketMessage += value;
            remove => guildedWebsocketMessage -= value;
        }
        /// <summary>
        /// Serializer used to (de)serialize JSONs given by Guilded or made for Guilded.
        /// </summary>
        /// <value></value>
        protected JsonSerializer GuildedSerializer {
            get; set;
        }
        event EventHandler<int> heartbeatEvent;
        /// <summary>
        /// An event when Guilded gives heartbeat response.
        /// </summary>
        public event EventHandler<int> HeartbeatResponse {
            add => heartbeatEvent += value;
            remove => heartbeatEvent -= value;
        }
        /// <summary>
        /// List of converters
        /// </summary>
        /// <returns>List of JSON converters</returns>
        protected static JsonConverter[] Converters = new JsonConverter[] {
            new EnumConverter(), new IdConverter(), new NodeConverter()
        };
        /// <summary>
        /// Regexp for numbers at the start of Guilded's mess
        /// </summary>
        /// <returns></returns>
        protected Regex NumberStart = new Regex("^([0-9]+)");
        protected BasicGuildedClient(): base() {
            // Create new serializer
            GuildedSerializer = new JsonSerializer();
            // Adds default converters
            foreach(JsonConverter converter in Converters)
                GuildedSerializer.Converters.Add(converter);
        }
        /// <summary>
        /// Base for connecting to Guilded.
        /// </summary>
        /// <returns>Async Task</returns>
#pragma warning disable 0618
        protected async Task BasicConnectAsync(IList<RestResponseCookie> cookies) {
            // Websocket event subscribtion
            // Inits websocket
            base.InitWebsocket(25, BaseGuildedClient.GuildedWebsocketURL, 25, CookieUtil.From(cookies));
#pragma warning restore 0618
            // Message
            Websocket.MessageReceived.Subscribe(WebsocketMessageReceived);
            // Start
            await Websocket.Start();
            HeartbeatThread.Start();
        }
        /// <summary>
        /// Used for when Websocket receives message.
        /// </summary>
        /// <param name="msg">Message</param>
        protected virtual void WebsocketMessageReceived(ResponseMessage msg) {
            if(msg.MessageType == WebSocketMessageType.Text) {
                // Matches the number using Regex
                string strnum = NumberStart.Match(msg.Text).Value;
                // Parses the number
                uint num = 0;
                uint.TryParse(strnum, out num);
                // Trimmed string
                string trimmed = msg.Text.Substring(strnum.Length);
                // Get type of the socket message
                JArray array;
                JObject jobj;
                if(JsonUtil.TryParse(trimmed, out array)) {
                    // Gets type and object from the array
                    if (array[0] is JValue value && array[1] is JObject obj)
                        guildedWebsocketMessage?.Invoke(this, new GSocketEvent(num, obj, value.ToString()));
                }
                else if(JsonUtil.TryParse(trimmed, out jobj))
                    guildedWebsocketMessage?.Invoke(this, new GObjectMessage(num, jobj));
                else if(string.IsNullOrEmpty(trimmed))
                    guildedWebsocketMessage?.Invoke(this, new GSocketMessage(num));
            }
        }
        /// <summary>
        /// Base for disconnect method.
        /// </summary>
        /// <returns>Task</returns>
        protected Task BasicDisconnectAsync() {
            DisconnectedEvent?.Invoke(this, EventArgs.Empty);
            return Task.CompletedTask;
        }
        /// <summary>
        /// Disposes the bot.
        /// </summary>
        public override void Dispose() {
            DisconnectAsync().GetAwaiter().GetResult();
            base.Dispose();
        }
        /// <summary>
        /// Invokes heartbeat event.
        /// </summary>
        /// <param name="o">The sender</param>
        /// <param name="value">Heartbeat response</param>
        protected void InvokeHeartbeatEvent(object o, int value) => heartbeatEvent?.Invoke(o, value);
    }
}