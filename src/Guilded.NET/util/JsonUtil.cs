using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace Guilded.NET.Util {
    /// <summary>
    /// Utilities for JSON related things.
    /// </summary>
    public static class JsonUtil {
#pragma warning disable 0168
        /// <summary>
        /// Tries to parse JArray.
        /// </summary>
        /// <param name="json">JSON Array</param>
        /// <param name="arr">Variable to be changed</param>
        /// <returns>If JArray was parsed</returns>
        public static bool TryParse(string json, out JArray arr) {
            try {
                arr = JArray.Parse(json);
                return true;
            } catch(JsonReaderException e) {
                arr = null;
                return false;
            }
        }
        /// <summary>
        /// Tries to parse JObject.
        /// </summary>
        /// <param name="json">JSON Object</param>
        /// <param name="obj">Variable to be changed</param>
        /// <returns>If JObject was parsed</returns>
        public static bool TryParse(string json, out JObject obj) {
            try {
                obj = JObject.Parse(json);
                return true;
            } catch(JsonReaderException e) {
                obj = null;
                return false;
            }
        }
#pragma warning restore 0168
    }
}