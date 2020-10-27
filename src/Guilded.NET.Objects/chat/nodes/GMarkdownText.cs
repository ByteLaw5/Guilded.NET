using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's paragraph node.
    /// </summary>
    public class GMarkDownText: GContainerNode<IMessageObject> {
        public GMarkDownText() {
            Object = GMsgObject.Block;
            Type = GNodeType.MarkdownPlainText;
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
                        Leaves = leaves.ToList()
                    }
                }
            };
    }
}