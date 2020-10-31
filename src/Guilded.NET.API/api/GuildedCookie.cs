using RestSharp;

namespace Guilded.NET.API {
    /// <summary>
    /// Cookie for RestRequest.
    /// </summary>
    public class GuildedCookie: RestPair<string, string> {
        /// <summary>
        /// Cookie for RestRequest.
        /// </summary>
        /// <param name="name">Name/Key of the cookie</param>
        /// <param name="value">Cookie's value</param>
        /// <returns></returns>
        public GuildedCookie(string name, string value): base(name, value) {}
        /// <summary>
        /// Adds this to RestRequest.
        /// </summary>
        /// <param name="client">API Request</param>
        /// <returns>Given RestRequest</returns>
        public override IRestRequest AddTo(RestRequest req) => req.AddCookie(Key, Value);
    }
}