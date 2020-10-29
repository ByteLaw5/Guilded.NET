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
        event EventHandler<GMessageCreatedEvent> MessageCreated;
        /// <summary>
        /// Event when someone starts typing in the chat.
        /// </summary>
        event EventHandler<GUserTypingEvent> UserTyping;
        /// <summary>
        /// Sends a message into the chat.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message to post</param>
        /// <returns>Response</returns>
        Task<object> SendMessageAsync(Guid channel, GNewMessage message);
        /// <summary>
        /// Sends a message into the chat. Sync version of <see cref="SendMessageAsync"/>.
        /// </summary>
        /// <param name="channel">ID of the channel</param>
        /// <param name="message">Message to post</param>
        void SendMessage(Guid channel, GNewMessage message);
        /// <summary>
        /// Gets user this client is using.
        /// </summary>
        /// <returns>Current User</returns>
        Task<GMe> GetThisUserAsync();
        /// <summary>
        /// Gets user this client is using. Sync version of <see cref="GetThisUserAsync"/>.
        /// </summary>
        /// <returns>Current User</returns>
        GMe GetThisUser();
        /// <summary>
        /// Gets user with given ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        Task<GUser> GetUserAsync(GId id);
        /// <summary>
        /// Gets user with given ID. Sync version of <see cref="GetUserAsync"/>.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User</returns>
        GUser GetUser(GId id);
        /// <summary>
        /// Gets team with given ID.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        Task<GTeam> GetTeamAsync(GId id);
        /// <summary>
        /// Gets team with given ID. Sync version of <see cref="GetTeamAsync"/>.
        /// </summary>
        /// <param name="id">Team ID</param>
        /// <returns>Team</returns>
        GTeam GetTeam(GId id);
        /// <summary>
        /// List of channels and categories in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        Task<GChannels> GetChannelsAsync(GId teamId);
        /// <summary>
        /// List of channels and categories in given team. Sync version of <see cref="GetChannelsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Channel list</returns>
        GChannels GetChannels(GId teamId);
        /// <summary>
        /// List of groups in given team.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        Task<IList<GGroup>> GetGroupsAsync(GId teamId);
        /// <summary>
        /// List of groups in given team. Sync version of <see cref="GetGroupsAsync"/>.
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>List of groups</returns>
        IList<GGroup> GetGroups(GId teamId);
        /// <summary>
        /// Gets message inside a specific channel.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        Task<GMessage> GetMessageAsync(Guid channelId, Guid messageId);
        /// <summary>
        /// Gets message inside a specific channel. Sync version of <see cref="GetMessageAsync"/>.
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="messageId">ID of the message</param>
        /// <returns>Message</returns>
        GMessage GetMessage(Guid channelId, Guid messageId);
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
    }
}