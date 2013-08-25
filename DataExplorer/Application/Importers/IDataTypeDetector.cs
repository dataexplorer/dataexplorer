using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Importers
{
    public interface IDataTypeDetector
    {
        Type Detect(IEnumerable<string> values);
    }
}
