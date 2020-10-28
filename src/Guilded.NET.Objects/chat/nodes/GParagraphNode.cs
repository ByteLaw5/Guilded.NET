using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's paragraph node.
    /// </summary>
    public class GParagraphNode: GContainerNode<IMessageObject> {
        public GParagraphNode() {
            Object = GMsgObject.Block;
            Type = GNodeType.Paragraph;
        }
        /// <summary>
        /// Gets all leaves in paragraph.
        /// </summary>
        /// <value>List of paragraph leaves</value>
        [JsonIgnore]
        public IEnumerable<GLeaf> Leaves {
            get =>
                // Get all text objects and link nodes, because others shouldn't be there
                Nodes.Where(x => !(x is GTextObj) && !(x is GLinkNode)).Select(x =>
                    x is GLinkNode xl
                    // Get all leaves in link node
                    ? xl.Nodes.Select(y =>
                        y is GTextObj yt
                        ? yt.Leaves
                        : new List<GLeaf>()
                    // Flatten the list
                    ).SelectMany(x => x)
                    // Else, get all text object leaves
                    : ((GTextObj)x).Leaves 
                // Flatten the enumerable
                ).SelectMany(x => x);
        }
        /// <summary>
        /// Generates paragraph node.
        /// </summary>
        /// <param name="leaves">List of message leaves</param>
        /// <returns>Paragraph node</returns>
        public static GParagraphNode Generate(params GLeaf[] leaves) =>
            new GParagraphNode {
                // Set data to nothing, because paragraphs don't need anything
                Data = new Dictionary<string, object>(),
                // Generate list of 1 text object with given leaves
                Nodes = new List<IMessageObject>() {
                    new GTextObj {
                       Leaves = leaves.ToList(),
                       Object = GMsgObject.Text
                    }
                }
            };
        /// <summary>
        /// Generates paragraph node.
        /// </summary>
        /// <param name="objs">List of text objects</param>
        /// <returns>Paragraph node</returns>
        public static GParagraphNode Generate(params GTextObj[] objs) =>
            new GParagraphNode {
                // Set data to nothing, because paragraphs don't need anything
                Data = new Dictionary<string, object>(),
                // Generate list of 1 text object with given leaves
                Nodes = objs.Select(x => (IMessageObject)x).ToList()
            };
        /// <summary>
        /// Turns paragraph node to string.
        /// </summary>
        /// <returns>Paragraph as a string</returns>
        public override string ToString() => string.Concat(Nodes) + '\n';
    }
}