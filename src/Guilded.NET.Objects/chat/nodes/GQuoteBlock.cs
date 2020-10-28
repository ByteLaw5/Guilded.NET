using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's quote block node.
    /// </summary>
    public class GQuoteBlock: GContainerNode<GQuoteBlockLine> {
        public GQuoteBlock() {
            Object = GMsgObject.Block;
            Type = GNodeType.BlockQuoteContainer;
        }
        /// <summary>
        /// Generates quote block node.
        /// </summary>
        /// <param name="objs">List of text objects</param>
        /// <returns>Quote block node</returns>
        public static GQuoteBlock Generate(params GTextObj[] objs) =>
            new GQuoteBlock {
                // Set data to nothing, because quote blocks don't need anything
                Data = new Dictionary<string, object>(),
                // Generate list of 1 text object with given leaves
                Nodes = objs.Select(x => new GQuoteBlockLine(x)).ToList()
            };
        /// <summary>
        /// Turns quote block to string.
        /// </summary>
        /// <returns>Quote block as a string</returns>
        public override string ToString() => string.Concat(Nodes);
    }
}