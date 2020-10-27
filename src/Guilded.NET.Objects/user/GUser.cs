using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace Guilded.NET.Objects {
    /// <summary>
    /// Guilded user. This is NOT Guild member.
    /// </summary>
    public class GUser: GBaseObject<GUser> {
        /// <summary>
        /// Given ID of the user.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public GId Id {
            get; set;
        }
        /// <summary>
        /// Current name of the user.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Username {
            get; set;
        }
        /// <summary>
        /// Large version of profile picture.
        /// </summary>
        [JsonProperty("profilePictureLg")]
        public string AvatarLarge {
            get; set;
        }
        /// <summary>
        /// User's current profile picture.
        /// </summary>
        [JsonProperty("profilePicture")]
        public string Avatar {
            get; set;
        }
        /// <summary>
        /// Small version of profile picture.
        /// </summary>
        [JsonProperty("profilePictureSm")]
        public string AvatarSmall {
            get; set;
        }
        /// <summary>
        /// Blurry version of profile picture.
        /// </summary>
        [JsonProperty("profilePictureBlur")]
        public string AvatarBlurry {
            get; set;
        }
        /// <summary>
        /// Large version of profile banner.
        /// </summary>
        [JsonProperty("profileBannerLg")]
        public string BannerLarge {
            get; set;
        }
        /// <summary>
        /// Small version of profile banner.
        /// </summary>
        [JsonProperty("profileBannerSm")]
        public string BannerSmall {
            get; set;
        }
        /// <summary>
        /// Blurry version of profile banner.
        /// </summary>
        [JsonProperty("profileBannerBlur")]
        public string BannerBlurry {
            get; set;
        }
        /// <summary>
        /// User's steam ID.
        /// </summary>
        [JsonProperty("steamId")]
        public string SteamID {
            get; set;
        }
        /// <summary>
        /// Moderation status of the user.
        /// </summary>
        [JsonProperty("moderationStatus")]
        public string ModerationStatus {
            get; set;
        }
        /// <summary>
        /// User's profile <strong>about</strong> section.
        /// </summary>
        [JsonProperty("aboutInfo")]
        public GAbout About {
            get; set;
        }
        /// <summary>
        /// Date of last time user was online.
        /// </summary>
        [JsonProperty("lastOnline")]
        public DateTime LastOnline {
            get; set;
        }
        /// <summary>
        /// Date of user's registration.
        /// </summary>
        [JsonProperty("joinDate")]
        public DateTime JoinDate {
            get; set;
        }
    }
}