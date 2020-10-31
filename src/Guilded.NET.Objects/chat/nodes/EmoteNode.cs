using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's emote node.
    /// </summary>
    public class EmoteNode: ContainerNode<IMessageObject> {
        public EmoteNode() {
            Object = MsgObject.Inline;
            Type = NodeType.Reaction;
        }
        [JsonIgnore]
        public uint EmoteId {
            get {
                if(Data == null) return 0;
                else if(!Data.ContainsKey("reaction")) return 0;
                // Get reaction data
                JObject obj = JObject.FromObject(Data["reaction"]);
                // Get ID
                return obj["id"].Value<uint>();
            }
        }
        /// <summary>
        /// Turns emote to string.
        /// </summary>
        /// <returns>Emote as a string</returns>
        public override string ToString() => $"<::>"; // TODO: Fix
        /// <summary>
        /// Generates emote node.
        /// </summary>
        /// <param name="id">ID of the emote</param>
        /// <returns>Emote node</returns>
        public static LinkNode Generate(uint id) =>
            new LinkNode {
                // Adds link to the link node
                Data = new Dictionary<string, object> {
                    {
                        "reaction", JObject.FromObject(new {
                            id = id,
                            customReactionId = id
                        })
                    }
                },
                // Emotes need nodes for some reason
                Nodes = new List<IMessageObject> {
                    new TextObj {
                        //Generates leaves, because emotes need to
                        Leaves = new List<Leaf> {
                           Leaf.Generate($":{id}:")
                        },
                        Object = MsgObject.Text
                    }
                }
            };
    }
}