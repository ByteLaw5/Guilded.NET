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
        public static async Task SendMessageAsync(this GChannel channel, IGuildedClient client, GNewMessage message) =>
            await client.SendMessageAsync(channel.Id, message);
        /// <summary>
        /// Sends a message to the specific channel. Sync version of <see cref="SendMessageAsync"/>.
        /// </summary>
        /// <param name="channel">Channel to send to</param>
        /// <param name="client">Client to send the message with</param>
        /// <param name="message">Message itself</param>
        public static void SendMessage(this GChannel channel, IGuildedClient client, GNewMessage message) =>
            client.SendMessage(channel.Id, message);
        /// <summary>
        /// Sends a message to the specific channel.
        /// </summary>
        /// <param name="channel">Channel to send to</param>
        /// <param name="client">Client to send the message with</param>
        /// <param name="message">Message itself</param>
        public static async Task<GMessage> GetMessageAsync(this GChannel channel, IGuildedClient client, Guid messageId) =>
            await client.GetMessageAsync(channel.Id, messageId);
        /// <summary>
        /// Sends a message to the specific channel. Sync version of <see cref="GetMessageAsync"/>.
        /// </summary>
        /// <param name="channel">Channel to send to</param>
        /// <param name="client">Client to send the message with</param>
        /// <param name="message">Message itself</param>
        public static GMessage GetMessage(this GChannel channel, IGuildedClient client, Guid messageId) =>
            client.GetMessage(channel.Id, messageId);
        /// <summary>
        /// Gets team channels.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get channels with</param>
        public static async Task<GChannels> GetChannelsAsync(this GTeam team, IGuildedClient client) =>
            await client.GetChannelsAsync(team.Id);
        /// <summary>
        /// Gets team channels. Sync version of <see cref="GetChannelsAsync"/>.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get channels with</param>
        public static GChannels GetChannels(this GTeam team, IGuildedClient client) =>
            client.GetChannels(team.Id);
        /// <summary>
        /// Gets team groups.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get groups with</param>
        public static async Task<IList<GGroup>> GetGroupsAsync(this GTeam team, IGuildedClient client) =>
            await client.GetGroupsAsync(team.Id);
        /// <summary>
        /// Gets team groups. Sync version of <see cref="GetGroupsAsync"/>.
        /// </summary>
        /// <param name="team">Team itself</param>
        /// <param name="client">Client to get groups with</param>
        public static IList<GGroup> GetGroups(this GTeam team, IGuildedClient client) =>
            client.GetGroups(team.Id);
    }
}