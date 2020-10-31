using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guilded.NET.Objects.Converters {
    using Chat;
    public class NodeConverter: JsonConverter {
        Type node = typeof(Node);
        Type msgobj = typeof(IMessageObject);
        Dictionary<string, Type> types = new Dictionary<string, Type> {
            { "paragraph", typeof(ParagraphNode) },
            { "link", typeof(LinkNode) },
            //{ "text", typeof(TextObj) },
            { "block-quote-container", typeof(QuoteBlock) },
            { "block-quote-line", typeof(QuoteBlockLine) },
            { "markdown-plain-text", typeof(MarkDownText) },
            { "unordered-list", typeof(UnorderedList) },
            { "ordered-list", typeof(OrderedList) },
            { "list-item", typeof(ListItem) },
            { "reaction", typeof(EmoteNode) },
            { "webhookMessage", typeof(EmbedNode) }
            //{ "mark", typeof(Mark) },
            //{ "leaf", typeof(Leaf) }
        };
        Dictionary<string, Type> objs = new Dictionary<string, Type> {
            { "text", typeof(TextObj) },
            { "mark", typeof(Mark) },
            { "leaf", typeof(Leaf) }
        };
        /// <summary>
        /// Writes node to the JSON string.
        /// </summary>
        /// <param name="writer">JsonWriter</param>
        /// <param name="value">ID</param>
        /// <param name="serializer">Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => writer.WriteValue(JObject.FromObject(value));
        /// <summary>
        /// Converts object to node.
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="objectType">Type of the object</param>
        /// <param name="existingValue">Previous property value</param>
        /// <param name="serializer">Serializer</param>
        /// <returns>GLongId or GId</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JObject obj = JObject.Load(reader);
            // Create new serializer without this to not make an infinite loop
            // JsonSerializer newer = new JsonSerializer();
            // foreach(JsonConverter converter in serializer.Converters)
            //     if(!(converter is NodeConverter)) newer.Converters.Add(converter);
            // Convert JSON to Node
            string objparam = obj["object"].Value<string>();
            if(!objs.ContainsKey(objparam)) {
                // Gets object type
                string objtype = obj["type"].Value<string>();
                object o = 
                    types.ContainsKey(objtype)
                    ? obj.ToObject(types[objtype], serializer)
                    : obj.ToObject<Node>(serializer);
                return o;
            } else return obj.ToObject(objs[objparam], serializer);
        }
        /// <summary>
        /// Whether or not this converter can convert given type.
        /// </summary>
        /// <param name="objectType">Type of the object</param>
        /// <returns>Can convert the type</returns>
        public override bool CanConvert(Type objectType) => objectType == node || objectType == msgobj;
    }
}