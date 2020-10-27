using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Guilded.NET {
    using Objects.Chat;
    using Objects;
    using API;
    using Objects.Teams;
    public partial class GuildedUserClient: BasicGuildedClient, IGuildedClient {
        /// <summary>
        /// Gets user this client is using.
        /// </summary>
        /// <returns>Task[Current User]</returns>
        public async Task<GMe> GetThisUserAsync() =>
            JsonConvert.DeserializeObject<GMe>((await ExecuteRequest<object>(Endpoint.ME)).Content, Converters);
        /// <summary>
        /// Gets user this client is using. Sync version of <see cref="GetThisUserAsync"/>.
        /// </summary>
        /// <returns>Current User</returns>
        public GMe GetThisUser() =>
            GetThisUserAsync().GetAwaiter().GetResult();
        /// <summary>
        /// Sends a message to the specific channel.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message</param>
        /// <returns>Async task</returns>
        public async Task<object> SendMessageAsync(Guid channel, GNewMessage message) {
            // Serialize the JSON
            string s = JsonConvert.SerializeObject(message, Converters);
            // Get the endpoint of the given channel
            Endpoint point = new Endpoint($"channels/{channel}/messages", Method.POST);
            // Creates addables
            List<IReqAddable> addables = LoginCookies.Select(x => (IReqAddable)new GCookie(x.Name, x.Value)).ToList();
            addables.Add(new GJsonBody(s));
            // Execute and return it
            return await ExecuteRequest<object>(point, addables.ToArray());
        }
        /// <summary>
        /// Sends a message into the chat. Sync version of <see cref="SendMessageAsync"/>.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message to post</param>
        public void SendMessage(Guid channel, GNewMessage message) =>
            SendMessageAsync(channel, message).GetAwaiter().GetResult();
        /// <summary>
        /// Gets user with given ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        public async Task<GUser> GetUserAsync(GId id) =>
            JObject.Parse((await ExecuteRequest<object>(new Endpoint($"/users/{id}", Method.GET))).Content)["user"].ToObject<GUser>(GuildedSerializer);
        /// <summary>
        /// Gets user with given ID. Sync version of <see cref="GetUserAsync"/>.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        public GUser GetUser(GId id) =>
            GetUserAsync(id).GetAwaiter().GetResult();
        /// <summary>
        /// Gets team with given ID.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        public async Task<GTeam> GetTeamAsync(GId id) =>
            JObject.Parse((await ExecuteRequest<object>(new Endpoint($"/teams/{id}", Method.GET))).Content)["team"].ToObject<GTeam>(GuildedSerializer);
        /// <summary>
        /// Gets team with given ID. Sync version of <see cref="GetTeamAsync"/>.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        public GTeam GetTeam(GId id) =>
            GetTeamAsync(id).GetAwaiter().GetResult();
        /// <summary>
        /// List of channels and categories in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        public async Task<GChannels> GetChannelsAsync(GId teamId) =>
            JsonConvert.DeserializeObject<GChannels>((await ExecuteRequest<object>(new Endpoint($"/teams/{teamId}/channels", Method.GET))).Content, Converters);
        /// <summary>
        /// List of channels and categories in given team. Sync version of <see cref="GetChannelsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        public GChannels GetChannels(GId teamId) =>
            GetChannelsAsync(teamId).GetAwaiter().GetResult();
        /// <summary>
        /// List of groups in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        public async Task<IList<GGroup>> GetGroupsAsync(GId teamId) =>
            JArray.Parse((await ExecuteRequest<object>(new Endpoint($"/teams/{teamId}/groups", Method.GET))).Content)["groups"].ToObject<IList<GGroup>>(GuildedSerializer);
        /// <summary>
        /// List of groups in given team. Sync version of <see cref="GetGroupsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        public IList<GGroup> GetGroups(GId teamId) =>
            GetGroupsAsync(teamId).GetAwaiter().GetResult();
        /// <summary>
        /// Gets message inside a specific channel.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        public async Task<GMessage> GetMessageAsync(Guid channelId, Guid messageId) =>
            JObject.Parse((await ExecuteRequest<object>(new Endpoint($"content/route/metadata?route=//channels/{channelId}/chat?messageId={messageId}", Method.GET))).Content)["metadata"]["message"].ToObject<GMessage>(GuildedSerializer);
        /// <summary>
        /// Gets message inside a specific channel. Sync version of <see cref="GetMessageAsync"/>.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        public GMessage GetMessage(Guid channelId, Guid messageId) =>
            GetMessageAsync(channelId, messageId).GetAwaiter().GetResult();
    }
}