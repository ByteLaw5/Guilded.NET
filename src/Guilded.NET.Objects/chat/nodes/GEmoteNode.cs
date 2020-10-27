using System.Collections.Generic;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's emote node.
    /// </summary>
    public class GEmoteNode: GContainerNode<IMessageObject> {
        public GEmoteNode() {
            Object = GMsgObject.Inline;
            Type = GNodeType.Reaction;
        }
        /// <summary>
        /// Generates emote node.
        /// </summary>
        /// <param name="id">ID of the emote</param>
        /// <returns>Emote node</returns>
        public static GLinkNode Generate(uint id) =>
            new GLinkNode {
                // Adds link to the link node
                Data = new Dictionary<string, object>() {
                    {
                        "reaction", new {
                            id = id,
                            customReactionId = id
                        }
                    }
                },
                // Emotes need nodes for some reason
                Nodes = new List<IMessageObject>() {
                    new GTextObj {
                        //Generates leaves, because emotes need to
                        Leaves = new List<GLeaf>() {
                           GLeaf.Generate($":{id}:")
                        },
                        Object = GMsgObject.Text
                    }
                }
            };
    }
}