using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Semantics
{
    public interface ISemanticTypeDetector
    {
        SemanticType Detect(Type dataType, List<object> values);
    }
}
