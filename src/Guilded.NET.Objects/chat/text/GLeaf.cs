using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents text leaf in Guilded messages.
    /// </summary>
    public class GLeaf: GBaseObject<GLeaf>, IMessageObject {
        /// <summary>
        /// Object type of the leaf.
        /// </summary>
        /// <value>GMsgObject.Leaf</value>
        [JsonProperty("object", Required = Required.Always)]
        public GMsgObject Object {
            get; set;
        } = GMsgObject.Leaf;
        /// <summary>
        /// Piece of text in this leaf.
        /// </summary>
        /// <value></value>
        [JsonProperty("text", Required = Required.Always)]
        public string Text {
            get; set;
        }
        /// <summary>
        /// List of markdown marks in this leaf.
        /// </summary>
        /// <value>List of marks</value>
        [JsonProperty("marks")]
        public IList<GMark> Marks {
            get; set;
        } = null;
        /// <summary>
        /// Generates leaf from given text and marks.
        /// </summary>
        /// <param name="text">Text of the leaf</param>
        /// <param name="marks">Markdown marks</param>
        /// <returns>Message leaf</returns>
        public static GLeaf Generate(string text, params GMarkType[] marks) =>
            new GLeaf {
                Text = text,
                // From given mark types, generate marks themselves
                Marks = marks.Select(x => new GMark {
                    Type = x,
                    Data = new Dictionary<string, object>()
                }).ToList()
            };
    }
}