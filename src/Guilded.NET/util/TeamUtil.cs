using Guilded.NET.Objects.Teams;
using Guilded.NET.Objects.Chat;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Guilded.NET.Util {
    /// <summary>
    /// Utilities for team related things.
    /// </summary>
    public static class TeamUtil {
        /// <summary>
        /// Sends a message to the specific channel.
        /// </summary>
        /// <param name="channel">Channel to send to</param>
        /// <param name="client">Client to send the message with</param>
        /// <param name="message">Message itself</param>
        public static async Task SendMessageAsync(this Channel channel, IGuildedClient client, NewMessage message) =>
            await client.SendMessageAsync(channel.Id, message);
        /// <summary>
        /// Sends a message to the specific channel. Sync version of <see cref="SendMessageAsync"/>.
        /// </summary>
        /// <param name="channel">Channel to send to</param>
        /// <param name="client">Client to send the message with</param>
        /// <param name="message">Message itself</param>
        public static void SendMessage(this Channel channel, IGuildedClient client, NewMessage message) =>
            client.SendMessage(channel.Id, message);
        /// <summary>
        /// Sends a message to the specific channel.
        /// </summary>
        /// <param name="channel">Channel to send to</param>
        /// <param name="client">Client to send the message with</param>
        /// <param name="message">Message itself</param>
        public static async Task<Message> GetMessageAsync(this Channel channel, IGuildedClient client, Guid messageId) =>
            await client.GetMessageAsync(channel.Id, messageId);
        /// <summary>
        /// Sends a message to the specific channel. Sync version of <see cref="GetMessageAsync"/>.
        /// </summary>
        /// <param name="channel">Channel to send to</param>
        /// <param name="client">Client to send the message with</param>
        /// <param name="message">Message itself</param>
        public static Message GetMessage(this Channel channel, IGuildedClient client, Guid messageId) =>
            client.GetMessage(channel.Id, messageId);
        /// <summary>
        /// Gets team channels.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get channels with</param>
        public static async Task<Channels> GetChannelsAsync(this Team team, IGuildedClient client) =>
            await client.GetChannelsAsync(team.Id);
        /// <summary>
        /// Gets team channels. Sync version of <see cref="GetChannelsAsync"/>.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get channels with</param>
        public static Channels GetChannels(this Team team, IGuildedClient client) =>
            client.GetChannels(team.Id);
        /// <summary>
        /// Gets team groups.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get groups with</param>
        public static async Task<IList<Group>> GetGroupsAsync(this Team team, IGuildedClient client) =>
            await client.GetGroupsAsync(team.Id);
        /// <summary>
        /// Gets team groups. Sync version of <see cref="GetGroupsAsync"/>.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get groups with</param>
        public static IList<Group> GetGroups(this Team team, IGuildedClient client) =>
            client.GetGroups(team.Id);
    }
}