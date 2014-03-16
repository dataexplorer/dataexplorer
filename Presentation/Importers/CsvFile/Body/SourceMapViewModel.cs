using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Presentation.Core.Converters;

namespace DataExplorer.Presentation.Importers.CsvFile.Body
{
    public class SourceMapViewModel
    {
        private readonly SourceMap _map;
        private readonly FriendlyDataTypeNameConverter _dataTypeConverter;
        private readonly FriendlySemanticTypeNameConverter _semanticTypeConverter;

        public SourceMapViewModel(SourceMap map)
        {
            _map = map;
            _dataTypeConverter = new FriendlyDataTypeNameConverter();
            _semanticTypeConverter = new FriendlySemanticTypeNameConverter();
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
            get { return _dataTypeConverter.Convert(_map.DataType); }
        }

        public List<string> SemanticTypes
        {
            get
            {
                return Enum.GetValues(typeof (SemanticType))
                    .Cast<SemanticType>()
                    .Select(p => _semanticTypeConverter.Convert(p))
                    .ToList();
            }
        }

        public string SelectedSemanticType
        {
            get { return _semanticTypeConverter.Convert(_map.SemanticType); }
            set { _map.SemanticType = _semanticTypeConverter.Convert(value); }
        }
    }
}