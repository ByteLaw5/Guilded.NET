using Newtonsoft.Json;
using System.Linq;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Line of code block in Guilded.
    /// </summary>
    public class CodeLine: ContainerNode<IMessageObject> {
        public CodeLine() {
            Type = NodeType.CodeLine;
            Object = MsgObject.Block;
        }
        /// <summary>
        /// Generates code block line.
        /// </summary>
        /// <param name="objs">Text objects to create line from</param>
        /// <returns>Code block line</returns>
        public static CodeLine Generate(params IMessageObject[] objs) =>
            new CodeLine {
                Nodes = objs.ToList()
            };
        /// <summary>
        /// Turns code block line to string.
        /// </summary>
        /// <returns>Code block line as a string</returns>
        public override string ToString() => string.Concat(Nodes) + '\n';
    }
}