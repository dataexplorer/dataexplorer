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
        public SourceMap Create(DataColumn column)
        {
            var map = new SourceMap()
            {
                Name = column.ColumnName
            };

            return map;
        }
    }
}
