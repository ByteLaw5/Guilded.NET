using RestSharp;

namespace Guilded.NET.API {
    /// <summary>
    /// JSON body for RestRequest.
    /// </summary>
    public class GJsonBody: GRestValue<object> {
        /// <summary>
        /// JSON for RestRequest.
        /// </summary>
        /// <param name="value">Value to be serialized</param>
        public GJsonBody(object value): base(value) {}
        /// <summary>
        /// Adds this to RestRequest.
        /// </summary>
        /// <param name="client">API Request</param>
        /// <returns>Given RestRequest</returns>
        public override IRestRequest AddTo(RestRequest req) => req.AddJsonBody(Value);
    }
    /// <summary>
    /// Normal body for RestRequest
    /// </summary>
    public class GBody: GRestValue<object> {
        /// <summary>
        /// Normal body for RestRequest.
        /// </summary>
        /// <param name="value">Value to send</param>
        public GBody(object value): base(value) {}
        /// <summary>
        /// Adds this to RestRequest.
        /// </summary>
        /// <param name="client">API Request</param>
        /// <returns>Given RestRequest</returns>
#pragma warning disable 0618
        public override IRestRequest AddTo(RestRequest req) => req.AddBody(Value);
#pragma warning restore 0618
    }
}