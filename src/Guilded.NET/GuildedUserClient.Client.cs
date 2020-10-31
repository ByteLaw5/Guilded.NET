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
        protected internal EventHandler<MessageCreatedEvent> messageCreated;
        /// <summary>
        /// Event when message was posted into the channel.
        /// </summary>
        public event EventHandler<MessageCreatedEvent> MessageCreated {
            add => messageCreated += value;
            remove => messageCreated -= value;
        }
        protected internal EventHandler<UserTypingEvent> userTyping;
        /// <summary>
        /// Event when someone is typing into the channel.
        /// </summary>
        public event EventHandler<UserTypingEvent> UserTyping {
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
        public User CurrentUser {
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
                if(x is SocketEvent xe) {
                    // Get the given data
                    JObject xeobj = xe.Object;
                    // Get the type of the event
                    switch(xe.MessageType) {
                        case "ChatMessageCreated":
                            MessageCreatedEvent msg = xeobj.ToObject(typeof(MessageCreatedEvent), GuildedSerializer) as MessageCreatedEvent;
                            // Send it as message created event
                            messageCreated?.Invoke(this, msg);
                            break;
                        case "ChatChannelTyping":
                            // Send it as user typing event
                            userTyping?.Invoke(this, xeobj.ToObject(typeof(UserTypingEvent), GuildedSerializer) as UserTypingEvent);
                            break;
                    }
                }
                else if(x is SocketMessage xm)
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
            var executed = await ExecuteRequest<object>(Endpoint.LOGIN, new JsonBody(login));
            // Set login cookies
            LoginCookies = executed.Cookies;
            // Executes base
            await base.BasicConnectAsync(LoginCookies);
            // Parse given object
            JObject obj = JObject.Parse(executed.Content);
            try {
                // Turn it into current user
                CurrentUser = obj["user"].ToObject<User>(GuildedSerializer);
            } catch(Exception e) {
                // Create new exception and throw it
                GuildedException exception = new GuildedException(e);
                exception.Code = obj["code"].Value<string>();
                exception.ErrorMessage = obj["message"].Value<string>();
                throw exception;
            }
            // Invokes login event
            ConnectedEvent?.Invoke(this, EventArgs.Empty);
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