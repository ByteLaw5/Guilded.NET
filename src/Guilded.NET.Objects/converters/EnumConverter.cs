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
        static Type msgobjtype = typeof(MsgObject);
        static Type marktype = typeof(MarkType);
        static Type nodetype = typeof(NodeType);
        static Type member = typeof(Membership);
        static Type chattype = typeof(ChatType);
        // All of the allowed types
        static Type[] allowed = new Type[] { msgobjtype, marktype, nodetype, member, chattype };
        // All msgobj enums and their string equivalents
        static Dictionary<string, MsgObject> msgobj = new Dictionary<string, MsgObject> {
            {"block", MsgObject.Block},
            {"document", MsgObject.Document},
            {"inline", MsgObject.Inline},
            {"leaf", MsgObject.Leaf},
            {"mark", MsgObject.Mark},
            {"text", MsgObject.Text},
            {"value", MsgObject.Value}
        };
        // All marktype enums and their string equivalents
        static Dictionary<string, MarkType> marktypes = new Dictionary<string, MarkType> {
            {"bold", MarkType.Bold},
            {"inline-code-v2", MarkType.InlineCode},
            {"italic", MarkType.Italic},
            {"spoiler", MarkType.Spoiler},
            {"strikethrough", MarkType.Strikethrough},
            {"underline", MarkType.Underline}
        };
        // All nodetype enums and their string equivalents
        static Dictionary<string, NodeType> nodetypes = new Dictionary<string, NodeType> {
            {"block-quote-container", NodeType.BlockQuoteContainer},
            {"webhookMessage", NodeType.Embed},
            {"block-quote-line", NodeType.BlockQuoteLine},
            {"paragraph", NodeType.Paragraph},
            {"markdown-plain-text", NodeType.MarkdownPlainText},
            {"code-container", NodeType.CodeContainer},
            {"code-line", NodeType.CodeLine},
            {"unordered-list", NodeType.UnorderedList},
            {"ordered-list", NodeType.OrderedList},
            {"list-item", NodeType.ListItem},
            {"image", NodeType.Image},
            {"reaction", NodeType.Reaction}
        };
        static Dictionary<string, MembershipType> membershiptypes = new Dictionary<string, MembershipType> {
            { "joined", MembershipType.Joined },
            { "left", MembershipType.Left },
            { "following", MembershipType.Following }
        };
        static Dictionary<string, ChatType> chattypes = new Dictionary<string, ChatType> {
            { "Team", ChatType.Team },
            { "DM", ChatType.DM }
        };
        static Dictionary<string, ChannelType> channeltypes = new Dictionary<string, ChannelType> {
            { "chat", ChannelType.Chat },
            { "announcement", ChannelType.Announcement },
            { "voice", ChannelType.Voice },
            { "forum", ChannelType.Forum },
            { "doc", ChannelType.Document },
            { "media", ChannelType.Media },
            { "event", ChannelType.Event },
            { "list", ChannelType.List },
            { "scheduling", ChannelType.Scheduling },
            { "stream", ChannelType.Stream }
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
            if(type == msgobjtype) return ConvertTo<MsgObject>(msgobj, (MsgObject)value);
            else if(type == marktype) return ConvertTo<MarkType>(marktypes, (MarkType)value);
            else if(type == nodetype) return ConvertTo<NodeType>(nodetypes, (NodeType)value);
            else if(type == member) return ConvertTo<MembershipType>(membershiptypes, (MembershipType)value);
            else throw new ArgumentException($"{nameof(value)} is not MsgObject, MarkType or NodeType.");
        }
        /// <summary>
        /// Converts enum value to string.
        /// </summary>
        /// <param name="dict">Dictionary of the enum</param>
        /// <param name="t">Value</param>
        /// <returns>String</returns>
        protected static string ConvertTo<T>(Dictionary<string, T> dict, T t) where T: IConvertible => dict.FirstOrDefault(x => object.Equals(x.Value, t)).Key;
        /// <summary>
        /// Converts string to MsgObject.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>MsgObject value</returns>
        public static MsgObject ConvertMsgFrom(string value) => msgobj[value];
        /// <summary>
        /// Converts string to NodeType.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>NodeType value</returns>
        public static NodeType ConvertNodeFrom(string value) => nodetypes[value];
        /// <summary>
        /// Converts string to MarkType.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>MarkType value</returns>
        public static MarkType ConvertMarkFrom(string value) => marktypes[value];
        /// <summary>
        /// Converts string to MembershipType.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>MembershipType value</returns>
        public static MembershipType ConvertMembershipFrom(string value) => membershiptypes[value];
        /// <summary>
        /// Converts string to ChatType.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>ChatType value</returns>
        public static ChatType ConvertChatTypeFrom(string value) => chattypes[value];
        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <param name="value">String to be parsed</param>
        /// <returns>Any enum value</returns>
        public static object ConvertFrom(string value, Type type) =>
                type == msgobjtype
                ? (object)msgobj[value]
                : type == marktype
                ? (object)marktypes[value]
                : type == member
                ? (object)membershiptypes[value]
                : type == chattype
                ? (object)chattypes[value]
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