using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Message embed data.
    /// </summary>
    public class GEmbed: GBaseObject<GEmbed> {
        /// <summary>
        /// Title of the embed.
        /// </summary>
        /// <value>Name</value>
        [JsonProperty("title")]
        public string Title {
            get; set;
        } = null;
        /// <summary>
        /// Description of the embed.
        /// </summary>
        /// <value></value>
        [JsonProperty("description")]
        public string Description {
            get; set;
        } = null;
        /// <summary>
        /// URL of the title.
        /// </summary>
        /// <value>URL</value>
        [JsonProperty("url")]
        public Uri Url {
            get; set;
        } = null;
        /// <summary>
        /// Colour of the embed.
        /// </summary>
        /// <value>Colour</value>
        [JsonProperty("color")]
        public uint? Color {
            get; set;
        } = null;
        /// <summary>
        /// Timestamp of the embed footer.
        /// </summary>
        /// <value>Date</value>
        [JsonProperty("timestamp")]
        public DateTime? Timestamp {
            get; set;
        } = null;
        /// <summary>
        /// Thumbnail of the embed.
        /// </summary>
        /// <value>Image</value>
        [JsonProperty("image")]
        public GEmbedImage Image {
            get; set;
        } = null;
        /// <summary>
        /// Image of the embed.
        /// </summary>
        /// <value>Image</value>
        [JsonProperty("thumbnail")]
        public GEmbedImage Thumbnail {
            get; set;
        } = null;
        /// <summary>
        /// Embed's footer.
        /// </summary>
        /// <value>Footer</value>
        [JsonProperty("footer")]
        public GEmbedFooter Footer {
            get; set;
        } = null;
        /// <summary>
        /// Author of the embed.
        /// </summary>
        /// <value>Author</value>
        [JsonProperty("author")]
        public GEmbedAuthor Author {
            get; set;
        } = null;
        /// <summary>
        /// List of fields in this embed.
        /// </summary>
        /// <value>List of fields</value>
        [JsonProperty("fields")]
        public IList<GEmbedField> Fields {
            get; set;
        } = null;
        /// <summary>
        /// Adds field to this embed.
        /// </summary>
        /// <param name="title">Title of the field</param>
        /// <param name="description">Description of the field</param>
        /// <param name="inline">If this field should be inline</param>
        /// <returns>This</returns>
        public GEmbed AddField(string title, string description, bool inline = false) => AddField(GEmbedField.Generate(title, description));
        /// <summary>
        /// Adds field to this embed.
        /// </summary>
        /// <param name="field">Field to be added</param>
        /// <returns>This</returns>
        public GEmbed AddField(GEmbedField field) {
            // If fields list is null
            if(Fields == null) Fields = new List<GEmbedField>() {
                field
            };
            else Fields.Add(field);
            // Returns this embed
            return this;
        }
        /// <summary>
        /// Adds fields to this embed.
        /// </summary>
        /// <param name="fields">Fields to be added</param>
        /// <returns>This</returns>
        public GEmbed AddFields(IEnumerable<GEmbedField> fields) {
            // If fields list is null
            if(Fields == null) Fields = fields.ToList();
            // Because for some reason, IList has no AddRange, where as List has AddRange.
            else foreach(GEmbedField field in fields) Fields.Add(field);
            // Returns this embed
            return this;
        }
        /// <summary>
        /// Adds fields to this embed.
        /// </summary>
        /// <param name="fields">Fields to be added</param>
        /// <returns>This</returns>
        public GEmbed AddFields(params GEmbedField[] fields) => AddFields(fields);
        /// <summary>
        /// Sets author to this embed.
        /// </summary>
        /// <param name="author">Author to be set to</param>
        /// <returns>This</returns>
        public GEmbed SetAuthor(GEmbedAuthor author) {
            Author = author;
            return this;
        }
        /// <summary>
        /// Sets author to this embed.
        /// </summary>
        /// <param name="name">Name of the author</param>
        /// <param name="iconUrl">URL of the image</param>
        /// <param name="url">URL of the author's name</param>
        /// <returns>This</returns>
        public GEmbed SetAuthor(string name, Uri iconUrl = null, Uri url = null) => SetAuthor(name, iconUrl, url);
        /// <summary>
        /// Sets embed's title name and URL.
        /// </summary>
        /// <param name="name">Name of the title</param>
        /// <param name="url">URL of the title</param>
        /// <returns>This</returns>
        public GEmbed SetTitle(string name, Uri url = null) {
            Title = name;
            Url = url;
            return this;
        }
        /// <summary>
        /// Sets description of the embed.
        /// </summary>
        /// <param name="description">Embed's description</param>
        /// <returns>This</returns>
        public GEmbed SetDescription(string description) {
            Description = description;
            return this;
        }
        /// <summary>
        /// Sets the image of the embed.
        /// </summary>
        /// <param name="url">URL to the image</param>
        /// <returns>This</returns>
        public GEmbed SetImage(Uri url) {
            Image = new GEmbedImage {
                Url = url
            };
            return this;
        }
        /// <summary>
        /// Sets the thumbnail of the embed.
        /// </summary>
        /// <param name="url">URL to the image</param>
        /// <returns>This</returns>
        public GEmbed SetThumbnail(Uri url) {
            Thumbnail = new GEmbedImage {
                Url = url
            };
            return this;
        }
        /// <summary>
        /// Sets timestamp of the embed.
        /// </summary>
        /// <param name="time">Date to be set to</param>
        /// <returns>This</returns>
        public GEmbed SetTimestamp(DateTime time) {
            Timestamp = time;
            return this;
        }
        /// <summary>
        /// Sets timestamp of the embed to current time.
        /// </summary>
        /// <returns>This</returns>
        public GEmbed SetTimestamp() => SetTimestamp(DateTime.Now);
        /// <summary>
        /// Sets colour to given colour.
        /// </summary>
        /// <example>
        /// <code>embed.SetColor(0xFFFFFF)</code>
        /// </example>
        /// <param name="color">Colour</param>
        /// <returns></returns>
        public GEmbed SetColor(uint color) {
            Color = color;
            return this;
        }
    }
}