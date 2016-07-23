// Copyright (c) rigofunc (xuyingting). All rights reserved.

using System.IO;

namespace Love.Net.Help {
    /// <summary>
    /// Defines the interface(s) for creating the stream of Index.html file.
    /// </summary>
    public interface IInedexPageStreamFactory {
        /// <summary>
        /// Creates the stream of the Index.html file.
        /// </summary>
        /// <returns>Stream.</returns>
        Stream Create();
    }
}
