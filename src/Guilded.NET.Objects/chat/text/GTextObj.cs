using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents text object which holds leaves.
    /// </summary>
    public class GTextObj: GBaseObject<GTextObj>, IMessageObject {
        /// <summary>
        /// Object type of the text object.
        /// </summary>
        /// <value>GMsgObject.Text</value>
        [JsonProperty("object", Required = Required.Always)]
        public GMsgObject Object {
            get; set;
        } = GMsgObject.Text;
        /// <summary>
        /// List of leaves in this text object.
        /// </summary>
        /// <value>List of leaves</value>
        [JsonProperty("leaves", Required = Required.Always)]
        public IList<GLeaf> Leaves {
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
        public static GTextObj GenerateText(params GLeaf[] leaves) =>
            new GTextObj {
                Leaves = leaves.ToList()
            };
    }
}