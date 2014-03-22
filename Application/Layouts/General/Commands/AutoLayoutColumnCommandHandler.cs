using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.General.Commands
{
    public class AutoLayoutColumnCommandHandler : ICommandHandler<AutoLayoutColumnCommand>
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IEventBus _eventBus;

        public AutoLayoutColumnCommandHandler(
            IColumnRepository columnRepository,
            IViewRepository viewRepository,
            IEventBus eventBus)
        {
            _columnRepository = columnRepository;
            _viewRepository = viewRepository;
            _eventBus = eventBus;
        }

        public void Execute(AutoLayoutColumnCommand command)
        {
            var column = _columnRepository.Get(command.Id);

            var view = _viewRepository.Get<ScatterPlot>();

            var layout = view.GetLayout();

            var setColumnAction = GetSetColumnAction(column, layout);

            setColumnAction(layout, column);

            _eventBus.Raise(new LayoutChangedEvent());
        }

        public Action<ScatterPlotLayout, Column> GetSetColumnAction(Column column, ScatterPlotLayout layout)
        {
            if (column.DataType == typeof (BitmapImage))
                return (l, c) => l.ShapeColumn = c;

            if (column.SemanticType == SemanticType.Uri)
                return (l, c) => l.LinkColumn = c;

            if (layout.XAxisColumn == null)
                return (l, c) => l.XAxisColumn = c;

            if (layout.YAxisColumn == null)
                return (l, c) => l.YAxisColumn = c;

            if (layout.ColorColumn == null)
                return (l, c) => l.ColorColumn = c;

            if (layout.SizeColumn == null)
                return (l, c) => l.SizeColumn = c;
            
            if (layout.LabelColumn == null)
                return (l, c) => l.LabelColumn = c;

            return (l, c) => l.YAxisColumn = c;
        }
    }
}
