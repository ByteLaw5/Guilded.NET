using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Node containing embeds. A.k.a. webhook message in Guilded.
    /// </summary>
    public class GEmbedNode: GContainerNode<IMessageObject> {
        public GEmbedNode() {
            Type = GNodeType.Embed;
            Object = GMsgObject.Block;
        }
        /// <summary>
        /// List of embeds in this embed node.
        /// </summary>
        /// <value>List of embeds</value>
        [JsonIgnore]
        public IList<GEmbed> Embeds {
            get {
                if(!Data.ContainsKey("embeds")) return null;
                // Embed data
                object obj = Data["embeds"];
                // If object is JArray,
                // Turn it to list of embeds and return it
                if(obj is JArray arr) return arr.ToObject<IList<GEmbed>>();
                // Else return null
                return null;
            }
        }
        /// <summary>
        /// Generates embed node from given embed data.
        /// </summary>
        /// <param name="embed">Embed data</param>
        /// <returns>Embed node</returns>
        public static GEmbedNode Generate(GEmbed embed) =>
            new GEmbedNode {
                Data = new Dictionary<string, object> {
                    {
                        "embeds", new List<GEmbed> {
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