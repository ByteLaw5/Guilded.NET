using Newtonsoft.Json;
using System.Linq;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Line of quote block in Guilded.
    /// </summary>
    public class GQuoteBlockLine: GContainerNode<IMessageObject> {
        public GQuoteBlockLine() {
            Type = GNodeType.BlockQuoteLine;
            Object = GMsgObject.Block;
        }
        /// <param name="objs">Text objects to create line from</param>
        public GQuoteBlockLine(params IMessageObject[] objs): this() => Nodes = objs.ToList();
        /// <summary>
        /// Turns quote block to string.
        /// </summary>
        /// <returns>Quote block as a string</returns>
        public override string ToString() => $"> {string.Concat(Nodes)}\n";
    }
}