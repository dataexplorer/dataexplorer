using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Property
{
    public class PropertyPaneViewModel 
        : BaseViewModel,
        IPropertyPaneViewModel,
        IEventHandler<SelectedRowsChangedEvent>,
        IEventHandler<CsvFileImportingEvent>,
        IEventHandler<ProjectOpeningEvent>
    {
        private readonly IColumnService _columnService;
        private readonly IRowService _rowService;
        private readonly IProcess _process;

        public PropertyPaneViewModel(
            IColumnService columnService, 
            IRowService rowService, 
            IProcess process)
        {
            _columnService = columnService;
            _rowService = rowService;
            _process = process;
        }

        public IEnumerable<IPropertyViewModel> Properties
        {
            get
            {
                var row = _rowService.GetSelectedRow();

                if (row == null)
                    return new List<PropertyViewModel>();

                var fields = row.Fields.ToList();

                var columns = _columnService.GetAllColumns();

                return columns.Select(p => new PropertyViewModel(
                    p.Name,
                    GetDisplayValue(p.Index, fields),
                    _process));
            }
        }

        private string GetDisplayValue(int index, List<object> fields)
        {
            var field = fields[index];

            if (field == null)
                return string.Empty;

            return field.ToString();
        }

        public void Handle(SelectedRowsChangedEvent args)
        {
            OnPropertyChanged(() => Properties);
        }

        public void Handle(CsvFileImportingEvent args)
        {
            OnPropertyChanged(() => Properties);
        }

        public void Handle(ProjectOpeningEvent args)
        {
            OnPropertyChanged(() => Properties);
        }
    }
}
