using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Sources.Maps
{
    public class SourceMapFactory : ISourceMapFactory
    {
        public SourceMap Create(SourceColumn column)
        {
            var map = new SourceMap()
            {
                Name = column.Name,
                SourceType = column.DataType,
                SemanticType = column.SemanticType,
            };

            return map;
        }
    }
}
