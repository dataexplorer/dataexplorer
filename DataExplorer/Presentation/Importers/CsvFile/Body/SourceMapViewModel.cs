using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Importers.CsvFile.Body
{
    public class SourceMapViewModel
    {
        private readonly SourceMap _map;
        private readonly FriendlyDataTypeNameConverter _converter;

        public SourceMapViewModel(SourceMap map)
        {
            _map = map;
            _converter = new FriendlyDataTypeNameConverter();
        }

        public SourceMap Map
        {
            get { return _map; }
        }

        public string Name
        {
            get { return _map.Name; }
        }

        public string SourceType
        {
            get { return _converter.Convert(_map.SourceType); }
        }
    }
}