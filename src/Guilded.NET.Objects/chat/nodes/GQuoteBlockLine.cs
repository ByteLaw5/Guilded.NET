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
    }
}