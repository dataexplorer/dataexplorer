using System;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers
{
    public interface ISourceRepository
    {
        T GetSource<T>() where T : Source, new();
        void SetSource<T>(T source) where T : Source;
    }
}
