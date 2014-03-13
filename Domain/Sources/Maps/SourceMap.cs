using System;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Sources.Maps
{
    public class SourceMap
    {
        public string Name { get; set; }

        public Type SourceType { get; set; }

        public SemanticType SemanticType { get; set; }
    }
}
