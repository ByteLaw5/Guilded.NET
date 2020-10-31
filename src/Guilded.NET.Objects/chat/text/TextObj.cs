using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents text object which holds leaves.
    /// </summary>
    public class TextObj: BaseObject<TextObj>, IMessageObject {
        /// <summary>
        /// Object type of the text object.
        /// </summary>
        /// <value>MsgObject.Text</value>
        [JsonProperty("object", Required = Required.Always)]
        public MsgObject Object {
            get; set;
        } = MsgObject.Text;
        /// <summary>
        /// List of leaves in this text object.
        /// </summary>
        /// <value>List of leaves</value>
        [JsonProperty("leaves", Required = Required.Always)]
        public IList<Leaf> Leaves {
            get; set;
        }
        /// <summary>
        /// Data of the text object. Used by links only.
        /// </summary>
        /// <value>Node data</value>
        [JsonProperty("data")]
        public IDictionary<string, object> Data {
            get; set;
        } = null;
        /// <summary>
        /// Generates normal text object.
        /// </summary>
        /// <param name="leaves">List of leaves</param>
        /// <returns>Text object</returns>
        public static TextObj GenerateText(params Leaf[] leaves) =>
            new TextObj {
                Leaves = leaves.ToList()
            };
        /// <summary>
        /// Turns text object to string.
        /// </summary>
        /// <returns>Text object as a string</returns>
        public override string ToString() => string.Concat(Leaves);
    }
}