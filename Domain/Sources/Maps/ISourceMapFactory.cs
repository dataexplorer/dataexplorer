using System;
using System.Data;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Sources.Maps
{
    public interface ISourceMapFactory
    {
        SourceMap Create(int index, string name, Type dataType, SemanticType semanticType);
    }
}