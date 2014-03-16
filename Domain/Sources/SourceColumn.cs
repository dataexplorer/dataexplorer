using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Sources
{
    public class SourceColumn
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public Type DataType { get; set; }

        public SemanticType SemanticType { get; set; }
    }
}
