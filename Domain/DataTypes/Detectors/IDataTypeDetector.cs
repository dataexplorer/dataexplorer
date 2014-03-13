using System;
using System.Collections.Generic;

namespace DataExplorer.Domain.DataTypes.Detectors
{
    public interface IDataTypeDetector
    {
        Type Detect(IEnumerable<object> values);
    }
}
