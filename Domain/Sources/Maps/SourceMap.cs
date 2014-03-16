using System;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Sources.Maps
{
    public class SourceMap
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public Type DataType { get; set; }

        public SemanticType SemanticType { get; set; }
    }
}
