using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Domain.Sources
{
    public class CsvFileSource : ISource
    {
        private string _filePath;

        private List<SourceMap> _maps; 

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                DomainEvents.Raise(new CsvFilePathChangedEvent());
            }
        }

        public CsvFileSource()
        {
            _maps = new List<SourceMap>();
        }

        public void SetMaps(List<SourceMap> maps)
        {
            _maps = maps;
        }

        public List<SourceMap> GetMaps()
        {
            return _maps;
        }
    }
}
