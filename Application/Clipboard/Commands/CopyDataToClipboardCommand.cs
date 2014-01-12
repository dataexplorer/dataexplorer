using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Exporters.TabFile;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Clipboard.Commands
{
    public class CopyDataToClipboardCommand : ICopyDataToClipboardCommand
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IApplicationStateService _stateService;
        private readonly ITabExporter _exporter;
        private readonly IClipboard _clipboard;

        public CopyDataToClipboardCommand(
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

        public void Execute()
        {
            var columns = _columnRepository.GetAll();

            var rows = _stateService.GetSelectedRows();

            var text = _exporter.Export(columns, rows);

            _clipboard.SetText(text);
        }
    }
}
