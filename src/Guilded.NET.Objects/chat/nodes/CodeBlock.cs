using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Represents Guilded's code block node.
    /// </summary>
    public class CodeBlock: ContainerNode<CodeLine> {
        public CodeBlock() {
            Object = MsgObject.Block;
            Type = NodeType.CodeContainer;
        }
        /// <summary>
        /// Generates code block node.
        /// </summary>
        /// <param name="objs">List of code lines</param>
        /// <returns>Code block node</returns>
        public static CodeBlock Generate(string language = null, params CodeLine[] objs) =>
            new CodeBlock {
                Nodes = objs.Select(x => CodeLine.Generate(x)).ToList(),
                // Sets a language. If it's null, then set it as unformatted
                Data = new Dictionary<string, object> {
                    { "language", string.IsNullOrWhiteSpace(language) ? "unformatted" : language.ToLower() }
                }
            };
        /// <summary>
        /// Turns code block to string.
        /// </summary>
        /// <returns>Code block as a string</returns>
        public override string ToString() => string.Concat(Nodes);
    }
}