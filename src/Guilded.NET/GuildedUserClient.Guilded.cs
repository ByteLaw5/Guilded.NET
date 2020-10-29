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
            // Creates addables
            List<IReqAddable> addables = LoginCookies.Select(x => (IReqAddable)new GCookie(x.Name, x.Value)).ToList();
            addables.Add(new GJsonBody(JsonConvert.SerializeObject(message, Converters)));
            // Execute it
            return await ExecuteRequest<object>(new Endpoint($"channels/{channel}/messages", Method.POST), addables.ToArray());
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
        /// <summary>
        /// Changes the name of the user.
        /// </summary>
        /// <param name="name">New name</param>
        /// <returns>Async task</returns>
        public async Task ChangeNameAsync(string name) {
            // Creates addables
            List<IReqAddable> addables = LoginCookies.Select(x => (IReqAddable)new GCookie(x.Name, x.Value)).ToList();
            addables.Add(new GJsonBody($"{{\"name\": \"{name}\"}}"));
            // Executes it
            await ExecuteRequest<object>(new Endpoint($"/users/{CurrentUser.Id}/profilev2", Method.POST), addables.ToArray());
        }
        /// <summary>
        /// Changes the name of the user. Sync version of <see cref="ChangeNameAsync"/>.
        /// </summary>
        /// <param name="name">New name</param>
        public void ChangeName(string name) => ChangeNameAsync(name).GetAwaiter().GetResult();
        /// <summary>
        /// Clears all notifications in a specific channel.
        /// </summary>
        /// <param name="channelId">ID of the channel to clear notifications in</param>
        /// <returns>Async task</returns>
        public async Task ClearNotificationsAsync(Guid channelId) =>
            await ExecuteRequest<object>(new Endpoint($"/channels/{channelId}/seen", Method.POST));
        /// <summary>
        /// Clears all notifications in a specific channel. Sync version of <see cref="ClearNotificationsAsync"/>.
        /// </summary>
        /// <param name="channelId">ID of the channel to clear notifications in</param>
        public void ClearNotifications(Guid channelId) =>
            ClearNotificationsAsync(channelId).GetAwaiter().GetResult();
        /// <summary>
        /// Accepts an invite.
        /// </summary>
        /// <param name="id">ID of the invite to accept</param>
        /// <returns>Async task</returns>
        public async Task AcceptInviteAsync(GId id) =>
            await ExecuteRequest<object>(new Endpoint($"/invites/{id}", Method.POST), new GJsonBody("{\"type\": \"consume\"}"));
        /// <summary>
        /// Accepts an invite.
        /// </summary>
        /// <param name="id">ID of the invite to accept</param>
        public void AcceptInvite(GId id) =>
            AcceptInviteAsync(id).GetAwaiter().GetResult();
        
    }
}