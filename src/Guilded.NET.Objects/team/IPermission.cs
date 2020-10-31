using System;

namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Interface for user and role permissions.
    /// </summary>
    public interface IPermission {
        /// <summary>
        /// ID of the channel this permission is in.
        /// </summary>
        /// <value>Channel ID</value>
        Guid ChannelId {
            get; set;
        }
        /// <summary>
        /// Date when this permission was created.
        /// </summary>
        /// <value>Date</value>
        DateTime CreatedAt {
            get; set;
        }
        /// <summary>
        /// Date when this permission was last updated.
        /// </summary>
        /// <value>Nullable date</value>
        DateTime? UpdatedAt {
            get; set;
        }
        /// <summary>
        /// Denied permissions.
        /// </summary>
        /// <value>Permissions</value>
        Permissions DenyPermissions {
            get; set;
        }
        /// <summary>
        /// Allowed permissions.
        /// </summary>
        /// <value>Permissions</value>
        Permissions AllowPermissions {
            get; set;
        }
    }
}