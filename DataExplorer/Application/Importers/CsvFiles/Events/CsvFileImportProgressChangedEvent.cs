using DataExplorer.Application.Core.Events;

namespace DataExplorer.Application.Importers.CsvFiles.Events
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
