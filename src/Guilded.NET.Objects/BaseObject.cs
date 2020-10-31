using Newtonsoft.Json;
using System;
namespace Guilded.NET.Objects {
    /// <summary>
    /// Base object for all JSON-based Guilded objects.
    /// </summary>
    /// <typeparam name="T">Child type - Type which is inheriting from this type</typeparam>
    public abstract class BaseObject<T> where T: BaseObject<T> {
        /// <summary>
        /// Parses JSON and outputs BaseObject.
        /// </summary>
        /// <param name="json">JSON String</param>
        /// <returns>Deserialized JSON BaseObject</returns>
        public static T Parse(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
