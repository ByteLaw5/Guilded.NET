using System.Threading.Tasks;
using System.Net;
using RestSharp;
using System;
using System.Net.WebSockets;
using Websocket.Client;
using System.Threading;

namespace Guilded.NET.API {
    /// <summary>
    /// A base for Guilded client.
    /// </summary>
    public abstract class BaseGuildedClient: IDisposable {
        /// <summary>
        /// Events when client gets Connected/Disconnected.
        /// </summary>
        protected EventHandler ConnectedEvent, DisconnectedEvent;
        /// <summary>
        /// Thread for heartbeats.
        /// </summary>
        /// <value>Thread</value>
        protected Thread HeartbeatThread {
            get; set;
        }
        /// <summary>
        /// Token for cancelling heartbeat thread.
        /// </summary>
        /// <value>Cancellation Token</value>
        protected CancellationTokenSource HeartbeatToken {
            get; set;
        }
        /// <summary>
        /// Guilded API URL.
        /// </summary>
        /// <value>URL</value>
        public static readonly string GuildedAPIURL = "https://api.guilded.gg/";
        /// <summary>
        /// Guilded Websocket URL.
        /// </summary>
        /// <value>URL</value>
        public static readonly string GuildedWebsocketURL = "wss://api.guilded.gg/socket.io/?jwt=undefined&EIO=3&transport=websocket";
        /// <summary>
        /// Default span of time between heartbeats.
        /// </summary>
        /// <value>Seconds</value>
        public static readonly double DefaultHeartbeat = 25;
        /// <summary>
        /// Rest client for Guilded.
        /// </summary>
        /// <seealso cref="Websocket"/>
        /// <value>Rest client</value>
        protected internal RestClient Rest {
            get; set;
        }
        /// <summary>
        /// Websocket client for Guilded. Websocket is null until <see cref="InitWebsocket(double?, string, double, CookieContainer"/> is called.
        /// </summary>
        /// <seealso cref="Rest"/>
        /// <value>Websocket</value>
        protected internal WebsocketClient Websocket {
            get; set;
        }
        /// <summary>
        /// Span of time between each heartbeat.
        /// </summary>
        /// <value>Seconds</value>
        public double HeartbeatTime {
            get; set;
        }
        /// <summary>
        /// Event when client connects to the Guilded.
        /// </summary>
        public event EventHandler Connected {
            add => ConnectedEvent += value;
            remove => ConnectedEvent -= value;
        }
        /// <summary>
        /// Event when client disconnects from Guilded.
        /// </summary>
        public event EventHandler Disconnected {
            add => DisconnectedEvent += value;
            remove => DisconnectedEvent += value;
        }
        /// <param name="apiurl">URL of API</param>
        /// <exception cref="System.ArgumentNullException">When apiurl or socketurl are null</exception>
        /// <exception cref="System.UriFormatException">When apiurl or socketurl are invalid</exception>
        protected BaseGuildedClient(string apiurl) {
            // If apiurl is null, throw an exception
            if(apiurl == null) throw new ArgumentNullException($"{nameof(apiurl)} is null.");
            // Initialize Rest client
            Rest = new RestClient(apiurl);
        }
        protected BaseGuildedClient(): this(GuildedAPIURL) {}
        /// <summary>
        /// Sends a request to Guilded's API with given arguments.
        /// </summary>
        /// <param name="endpoint">Guilded API endpoint</param>
        /// <param name="args">Args to be given to that endpoint</param>
        /// <typeparam name="T">Type of the response</typeparam>
        /// <returns>Request response</returns>
        public async Task<IRestResponse<T>> ExecuteRequest<T>(Endpoint endpoint, params IReqAddable[] addables) {
            // Create new request
            RestRequest req = new RestRequest(endpoint.Path, endpoint.EndpointMethod);
            // Add parameters
            foreach(var addable in addables)
                addable.AddTo(req);
            // Execute and return the response
            return await Rest.ExecuteAsync<T>(req);
        }
        /// <summary>
        /// Sends a request to Guilded's API without arguments.
        /// </summary>
        /// <param name="endpoint">Guilded API endpoint</param>
        /// <typeparam name="T">Type of the response</typeparam>
        /// <returns>Request response</returns>
        public async Task<IRestResponse<T>> ExecuteRequest<T>(Endpoint endpoint) {
            // Create new request
            RestRequest req = new RestRequest(endpoint.Path, endpoint.EndpointMethod);
            // Execute and return the response
            return await Rest.ExecuteAsync<T>(req);
        }
        /// <summary>
        /// Initializes websocket.
        /// </summary>
        /// <param name="reconnection">Seconds of time between each reconnection</param>
        /// <param name="socketurl">URL of WebSocket</param>
        /// <param name="heartbeat">Seconds between each heartbeat</param>
        /// <param name="cookies">Cookies given after Rest Client logged into Guilded</param>
        protected virtual void InitWebsocket(double? reconnection, string socketurl, double heartbeat, CookieContainer cookies) {
            // If socketurl is null, throw an exception
            if(socketurl == null) throw new ArgumentNullException($"{nameof(socketurl)} is null.");
            HeartbeatTime = heartbeat;
            // Initialize Websocket client
            var factory = new Func<ClientWebSocket>(() => new ClientWebSocket {
                // Options of the ClientWebSocket
                Options = {
                    KeepAliveInterval = TimeSpan.FromSeconds(heartbeat),
                    Cookies = cookies
                }
            });
            Websocket = new WebsocketClient(new Uri(socketurl), factory);
            // Starts a heartbeat thread
            HeartbeatToken = new CancellationTokenSource();
            HeartbeatThread = new Thread(async (o) => await HeartbeatThreadMethod(HeartbeatToken.Token));
            //SendHeartbeat("2");
            // Reconnection
            if(reconnection != null)
                Websocket.ReconnectTimeout = TimeSpan.FromSeconds(reconnection.Value);
        }
        /// <summary>
        /// Connects to Guilded client/user.
        /// </summary>
        /// <returns>Async Task</returns>
        public abstract Task<object> ConnectAsync();
        /// <summary>
        /// Disconnects from Guilded client/user.
        /// </summary>
        /// <returns>Async Task</returns>
        public abstract Task<object> DisconnectAsync();
        /// <summary>
        /// Disposes BaseGuildedClient.
        /// </summary>
        public virtual void Dispose() {
            HeartbeatToken.Cancel();
            HeartbeatThread.Join();
            Websocket.Dispose();
        }
        /// <summary>
        /// Method for hearbeat thread.
        /// </summary>
        /// <param name="token">Token for cancelling while loop</param>
        protected virtual async Task HeartbeatThreadMethod(CancellationToken token) {
            // Turn seconds into milliseconds
            int ms = (int)HeartbeatTime * 1000;
            // If thread wasn't cancelled
            while(!token.IsCancellationRequested) {
                // Sends a heartbeat
                await SendHeartbeat("2");
                // Make it sleep until the next thread
                Thread.Sleep(ms);
            }
        }
        /// <summary>
        /// Sends a heartbeat to the websocket server.
        /// </summary>
        /// <param name="value">Heartbeat value</param>
        protected virtual async Task SendHeartbeat(string value) {
            // Websocket sends ping too
            Websocket.Send(value);
            // Rest client sends a ping too
            await ExecuteRequest<object>(Endpoint.PING);
        }
    }
}
