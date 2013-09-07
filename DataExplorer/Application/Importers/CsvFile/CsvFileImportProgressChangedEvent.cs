using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class CsvFileImportProgressChangedEvent : IAppEvent
    {
        private readonly double _progress;

        public CsvFileImportProgressChangedEvent(double progress)
        {
            _progress = progress;
        }

        public double Progress
        {
            get { return _progress; }
        }
    }
}
