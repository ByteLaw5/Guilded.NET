namespace Guilded.NET.Objects.Teams {
    /// <summary>
    /// Represents types of Guilded channels.
    /// </summary>
    public enum GChannelType {
        // Chat & voice
        Chat, Voice, Stream,
        // Information
        Document, List, Announncement,
        // Posting content
        Media, Forum,
        // Calendar and time related
        Event, Scheduling
    }
}