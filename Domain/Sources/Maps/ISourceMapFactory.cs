using System.Data;

namespace DataExplorer.Domain.Sources.Maps
{
    public interface ISourceMapFactory
    {
        SourceMap Create(SourceColumn column);
    }
}