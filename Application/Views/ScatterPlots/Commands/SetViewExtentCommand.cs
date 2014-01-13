using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class SetViewExtentCommand : ICommand
    {
        private readonly Rect _viewExtent;

        public SetViewExtentCommand(Rect viewExtent)
        {
            _viewExtent = viewExtent;
        }

        public Rect ViewExtent
        {
            get { return _viewExtent; }
        }
    }
}
