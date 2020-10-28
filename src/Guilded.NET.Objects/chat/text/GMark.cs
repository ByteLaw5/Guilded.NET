using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents markdown marks.
    /// </summary>
    public class GMark: GBaseObject<GMark>, IMessageObject {
        internal static Dictionary<GMarkType, string> MarkSymbols = new Dictionary<GMarkType, string>() {
            { GMarkType.Bold, "**" },
            { GMarkType.InlineCode, "`" },
            { GMarkType.Italic, "*" },
            { GMarkType.Spoiler, "||" },
            { GMarkType.Strikethrough, "~~" },
            { GMarkType.Underline, "__" }
        };
        /// <summary>
        /// Object of the mark.
        /// </summary>
        /// <value>GMsgObject.Mark</value>
        public GMsgObject Object {
            get; set;
        } = GMsgObject.Mark;
        /// <summary>
        /// Type of the markdown.
        /// </summary>
        /// <value>Markdown type</value>
        [JsonProperty("type", Required = Required.Always)]
        public GMarkType Type {
            get; set;
        }
        /// <summary>
        /// Data of the mark.
        /// </summary>
        /// <value>Mark data</value>
        [JsonProperty("data")]
        public IDictionary<string, object> Data {
            get; set;
        } = null;
    }
}