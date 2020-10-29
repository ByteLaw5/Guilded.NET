using System;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Author of the embed.
    /// </summary>
    public class GEmbedAuthor: GBaseObject<GEmbedAuthor> {
        /// <summary>
        /// Author icon URL.
        /// </summary>
        /// <value>URL</value>
        [JsonProperty("iconUrl")]
        public Uri IconUrl {
            get; set;
        } = null;
        /// <summary>
        /// Title of the embed author.
        /// </summary>
        /// <value>Author</value>
        [JsonProperty("name", Required = Required.Always)]
        public string Name {
            get; set;
        } = null;
        /// <summary>
        /// URL of the author.
        /// </summary>
        /// <value>URL</value>
        [JsonProperty("url")]
        public Uri Url {
            get; set;
        } = null;
        /// <summary>
        /// Generates embed author.
        /// </summary>
        /// <param name="name">Name of the author</param>
        /// <returns>Author</returns>
        public static GEmbedAuthor Generate(string name) =>
            new GEmbedAuthor {
                Name = name
            };
        /// <summary>
        /// Generates embed author.
        /// </summary>
        /// <param name="name">Name of the author</param>
        /// <param name="image">Image of the icon</param>
        /// <returns>Author</returns>
        public static GEmbedAuthor Generate(string name, Uri image) =>
            new GEmbedAuthor {
                Name = name,
                IconUrl = image
            };
        /// <summary>
        /// Generates embed author.
        /// </summary>
        /// <param name="name">Name of the author</param>
        /// <param name="image">Image of the icon</param>
        /// <param name="url">URL of the author</param>
        /// <returns>Author</returns>
        public static GEmbedAuthor Generate(string name, Uri image, Uri url) =>
            new GEmbedAuthor {
                Name = name,
                IconUrl = image,
                Url = url
            };
    }
}