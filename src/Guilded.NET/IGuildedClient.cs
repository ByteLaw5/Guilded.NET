using Guilded.NET.Objects.Events;
using System;
using Guilded.NET.Objects.Chat;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Guilded.NET {
    using Objects;
    using Objects.Teams;
    /// <summary>
    /// Represents any Guilded client.
    /// </summary>
    public interface IGuildedClient {
        /// <summary>
        /// Event when someone posts a message in the chat.
        /// </summary>
        event EventHandler<MessageCreatedEvent> MessageCreated;
        /// <summary>
        /// Event when someone starts typing in the chat.
        /// </summary>
        event EventHandler<UserTypingEvent> UserTyping;
        /// <summary>
        /// Sends a message into the chat.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message to post</param>
        /// <returns>Response</returns>
        Task<object> SendMessageAsync(Guid channel, NewMessage message);
        /// <summary>
        /// Sends a message into the chat. Sync version of <see cref="SendMessageAsync"/>.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message to post</param>
        void SendMessage(Guid channel, NewMessage message);
        /// <summary>
        /// Gets user this client is using.
        /// </summary>
        /// <returns>Current User</returns>
        Task<Me> GetThisUserAsync();
        /// <summary>
        /// Gets user this client is using. Sync version of <see cref="GetThisUserAsync"/>.
        /// </summary>
        /// <returns>Current User</returns>
        Me GetThisUser();
        /// <summary>
        /// Gets user with given ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        Task<User> GetUserAsync(GId id);
        /// <summary>
        /// Gets user with given ID. Sync version of <see cref="GetUserAsync"/>.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        User GetUser(GId id);
        /// <summary>
        /// Gets team with given ID.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        Task<Team> GetTeamAsync(GId id);
        /// <summary>
        /// Gets team with given ID. Sync version of <see cref="GetTeamAsync"/>.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        Team GetTeam(GId id);
        /// <summary>
        /// List of channels and categories in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        Task<Channels> GetChannelsAsync(GId teamId);
        /// <summary>
        /// List of channels and categories in given team. Sync version of <see cref="GetChannelsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        Channels GetChannels(GId teamId);
        /// <summary>
        /// List of groups in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        Task<IList<Group>> GetGroupsAsync(GId teamId);
        /// <summary>
        /// List of groups in given team. Sync version of <see cref="GetGroupsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        IList<Group> GetGroups(GId teamId);
        /// <summary>
        /// Gets message inside a specific channel.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        Task<Message> GetMessageAsync(Guid channelId, Guid messageId);
        /// <summary>
        /// Gets message inside a specific channel. Sync version of <see cref="GetMessageAsync"/>.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        Message GetMessage(Guid channelId, Guid messageId);
        /// <summary>
        /// Changes the name of the user.
        /// </summary>
        /// <param name="name">New name</param>
        /// <returns>Async task</returns>
        Task ChangeNameAsync(string name);
        /// <summary>
        /// Changes the name of the user. Sync version of <see cref="ChangeNameAsync"/>.
        /// </summary>
        /// <param name="name">New name</param>
        void ChangeName(string name);
        /// <summary>
        /// Clears all notifications in a specific channel.
        /// </summary>
        /// <param name="channelId">ID of the channel to clear notifications in</param>
        /// <returns>Async task</returns>
        Task ClearNotificationsAsync(Guid channelId);
        /// <summary>
        /// Clears all notifications in a specific channel. Sync version of <see cref="ClearNotificationsAsync"/>.
        /// </summary>
        /// <param name="channelId">ID of the channel to clear notifications in</param>
        void ClearNotifications(Guid channelId);
        /// <summary>
        /// Creates a new channel in a specific team and group.
        /// </summary>
        /// <param name="team">Team to create channel in</param>
        /// <param name="group">Group to create channel in</param>
        /// <param name="type">Channel type</param>
        /// <param name="public">If channel should be public</param>
        /// <param name="name">Name of the channel</param>
        /// <returns>Async task</returns>
        Task CreateChannelAsync(GId team, GId group, ChannelType type, bool @public, string name);
        /// <summary>
        /// Creates a new channel in a specific team and group. Sync version of <see cref="CreateChannelAsync"/>.
        /// </summary>
        /// <param name="team">Team to create channel in</param>
        /// <param name="group">Group to create channel in</param>
        /// <param name="type">Channel type</param>
        /// <param name="public">If channel should be public</param>
        /// <param name="name">Name of the channel</param>
        void CreateChannel(GId team, GId group, ChannelType type, bool @public, string name);
        /// <summary>
        /// Deletes a channel in a specific team and group.
        /// </summary>
        /// <param name="team">Team to delete channel in</param>
        /// <param name="group">Group to delete channel in</param>
        /// <param name="channel">Channel to be deleted</param>
        /// <returns>Async task</returns>
        Task DeleteChannelAsync(GId team, GId group, Guid channel);
        /// <summary>
        /// Deletes a channel in a specific team and group. Sync version of <see cref="DeleteChannelAsync"/>.
        /// </summary>
        /// <param name="team">Team to delete channel in</param>
        /// <param name="group">Group to delete channel in</param>
        /// <param name="channel">Channel to be deleted</param>
        void DeleteChannel(GId team, GId group, Guid channel);
        /// <summary>
        /// Gets messages with a specific limit.
        /// </summary>
        /// <param name="channel">Channel to get messages in</param>
        /// <param name="limit">How many messages it should get</param>
        /// <returns>List of messages</returns>
        Task<IList<Message>> GetMessagesAsync(Guid channel, uint limit);
        /// <summary>
        /// Gets messages with a specific limit.
        /// </summary>
        /// <param name="channel">Channel to get messages in</param>
        /// <param name="limit">How many messages it should get</param>
        /// <returns>List of messages</returns>
        IList<Message> GetMessages(Guid channel, uint limit);
        /// <summary>
        /// Joins a specific team.
        /// </summary>
        /// <param name="team">Team to join</param>
        /// <returns>Async task</returns>
        Task JoinTeamAsync(GId team);
        /// <summary>
        /// Joins a specific team. Sync version of <see cref="JoinTeamAsync"/>.
        /// </summary>
        /// <param name="team">Team to join</param>
        void JoinTeam(GId team);
        /// <summary>
        /// Leaves a specific team.
        /// </summary>
        /// <param name="team">Team to leave</param>
        /// <returns>Async task</returns>
        Task LeaveTeamAsync(GId team);
        /// <summary>
        /// Leaves a specific team. Sync version of <see cref="JoinTeamAsync"/>.
        /// </summary>
        /// <param name="team">Team to leave</param>
        void LeaveTeam(GId team);
    }
}