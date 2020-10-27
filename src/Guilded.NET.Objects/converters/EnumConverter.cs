using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

// Ultimate spaghetti code
namespace Guilded.NET.Objects.Converters {
    using Chat;
    using Teams;
    /// <summary>
    /// Converts enum to string and vice versa.
    /// </summary>
    public class EnumConverter: JsonConverter {
        // For checking types
        static Type gmsgobjtype = typeof(GMsgObject);
        static Type gmarktype = typeof(GMarkType);
        static Type gnodetype = typeof(GNodeType);
        static Type gmember = typeof(GMembership);
        // All of the allowed types
        static Type[] allowed = new Type[] { gmsgobjtype, gmarktype, gnodetype };
        // All msgobj enums and their string equivalents
        static Dictionary<string, GMsgObject> msgobj = new Dictionary<string, GMsgObject>() {
            {"block", GMsgObject.Block},
            {"document", GMsgObject.Document},
            {"inline", GMsgObject.Inline},
            {"leaf", GMsgObject.Leaf},
            {"mark", GMsgObject.Mark},
            {"text", GMsgObject.Text},
            {"value", GMsgObject.Value}
        };
        // All marktype enums and their string equivalents
        static Dictionary<string, GMarkType> marktypes = new Dictionary<string, GMarkType>() {
            {"bold", GMarkType.Bold},
            {"inline-code-v2", GMarkType.InlineCode},
            {"italic", GMarkType.Italic},
            {"spoiler", GMarkType.Spoiler},
            {"strikethrough", GMarkType.Strikethrough},
            {"underline", GMarkType.Underline}
        };
        // All nodetype enums and their string equivalents
        static Dictionary<string, GNodeType> nodetypes = new Dictionary<string, GNodeType>() {
            {"block-quote-container", GNodeType.BlockQuoteContainer},
            {"webhookMessage", GNodeType.Embed},
            {"block-quote-line", GNodeType.BlockQuoteLine},
            {"paragraph", GNodeType.Paragraph},
            {"markdown-plain-text", GNodeType.MarkdownPlainText},
            {"code-container", GNodeType.CodeContainer},
            {"code-line", GNodeType.CodeLine},
            {"unordered-list", GNodeType.UnorderedList},
            {"ordered-list", GNodeType.OrderedList},
            {"list-item", GNodeType.ListItem},
            {"image", GNodeType.Image},
            {"reaction", GNodeType.Reaction}
        };
        static Dictionary<string, GMembershipType> membershiptypes = new Dictionary<string, GMembershipType>() {
            { "joined", GMembershipType.Joined },
            { "left", GMembershipType.Left },
            { "following", GMembershipType.Following }
        };
        /// <summary>
        /// Writes enum to the string.
        /// </summary>
        /// <param name="writer">JsonWriter</param>
        /// <param name="value">Enum</param>
        /// <param name="serializer">Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => writer.WriteValue(ConvertTo(value, value.GetType()));
        /// <summary>
        /// Converts enum value to string.
        /// </summary>
        /// <param name="value">Value to convert to string</param>
        /// <param name="type">Type of the value</param>
        /// <returns>String</returns>
        public static string ConvertTo(object value, Type type) {
            if(type == gmsgobjtype) return ConvertTo<GMsgObject>(msgobj, (GMsgObject)value);
            else if(type == gmarktype) return ConvertTo<GMarkType>(marktypes, (GMarkType)value);
            else if(type == gnodetype) return ConvertTo<GNodeType>(nodetypes, (GNodeType)value);
            else if(type == gmember) return ConvertTo<GMembershipType>(membershiptypes, (GMembershipType)value);
            else throw new ArgumentException($"{nameof(value)} is not GMsgObject, GMarkType or GNodeType.");
        }
        /// <summary>
        /// Converts enum value to string.
        /// </summary>
        /// <param name="dict">Dictionary of the enum</param>
        /// <param name="t">Value</param>
        /// <returns>String</returns>
        protected static string ConvertTo<T>(Dictionary<string, T> dict, T t) where T: IConvertible => dict.FirstOrDefault(x => object.Equals(x.Value, t)).Key;
        /// <summary>
        /// Converts string to GMsgObject.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>GMsgObject value</returns>
        public static GMsgObject ConvertMsgFrom(string value) => msgobj[value];
        /// <summary>
        /// Converts string to GNodeType.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>GNodeType value</returns>
        public static GNodeType ConvertNodeFrom(string value) => nodetypes[value];
        /// <summary>
        /// Converts string to GMarkType.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>GMarkType value</returns>
        public static GMarkType ConvertMarkFrom(string value) => marktypes[value];
        /// <summary>
        /// Converts string to GMembershipType.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>GMembershipType value</returns>
        public static GMembershipType ConvertMembershipFrom(string value) => membershiptypes[value];
        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>Any enum value</returns>
        public static object ConvertFrom(string value, Type type) =>
                type == gmsgobjtype
                ? (object)msgobj[value]
                : type == gmarktype
                ? (object)marktypes[value]
                : type == gmember
                ? (object)membershiptypes[value]
                : (object)nodetypes[value];
        
        /// <summary>
        /// Converts string to enum.
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="objectType">Type of the object</param>
        /// <param name="existingValue">Previous property value</param>
        /// <param name="serializer">Serializer</param>
        /// <returns>GLongId or GId</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => ConvertFrom((string)reader.Value, objectType);
        /// <summary>
        /// Whether or not this converter can convert given type.
        /// </summary>
        /// <param name="objectType">Type of the object</param>
        /// <returns>Can convert the type</returns>
        public override bool CanConvert(Type objectType) => allowed.Contains(objectType);
    }
}