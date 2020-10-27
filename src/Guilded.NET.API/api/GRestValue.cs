using RestSharp;

namespace Guilded.NET.API {
    /// <summary>
    /// Value for RestRequests.
    /// </summary>
    /// <typeparam name="TKey">Key type of the pair</typeparam>
    /// <typeparam name="TValue">Value type of the pair</typeparam>
    public abstract class GRestValue<T>: IReqAddable {
        /// <summary>
        /// Value of the request object.
        /// </summary>
        /// <value>Given value</value>
        public T Value {
            get; set;
        }
        /// <summary>
        /// Value for RestRequest.
        /// </summary>
        /// <param name="value">Pair value</param>
        protected GRestValue(T value) => Value = value;
        /// <summary>
        /// Adds this to RestRequest.
        /// </summary>
        /// <param name="client">API Request</param>
        /// <returns>Given RestRequest</returns>
        public abstract IRestRequest AddTo(RestRequest req);
        /// <summary>
        /// Casts GPair to KeyValuePair.
        /// </summary>
        /// <param name="pair">Pair to be casted</param>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <returns>New pair</returns>
        public static implicit operator T(GRestValue<T> restvalue) =>
            restvalue.Value;
    }
}