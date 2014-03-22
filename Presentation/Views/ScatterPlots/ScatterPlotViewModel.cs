using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views.ScatterPlots.Events;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Collections;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewModel 
        : BaseViewModel, 
        IScatterPlotViewModel,
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<SourceImportedEvent>,
        IDomainHandler<ScatterPlotChangedEvent>
    {
        private readonly IScatterPlotContextMenuViewModel _contextMenuViewModel;
        private readonly IScatterPlotViewModelQueries _queries;
        private readonly IScatterPlotViewModelCommands _commands;
        private readonly FastObservableCollection<CanvasItem> _selectedItems; 

        private Size _controlSize;

        public IScatterPlotContextMenuViewModel ContextMenuViewModel
        {
            get { return _contextMenuViewModel; }
        }

        public Size ControlSize
        {
            set { HandleControlSizeChanged(value); }
        }

        public List<CanvasItem> Items
        {
            get { return _queries.GetItems(_controlSize).ToList(); }
        }

        public ICollection<CanvasItem> SelectedItems
        {
            get { return _selectedItems; }
        }

        public ScatterPlotViewModel(
            IScatterPlotContextMenuViewModel contextMenuViewModel,
            IScatterPlotViewModelQueries queries,
            IScatterPlotViewModelCommands commands)
        {
            _contextMenuViewModel = contextMenuViewModel;
            _queries = queries;
            _commands = commands;

            _selectedItems = new FastObservableCollection<CanvasItem>();

            _selectedItems.CollectionChanged += HandleSelectedItemsChanged;
        }

        private void HandleControlSizeChanged(Size controlSize)
        {
            _controlSize = controlSize;

            _commands.Resize(_controlSize);
        }

        public void HandleZoomIn(Point center)
        {
            _commands.ZoomIn(center, _controlSize);
        }

        public void HandleZoomOut(Point center)
        {
            _commands.ZoomOut(center, _controlSize);
        }

        public void HandlePan(Vector vector)
        {
            _commands.Pan(vector, _controlSize);
        }

        public void HandleExecute(int id)
        {
            _commands.Execute(id);
        }

        public void Handle(ScatterPlotChangedEvent args)
        {
            OnPropertyChanged(() => Items);
        }

        public void Handle(ProjectOpenedEvent args)
        {
            OnPropertyChanged(() => Items);
            OnPropertyChanged(() => SelectedItems);
        }

        public void Handle(ProjectClosedEvent args)
        {
            _selectedItems.Clear();

            OnPropertyChanged(() => Items);
            OnPropertyChanged(() => SelectedItems);
        }

        public void Handle(SourceImportedEvent args)
        {
            OnPropertyChanged(() => Items);
            OnPropertyChanged(() => SelectedItems);
        }
        
        private void HandleSelectedItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _commands.Select(_selectedItems.ToList());
        }

        public bool IsValidLayoutDropSource(Column column)
        {
            return true;
        }

        public void HandleSetDragDropLayout(Column column)
        {
            _commands.Layout(column.Id);
        }
    }
}
