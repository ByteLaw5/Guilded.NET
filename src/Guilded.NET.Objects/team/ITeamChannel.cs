using System.Collections.Generic;
using System;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Interface for team channels and categories.
    /// </summary>
    public interface ITeamChannel {
        /// <summary>
        /// Priority of this channel.
        /// </summary>
        /// <value>Priority</value>
        uint? Priority {
            get; set;
        }
        /// <summary>
        /// Name of this channel.
        /// </summary>
        /// <value>Name</value>
        string Name {
            get; set;
        }
        /// <summary>
        /// Permissions of the roles in this channel.
        /// </summary>
        /// <value>Role Permissions</value>
        Dictionary<uint, GChannelPermission> RolePermissions {
            get; set;
        }
        /// <summary>
        /// Permissions of the users in this channel.
        /// </summary>
        /// <value>User Permissions</value>
        Dictionary<uint, GUserPermission> UserPermissions {
            get; set;
        }
        /// <summary>
        /// ID of team this channel is in.
        /// </summary>
        /// <value>Team ID</value>
        GId TeamId {
            get; set;
        }
        /// <summary>
        /// ID of the category this channel is in.
        /// </summary>
        /// <value>Nullable Channel ID</value>
        uint? ChannelCategoryId {
            get; set;
        }
        /// <summary>
        /// ID of the group this channel is in.
        /// </summary>
        /// <value>Group ID</value>
        GId GroupId {
            get; set;
        }
        /// <summary>
        /// When the channel was created.
        /// </summary>
        /// <value>Date</value>
        DateTime CreatedAt {
            get; set;
        }
        /// <summary>
        /// When the channel was updated.
        /// </summary>
        /// <value>Date</value>
        DateTime? UpdatedAt {
            get; set;
        }
    }
}