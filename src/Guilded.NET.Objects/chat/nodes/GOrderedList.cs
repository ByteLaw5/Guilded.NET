using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's bulleted/unordered list node.
    /// </summary>
    public class GOrderedList: GContainerNode<GListItem> {
        public GOrderedList() {
            Object = GMsgObject.Block;
            Type = GNodeType.OrderedList;
        }
        /// <summary>
        /// Generates unordered(a.k.a. bulleted) list node.
        /// </summary>
        /// <param name="nodes">List of text objects</param>
        /// <returns>Ordered list node</returns>
        public static GOrderedList Generate(params GTextObj[] objs) =>
            new GOrderedList {
                // Set data to nothing, because lists don't need anything
                Data = new Dictionary<string, object>(),
                // Generate list of 1 text object with given leaves
                Nodes = objs.Select(x => new GListItem(x)).ToList()
            };
    }
}