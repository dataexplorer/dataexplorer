using System;
using System.Collections.Generic;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Columns
{
    public interface IColumnFactory
    {
        Column Create(
            int id,
            int index,
            string name,
            Type dataType,
            SemanticType semanticType,
            List<object> values);
    }
}