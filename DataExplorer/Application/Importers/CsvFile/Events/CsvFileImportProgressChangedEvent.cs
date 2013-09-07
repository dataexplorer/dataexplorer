using DataExplorer.Application.Events;

namespace DataExplorer.Application.Importers.CsvFile.Events
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
