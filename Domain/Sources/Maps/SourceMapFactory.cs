using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Sources.Maps
{
    public class SourceMapFactory : ISourceMapFactory
    {
        public SourceMap Create(int index, string name, Type dataType, SemanticType semanticType)
        {
            var map = new SourceMap()
            {
                Index = index,
                Name = name,
                DataType = dataType,
                SemanticType = semanticType,
            };

            return map;
        }
    }
}
