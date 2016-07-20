// Copyright (c) rigofunc (xuyingting). All rights reserved.

namespace Love.Net.Help {
    public class ApiHelpOptions {
        /// <summary>
        /// Gets or sets a value indicating whether include supported media type.
        /// </summary>
        /// <value><c>true</c> if include supported media type; otherwise, <c>false</c>.</value>
        public bool IncludeSupportedMediaType { get; set; }
        /// <summary>
        /// Gets or sets the value indicating whether ignore obsolete API or not.
        /// </summary>
        /// <value>The value indicating whether ignore obsolete API or not.</value>
        public bool IgnoreObsoleteApi { get; set; } = true;

        /// <summary>
        /// Gets or sets the API document loading policy.
        /// </summary>
        /// <value>The API document loading policy.</value>
        public LoadingPolicy LoadingPolicy { get; set; }
    }

    public enum LoadingPolicy {
        /// <summary>
        /// Indicating eager loading.
        /// </summary>
        Eager,
        /// <summary>
        /// Indicating lazy loading.
        /// </summary>
        Lazy,
    }
}
