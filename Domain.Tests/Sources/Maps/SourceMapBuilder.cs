using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Domain.Tests.Sources.Maps
{
    public class SourceMapBuilder
    {
        private SourceMap _sourceMap;

        public SourceMapBuilder()
        {
            _sourceMap = new SourceMap();
        }

        public SourceMapBuilder WithIndex(int index)
        {
            _sourceMap.Index = index;
            return this;
        }

        public SourceMapBuilder WithName(string name)
        {
            _sourceMap.Name = name;
            return this;
        }

        public SourceMapBuilder WithDataType(Type dataType)
        {
            _sourceMap.DataType = dataType;
            return this;
        }

        public SourceMapBuilder WithSemanticType(SemanticType semanticType)
        {
            _sourceMap.SemanticType = semanticType;
            return this;
        }

        public SourceMap Build()
        {
            return _sourceMap;
        }
    }
}
