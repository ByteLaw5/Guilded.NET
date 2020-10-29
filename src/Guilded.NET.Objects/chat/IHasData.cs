using System.Collections.Generic;

namespace Guilded.NET.Objects.Chat {
    public interface IHasData<T> {
        /// <summary>
        /// Data of the node.
        /// </summary>
        /// <value>Node data</value>
        IDictionary<string, T> Data {
            get; set;
        }
    }
}