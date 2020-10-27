using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's link node.
    /// </summary>
    public class GLinkNode: GContainerNode<IMessageObject> {
        public GLinkNode() {
            Object = GMsgObject.Inline;
            Type = GNodeType.Link;
        }
        /// <summary>
        /// Generates link node.
        /// </summary>
        /// <param name="leaves">List of message leaves</param>
        /// <returns>Link node</returns>
        public static GLinkNode Generate(Uri url, params GLeaf[] leaves) =>
            new GLinkNode {
                // Adds link to the link node
                Data = new Dictionary<string, object>() {
                    { "href", url.ToString() }
                },
                // Generate list of 1 text object with given leaves
                Nodes = new List<IMessageObject>() {
                    new GTextObj {
                        Leaves = leaves.ToList(),
                        Object = GMsgObject.Text
                    }
                }
            };
        /// <summary>
        /// Generates link node.
        /// </summary>
        /// <param name="objs">List of text objects</param>
        /// <returns>Link node</returns>
        public static GLinkNode Generate(Uri url, params GTextObj[] objs) =>
            new GLinkNode {
                // Adds link to the link node
                Data = new Dictionary<string, object>() {
                    { "href", url.ToString() }
                },
                // Generate list of 1 text object with given leaves
                Nodes = objs.Select(x => (IMessageObject)x).ToList()
            };
    }
}