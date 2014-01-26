using DataExplorer.Application.Core.Events;

namespace DataExplorer.Application.Importers.CsvFiles.Events
{
    public class SourceImportProgressChangedEvent : IEvent
    {
        private readonly double _progress;

        public SourceImportProgressChangedEvent(double progress)
        {
            _progress = progress;
        }

        public double Progress
        {
            get { return _progress; }
        }
    }
}
