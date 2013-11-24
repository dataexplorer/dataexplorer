using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Exporters;
using DataExplorer.Application.Exporters.TabFile;
using DataExplorer.Domain.Columns;
using DataExplorer.Infrastructure.Clipboard;

namespace DataExplorer.Application.Clipboard
{
    public class ClipboardService : IClipboardService
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IApplicationStateService _stateService;
        private readonly ITabExporter _exporter;
        private readonly IClipboard _clipboard;

        public ClipboardService(
            IColumnRepository columnRepository,
            IApplicationStateService stateService,
            ITabExporter exporter,
            IClipboard clipboard)
        {
            _columnRepository = columnRepository;
            _stateService = stateService;
            _exporter = exporter;
            _clipboard = clipboard;
        }

        public void Copy()
        {
            var columns = _columnRepository.GetAll();

            var rows = _stateService.SelectedRows;

            var text = _exporter.Export(columns, rows);

            _clipboard.SetText(text);
        }
    }
}
