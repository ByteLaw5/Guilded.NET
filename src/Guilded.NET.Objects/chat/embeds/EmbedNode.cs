using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Node containing embeds. A.k.a. webhook message in Guilded.
    /// </summary>
    public class EmbedNode: ContainerNode<IMessageObject> {
        public EmbedNode() {
            Type = NodeType.Embed;
            Object = MsgObject.Block;
        }
        /// <summary>
        /// List of embeds in this embed node.
        /// </summary>
        /// <value>List of embeds</value>
        [JsonIgnore]
        public IList<Embed> Embeds {
            get {
                if(Data == null) return null;
                else if(!Data.ContainsKey("embeds")) return null;
                // Embed data
                object obj = Data["embeds"];
                if(obj is IList<Embed> list) return list;
                else if(obj is JArray arr) return arr.ToObject<IList<Embed>>();
                else return null;
            }
        }
        /// <summary>
        /// Generates embed node from given embed data.
        /// </summary>
        /// <param name="embed">Embed data</param>
        /// <returns>Embed node</returns>
        public static EmbedNode Generate(Embed embed) =>
            new EmbedNode {
                Data = new Dictionary<string, object> {
                    {
                        "embeds", new List<Embed> {
                            embed
                        }
                    }
                }
            };
        /// <summary>
        /// Turns embed to string.
        /// </summary>
        /// <returns>Embed as string</returns>
        public override string ToString() => "[Embeds: ToString not supported]";
    }
}