using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Presentation.Importers.CsvFile.Body
{
    public class SourceMapViewModel
    {
        private readonly SourceMap _map;

        public SourceMapViewModel(SourceMap map)
        {
            _map = map;
        }

        public SourceMap Map
        {
            get { return _map; }
        }

        public string Name
        {
            get { return _map.Name; }
        }
    }
}