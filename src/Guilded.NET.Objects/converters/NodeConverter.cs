using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Guilded.NET.Objects.Converters {
    using Chat;
    public class NodeConverter: JsonConverter {
        Type node = typeof(GNode);
        Type msgobj = typeof(IMessageObject);
        Dictionary<string, Type> types = new Dictionary<string, Type>() {
            { "paragraph", typeof(GParagraphNode) },
            { "link", typeof(GLinkNode) },
            //{ "text", typeof(GTextObj) },
            { "block-quote-container", typeof(GQuoteBlock) },
            { "block-quote-line", typeof(GQuoteBlockLine) },
            { "markdown-plain-text", typeof(GMarkDownText) },
            { "unordered-list", typeof(GUnorderedList) },
            { "ordered-list", typeof(GOrderedList) },
            { "list-item", typeof(GListItem) },
            { "reaction", typeof(GEmoteNode) },
            //{ "mark", typeof(GMark) },
            //{ "leaf", typeof(GLeaf) }
        };
        Dictionary<string, Type> objs = new Dictionary<string, Type>() {
            { "text", typeof(GTextObj) },
            { "mark", typeof(GMark) },
            { "leaf", typeof(GLeaf) }
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
            // Convert JSON to GNode
            string objparam = obj["object"].Value<string>();
            if(!objs.ContainsKey(objparam)) {
                // Gets object type
                string objtype = obj["type"].Value<string>();
                object o = 
                    types.ContainsKey(objtype)
                    ? obj.ToObject(types[objtype], serializer)
                    : obj.ToObject<GNode>(serializer);
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