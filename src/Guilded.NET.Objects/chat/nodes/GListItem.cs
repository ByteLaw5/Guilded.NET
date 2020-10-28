using Newtonsoft.Json;
using System.Linq;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// List item in Guilded.
    /// </summary>
    public class GListItem: GContainerNode<IMessageObject> {
        public GListItem() {
            Type = GNodeType.ListItem;
            Object = GMsgObject.Block;
        }
        /// <param name="objs">Text objects to create line from</param>
        public GListItem(params IMessageObject[] objs): this() => Nodes = objs.ToList();
        /// <summary>
        /// Turns list item to string.
        /// </summary>
        /// <returns>List item as a string</returns>
        public override string ToString() => string.Concat(Nodes);
    }
}