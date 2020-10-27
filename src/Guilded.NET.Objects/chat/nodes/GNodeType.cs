namespace Guilded.NET.Objects.Chat {
    /// <summary>
    /// Type of the node.
    /// </summary>
    public enum GNodeType {
        // Embeds & blocks
        BlockQuoteContainer, BlockQuoteLine, Embed,
        // Texts & Paragraphs
        Paragraph, Link, MarkdownPlainText,
        // Images & Emotes
        Reaction, Image,
        // Code
        CodeContainer, CodeLine,
        // Lists
        UnorderedList, OrderedList, ListItem
    }
}