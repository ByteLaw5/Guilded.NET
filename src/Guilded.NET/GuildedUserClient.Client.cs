using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Guilded.NET {
    using API;
    using Util;
    using Objects.Events;
    using Objects;
    /// <summary>
    /// Logged-in user in Guilded.
    /// </summary>
    public partial class GuildedUserClient: BasicGuildedClient {
        protected internal EventHandler<GMessageCreatedEvent> messageCreated;
        /// <summary>
        /// Event when message was posted into the channel.
        /// </summary>
        public event EventHandler<GMessageCreatedEvent> MessageCreated {
            add => messageCreated += value;
            remove => messageCreated -= value;
        }
        protected internal EventHandler<GUserTypingEvent> userTyping;
        /// <summary>
        /// Event when someone is typing into the channel.
        /// </summary>
        public event EventHandler<GUserTypingEvent> UserTyping {
            add => userTyping += value;
            remove => userTyping -= value;
        }
        string pass;
        /// <summary>
        /// User's email.
        /// </summary>
        /// <value>Email</value>
        public string Email {
            get;
            internal set;
        }
        /// <summary>
        /// User's password.
        /// </summary>
        /// <value>Password</value>
        public string Password {
            internal get => pass;
            set {
                //pass = value;
            }
        }
#pragma warning disable 0618
        IList<RestResponseCookie> LoginCookies {
            get; set;
        } = new List<RestResponseCookie>();
#pragma warning restore 0618
        public GUser CurrentUser {
            get; protected set;
        } = null;
        public GuildedUserClient(string email, string password): base() {
            if(string.IsNullOrWhiteSpace(email)) throw new ArgumentException($"{nameof(email)} cannot be null, full of whitespace or empty.");
            else if(string.IsNullOrWhiteSpace(password)) throw new ArgumentException($"{nameof(password)} cannot be null, full of whitespace or empty.");
            Email = email;
            pass = password;
            // Events
            GuildedWebsocketMessage += (o, x) => {
                // Check if it's socket event
                if(x is GSocketEvent xe) {
                    // Get the given data
                    JObject xeobj = xe.Object;
                    // Get the type of the event
                    switch(xe.MessageType) {
                        case "ChatMessageCreated":
                            GMessageCreatedEvent msg = xeobj.ToObject(typeof(GMessageCreatedEvent), GuildedSerializer) as GMessageCreatedEvent;
                            // Send it as message created event
                            messageCreated?.Invoke(this, msg);
                            break;
                        case "ChatChannelTyping":
                            // Send it as user typing event
                            userTyping?.Invoke(this, xeobj.ToObject(typeof(GUserTypingEvent), GuildedSerializer) as GUserTypingEvent);
                            break;
                    }
                }
                else if(x is GSocketMessage xm)
                    // If it's a heartbeat response
                    if(xm.Number == 3) InvokeHeartbeatEvent(this, 3);
            };
        }
        /// <summary>
        /// Connects to Guilded using password and email.
        /// </summary>
        /// <returns>Task</returns>
        public override async Task<object> ConnectAsync() {
            // Creates login details to send to Guilded
            var login = new { email = Email, password = Password };
            // Sends login details to Guilded
            var executed = await ExecuteRequest<object>(Endpoint.LOGIN, new GJsonBody(login));
            // Set login cookies
            LoginCookies = executed.Cookies;
            // Executes base
            await base.BasicConnectAsync(LoginCookies);
            // Gets user info from login response
            CurrentUser = JObject.Parse(executed.Content)["user"].ToObject<GUser>(GuildedSerializer);
            return executed;
        }
        /// <summary>
        /// Disconnects from Guilded.
        /// </summary>
        /// <returns>Task</returns>
        public override async Task<object> DisconnectAsync() {
            // Disconnect
            var executed = await ExecuteRequest<object>(Endpoint.LOGOUT);
            // Invoke disconnection event
            await base.BasicDisconnectAsync();

            return executed;
        }
    }
}