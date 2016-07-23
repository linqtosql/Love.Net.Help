// Copyright (c) rigofunc (xuyingting). All rights reserved.

using System.IO;
using System.Reflection;

namespace Love.Net.Help.JsonEditor {
    public class IndexPageStreamFactory : IInedexPageStreamFactory {
        private readonly Assembly _resourceAssembly;
        private readonly string _indexResourceName;

        public IndexPageStreamFactory(string indexResourceName) {
            _resourceAssembly = GetType().GetTypeInfo().Assembly;
            _indexResourceName = indexResourceName;
        }

        public Stream Create() => _resourceAssembly.GetManifestResourceStream(_indexResourceName);
    }
}
