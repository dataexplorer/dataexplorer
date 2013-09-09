using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Importers.CsvFile.Body
{
    public class CsvFileImportBodyViewModel : 
        BaseViewModel,
        ICsvFileImportBodyViewModel,
        IAppHandler<CsvFileSourceChangedEvent>
    {
        private readonly ICsvFileImportService _service;

        public CsvFileImportBodyViewModel(ICsvFileImportService service)
        {
            _service = service;
        }

        public List<SourceMapViewModel> MapViewModels
        {
            get { return GetMapViewModels(); }
        }

        private List<SourceMapViewModel> GetMapViewModels()
        {
            return _service.GetMaps()
                .Select(p => new SourceMapViewModel(p))
                .ToList();
        }

        public void Handle(CsvFileSourceChangedEvent args)
        {
            OnPropertyChanged(() => MapViewModels);
        }
    }
}
