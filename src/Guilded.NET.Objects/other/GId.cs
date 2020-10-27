namespace Guilded.NET.Objects {
    /// <summary>
    /// Represents team, group and user IDs.
    /// </summary>
    public sealed class GId {
        static int idlength = 8;
        internal static InvalidIdException IdException = new InvalidIdException("Could not parse the given short ID string.");
        internal static string AvailableChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
        string _;
        internal GId(string id) => _ = id;
        /// <summary>
        /// Parse string as a short ID.
        /// </summary>
        /// <param name="id">String to be parsed</param>
        /// <exception cref="InvalidIdException">String couldn't be parsed</exception>
        /// <returns>Short ID</returns>
        public static GId Parse(string id) {
            // If length isn't 8
            if(id.Length != idlength) throw IdException;
            // If each character is correct
            else if(!IsCorrect(id)) throw IdException;
            // Return the id
            return new GId(id);
        }
        /// <summary>
        /// Tries to parse string as a short ID. Doesn't throw an error when fails.
        /// </summary>
        /// <param name="idstr">String to be parsed</param>
        /// <param name="id">Variable to be changed</param>
        /// <returns>Succeeded</returns>
        public static bool TryParse(string idstr, out GId id) {
            #pragma warning disable 0168
            try {
                id = Parse(idstr);
                return true;
            } catch(InvalidIdException e) {
                id = null;
                return false;
            }
            #pragma warning restore 0168
        }
        static bool IsCorrect(string str) {
            foreach(char c in str)
                if(!AvailableChars.Contains(c.ToString())) return false;
            return true;
        }
        /// <summary>
        /// Converts short ID to string.
        /// </summary>
        /// <returns>Short ID string</returns>
        public override string ToString() => _;
    }
}