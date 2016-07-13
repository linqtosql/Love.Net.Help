// Copyright (c) rigofunc (xuyingting). All rights reserved.

namespace Love.Net.Help {
    public class ApiHelpOptions {
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
