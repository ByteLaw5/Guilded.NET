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
    using Objects.Converters;
    public partial class GuildedUserClient: BasicGuildedClient, IGuildedClient {
        /// <summary>
        /// Gets user this client is using.
        /// </summary>
        /// <returns>Task[Current User]</returns>
        public async Task<Me> GetThisUserAsync() =>
            JsonConvert.DeserializeObject<Me>((await ExecuteRequest<object>(Endpoint.ME)).Content, Converters);
        /// <summary>
        /// Gets user this client is using. Sync version of <see cref="GetThisUserAsync"/>.
        /// </summary>
        /// <returns>Current User</returns>
        public Me GetThisUser() =>
            GetThisUserAsync().GetAwaiter().GetResult();
        /// <summary>
        /// Sends a message to the specific channel.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message</param>
        /// <returns>Async task</returns>
        public async Task<object> SendMessageAsync(Guid channel, NewMessage message) {
            // Creates addables
            List<IReqAddable> addables = LoginCookies.Select(x => (IReqAddable)new GuildedCookie(x.Name, x.Value)).ToList();
            addables.Add(new JsonBody(JsonConvert.SerializeObject(message, Converters)));
            // Execute it
            return await ExecuteRequest<object>(new Endpoint($"channels/{channel}/messages", Method.POST), addables.ToArray());
        }
        /// <summary>
        /// Sends a message into the chat. Sync version of <see cref="SendMessageAsync"/>.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message to post</param>
        public void SendMessage(Guid channel, NewMessage message) =>
            SendMessageAsync(channel, message).GetAwaiter().GetResult();
        /// <summary>
        /// Gets user with given ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        public async Task<User> GetUserAsync(GId id) =>
            JObject.Parse((await ExecuteRequest<object>(new Endpoint($"/users/{id}", Method.GET))).Content)["user"].ToObject<User>(GuildedSerializer);
        /// <summary>
        /// Gets user with given ID. Sync version of <see cref="GetUserAsync"/>.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        public User GetUser(GId id) =>
            GetUserAsync(id).GetAwaiter().GetResult();
        /// <summary>
        /// Gets team with given ID.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        public async Task<Team> GetTeamAsync(GId id) =>
            JObject.Parse((await ExecuteRequest<object>(new Endpoint($"/teams/{id}", Method.GET))).Content)["team"].ToObject<Team>(GuildedSerializer);
        /// <summary>
        /// Gets team with given ID. Sync version of <see cref="GetTeamAsync"/>.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        public Team GetTeam(GId id) =>
            GetTeamAsync(id).GetAwaiter().GetResult();
        /// <summary>
        /// List of channels and categories in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        public async Task<Channels> GetChannelsAsync(GId teamId) =>
            JsonConvert.DeserializeObject<Channels>((await ExecuteRequest<object>(new Endpoint($"/teams/{teamId}/channels", Method.GET))).Content, Converters);
        /// <summary>
        /// List of channels and categories in given team. Sync version of <see cref="GetChannelsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        public Channels GetChannels(GId teamId) =>
            GetChannelsAsync(teamId).GetAwaiter().GetResult();
        /// <summary>
        /// List of groups in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        public async Task<IList<Group>> GetGroupsAsync(GId teamId) =>
            JArray.Parse((await ExecuteRequest<object>(new Endpoint($"/teams/{teamId}/groups", Method.GET))).Content)["groups"].ToObject<IList<Group>>(GuildedSerializer);
        /// <summary>
        /// List of groups in given team. Sync version of <see cref="GetGroupsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        public IList<Group> GetGroups(GId teamId) =>
            GetGroupsAsync(teamId).GetAwaiter().GetResult();
        /// <summary>
        /// Gets message inside a specific channel.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        public async Task<Message> GetMessageAsync(Guid channelId, Guid messageId) {
            // Get messages
            IRestResponse<object> response = await ExecuteRequest<object>(new Endpoint($"content/route/metadata?route=//channels/{channelId}/chat?messageId={messageId}", Method.GET));
            // Parse the content and get message itself
            return JObject.Parse(response.Content)["metadata"]["message"].ToObject<Message>(GuildedSerializer);
        }
        /// <summary>
        /// Gets message inside a specific channel. Sync version of <see cref="GetMessageAsync"/>.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        public Message GetMessage(Guid channelId, Guid messageId) =>
            GetMessageAsync(channelId, messageId).GetAwaiter().GetResult();
        /// <summary>
        /// Changes the name of the user.
        /// </summary>
        /// <param name="name">New name</param>
        /// <returns>Async task</returns>
        public async Task ChangeNameAsync(string name) {
            // Creates addables
            List<IReqAddable> addables = LoginCookies.Select(x => (IReqAddable)new GuildedCookie(x.Name, x.Value)).ToList();
            addables.Add(new JsonBody($"{{\"name\": \"{name}\"}}"));
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
            await ExecuteRequest<object>(new Endpoint($"/invites/{id}", Method.POST), new JsonBody("{\"type\": \"consume\"}"));
        /// <summary>
        /// Accepts an invite.
        /// </summary>
        /// <param name="id">ID of the invite to accept</param>
        public void AcceptInvite(GId id) =>
            AcceptInviteAsync(id).GetAwaiter().GetResult();
        /// <summary>
        /// Creates a new channel in a specific team and group.
        /// </summary>
        /// <param name="team">Team to create channel in</param>
        /// <param name="group">Group to create channel in</param>
        /// <param name="type">Channel type</param>
        /// <param name="public">If channel should be public</param>
        /// <returns>Async task</returns>
        public async Task CreateChannelAsync(GId team, GId group, ChannelType type, bool @public, string name) =>
            await ExecuteRequest<object>(new Endpoint($"teams/{team}/groups/{group}/channels", Method.POST), new JsonBody($"{{\"name\": {name}, \"contentType\": {EnumConverter.ConvertTo(type, type.GetType())}, \"isPublic\": {@public}}}"));
        /// <summary>
        /// Creates a new channel in a specific team and group. Sync version of <see cref="CreateChannelAsync"/>.
        /// </summary>
        /// <param name="team">Team to create channel in</param>
        /// <param name="group">Group to create channel in</param>
        /// <param name="type">Channel type</param>
        /// <param name="public">If channel should be public</param>
        public void CreateChannel(GId team, GId group, ChannelType type, bool @public, string name) =>
            CreateChannelAsync(team, group, type, @public, name).GetAwaiter().GetResult();
                /// <summary>
        /// Deletes a channel in a specific team and group.
        /// </summary>
        /// <param name="team">Team to delete channel in</param>
        /// <param name="group">Group to delete channel in</param>
        /// <param name="channel">Channel to be deleted</param>
        /// <returns>Async task</returns>
        public async Task DeleteChannelAsync(GId team, GId group, Guid channel) =>
            await ExecuteRequest<object>(new Endpoint($"teams/{team}/groups/{group}/channels/{channel}", Method.DELETE));
        /// <summary>
        /// Deletes a channel in a specific team and group. Sync version of <see cref="DeleteChannelAsync"/>.
        /// </summary>
        /// <param name="team">Team to delete channel in</param>
        /// <param name="group">Group to delete channel in</param>
        /// <param name="channel">Channel to be deleted</param>
        public void DeleteChannel(GId team, GId group, Guid channel) =>
            DeleteChannelAsync(team, group, channel).GetAwaiter().GetResult();
        /// <summary>
        /// Gets messages with a specific limit.
        /// </summary>
        /// <param name="channel">Channel to get messages in</param>
        /// <param name="limit">How many messages it should get</param>
        /// <returns>List of messages</returns>
        public async Task<IList<Message>> GetMessagesAsync(Guid channel, uint limit) {
            // Get response
            IRestResponse<object> response = await ExecuteRequest<object>(new Endpoint($"channels/{channel}/messages?limit={limit}", Method.GET));
            // Parse the object and get list of the messages
            return JObject.Parse(response.Content)["messages"].ToObject<IList<Message>>();
        }
        /// <summary>
        /// Gets messages with a specific limit.
        /// </summary>
        /// <param name="channel">Channel to get messages in</param>
        /// <param name="limit">How many messages it should get</param>
        /// <returns>List of messages</returns>
        public IList<Message> GetMessages(Guid channel, uint limit) =>
            GetMessagesAsync(channel, limit).GetAwaiter().GetResult();
        /// <summary>
        /// Joins a specific team.
        /// </summary>
        /// <param name="team">Team to join</param>
        /// <returns>Async task</returns>
        public async Task JoinTeamAsync(GId team) =>
            await ExecuteRequest<object>(new Endpoint($"teams/{team}/members/{CurrentUser.Id}/join", Method.PUT), new JsonBody("{}"));
        /// <summary>
        /// Joins a specific team. Sync version of <see cref="JoinTeamAsync"/>.
        /// </summary>
        /// <param name="team">Team to join</param>
        public void JoinTeam(GId team) =>
            JoinTeamAsync(team).GetAwaiter().GetResult();
        /// <summary>
        /// Leaves a specific team.
        /// </summary>
        /// <param name="team">Team to leave</param>
        /// <returns>Async task</returns>
        public async Task LeaveTeamAsync(GId team) =>
            await ExecuteRequest<object>(new Endpoint($"teams/{team}/members/{CurrentUser.Id}", Method.DELETE));
        /// <summary>
        /// Leaves a specific team. Sync version of <see cref="JoinTeamAsync"/>.
        /// </summary>
        /// <param name="team">Team to leave</param>
        public void LeaveTeam(GId team) =>
            LeaveTeamAsync(team).GetAwaiter().GetResult();
    }
}