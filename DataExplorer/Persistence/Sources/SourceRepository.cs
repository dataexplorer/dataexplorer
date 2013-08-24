using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Persistence.Sources
{
    public class SourceRepository : ISourceRepository
    {
        private readonly IDataContext _context;

        public SourceRepository(IDataContext context)
        {
            _context = context;
        }

        public T GetSource<T>() where T : ISource, new()
        {
            if (!_context.Sources.ContainsKey(typeof(T)))
            {
                var source = new T();
                _context.Sources.Add(source.GetType(), source);
            }

            return (T) _context.Sources[typeof(T)];
        }

        public void SetSource<T>(T source) where T : ISource
        {
            _context.Sources[typeof(T)] = source;
        }
    }
}
