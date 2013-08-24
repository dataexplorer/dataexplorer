using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;

namespace DataExplorer.Domain.Sources
{
    public class CsvFileSource : ISource
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
    }
}
