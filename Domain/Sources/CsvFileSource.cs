using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Sources.Events;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Domain.Sources
{
    public class CsvFileSource : Source
    {
        private string _filePath;

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
    }
}
